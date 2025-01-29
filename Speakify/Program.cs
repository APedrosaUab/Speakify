using Speakify.Facades;
using Speakify.Interfaces;
using Speakify.Implementations;
using Speakify.Implementations.Observers;

var builder = WebApplication.CreateBuilder(args);

// Adiciona servi�os ao cont�iner
builder.Services.AddControllersWithViews();

// Registo do IParameterFactory e das implementa��es de Facades
builder.Services.AddScoped<IParameterFactory, ConfigurableParameterFactory>();
builder.Services.AddScoped<IConfigurationFacade, ConfigurationFacade>();
builder.Services.AddScoped<AnalyticsFacade>();
builder.Services.AddScoped<RealizationFacade>();

// Registo dos Observers
builder.Services.AddScoped<ActivityLoggingObserver>();

// Configura��o do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configura��o do pipeline HTTP
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
