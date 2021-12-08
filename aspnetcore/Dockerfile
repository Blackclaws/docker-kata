FROM mcr.microsoft.com/dotnet/sdk:6.0 AS builder

WORKDIR /code

COPY . .

RUN dotnet publish -o /app

FROM mcr.microsoft.com/dotnet/aspnet:6.0

WORKDIR /app
COPY --from=builder /app/* ./

EXPOSE 8080

COPY docker-build/appsettings.json ./appsettings.json

ENTRYPOINT [ "dotnet", "aspnetcore.dll", "--urls", "http://*:8080" ]
