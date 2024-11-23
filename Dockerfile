# Etapa 1: Usar imagem oficial do .NET SDK para compilar o aplicativo
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copiar o arquivo de solução e projetos
COPY ./*.sln ./                             # Copia o arquivo de solução
COPY ./Speakify/*.csproj ./Speakify/        # Copia o arquivo do projeto .csproj

# Restaurar dependências
RUN dotnet restore

# Copiar o restante dos arquivos do projeto
COPY ./Speakify/. ./Speakify/               # Copia todos os arquivos do projeto para a pasta correspondente
WORKDIR /app/Speakify                       # Define o diretório de trabalho como o do projeto

# Compilar e publicar o aplicativo
RUN dotnet publish -c Release -o /out

# Etapa 2: Usar uma imagem menor (runtime) para execução
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app

# Copiar os arquivos publicados da etapa anterior
COPY --from=build /out ./

# Configurar o comando para iniciar o aplicativo
ENTRYPOINT ["dotnet", "Speakify.dll"]
