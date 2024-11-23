# Etapa 1: Usar imagem oficial do .NET SDK para compilar o aplicativo
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copiar arquivos da solução e do projeto
COPY Speakify.sln .                        # Copia o arquivo de solução
COPY Speakify/*.csproj ./Speakify/         # Copia o arquivo .csproj

# Restaurar dependências
RUN dotnet restore

# Copiar o restante do código-fonte
COPY Speakify/. ./Speakify/                # Copia todos os arquivos do projeto
WORKDIR /app/Speakify                      # Define o diretório de trabalho como o do projeto

# Compilar e publicar o aplicativo
RUN dotnet publish -c Release -o /out

# Etapa 2: Usar uma imagem menor (runtime) para execução
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app

# Copiar os arquivos publicados da etapa anterior
COPY --from=build /out ./

# Configurar o comando para iniciar o aplicativo
ENTRYPOINT ["dotnet", "Speakify.dll"]
