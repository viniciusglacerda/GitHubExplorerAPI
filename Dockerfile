# Utilize a imagem base do .NET 8.0 SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

# Defina o diretório de trabalho dentro do contêiner
WORKDIR /app

# Copie o arquivo csproj e restaure as dependências do NuGet
COPY *.csproj ./
RUN dotnet restore

# Copie todo o conteúdo do diretório atual para o diretório de trabalho do contêiner
COPY . ./

# Build do projeto
RUN dotnet publish -c Release -o out

# Segunda fase do build
FROM mcr.microsoft.com/dotnet/aspnet:8.0

# Defina o diretório de trabalho dentro do contêiner
WORKDIR /app

# Copie os arquivos publicados da fase anterior para o diretório de trabalho do contêiner
COPY --from=build-env /app/out .

# Exponha a porta 10000
EXPOSE 10000

# Execute o aplicativo quando o contêiner for iniciado
ENTRYPOINT ["dotnet", "GitHubExplorerAPI.dll"]
