# Use a imagem .NET SDK para construir o projeto
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Define o diretório de trabalho dentro do contêiner
WORKDIR /app

# Copia o arquivo da solução para o diretório de trabalho
COPY ./Speakify.sln ./

# Copia os arquivos do projeto para o contêiner
COPY ./Speakify/*.csproj ./Speakify/

# Restaura as dependências do projeto
RUN dotnet restore

# Copia o restante dos arquivos do projeto
COPY ./Speakify/. ./Speakify/

# Define o diretório de trabalho para o projeto
WORKDIR /app/Speakify

# Compila o projeto
RUN dotnet publish -c Release -o out

# Use a imagem do runtime .NET para rodar o app
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime

# Define o diretório de trabalho no contêiner de runtime
WORKDIR /app

# Copia os arquivos publicados da etapa de build para o runtime
COPY --from=build /app/Speakify/out .

# Define o comando para iniciar o aplicativo
ENTRYPOINT ["dotnet", "Speakify.dll"]
