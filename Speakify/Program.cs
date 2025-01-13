var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Registo do IParameterFactory e das implementa��es de Facades
builder.Services.AddScoped<Speakify.Interfaces.IParameterFactory, Speakify.Implementations.ConfigurableParameterFactory>();
builder.Services.AddScoped<Speakify.Facades.AnalyticsFacade>();
builder.Services.AddScoped<Speakify.Facades.ConfigurationFacade>();
builder.Services.AddScoped<Speakify.Facades.RealizationFacade>();

// Registo dos Observers
builder.Services.AddScoped<Speakify.Implementations.Observers.ActivityAnalyticsObserver>();
builder.Services.AddScoped<Speakify.Implementations.Observers.ActivityLoggingObserver>();

// Configura��o do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
