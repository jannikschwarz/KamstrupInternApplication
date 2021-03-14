# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source

# copy everything else and build app
COPY ./ ./aspnetapp/
WORKDIR /source/aspnetapp
RUN dotnet add package Swashbuckle.AspNetCore -v 6.1.0
RUN dotnet add package System.Data.SqlClient -v 4.8.2
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app ./

ENTRYPOINT ["dotnet", "RestWebApi.dll"]
