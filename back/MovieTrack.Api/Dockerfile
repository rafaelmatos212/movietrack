# Etapa 1: build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY Directory.Build.props .
COPY MovieTrack.Api/*.csproj ./MovieTrack.Api/
COPY MovieTrack.Application/*.csproj ./MovieTrack.Application/
COPY MovieTrack.Domain/*.csproj ./MovieTrack.Domain/
COPY MovieTrack.Infra/*.csproj ./MovieTrack.Infra/

RUN dotnet restore MovieTrack.Api/MovieTrack.Api.csproj

COPY MovieTrack.Api/. ./MovieTrack.Api/
COPY MovieTrack.Application/. ./MovieTrack.Application/
COPY MovieTrack.Domain/. ./MovieTrack.Domain/
COPY MovieTrack.Infra/. ./MovieTrack.Infra/

RUN dotnet publish MovieTrack.Api/MovieTrack.Api.csproj -c Release -o /app/publish --no-restore

# Etapa 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080
USER app
ENTRYPOINT ["dotnet", "MovieTrack.Api.dll"]
