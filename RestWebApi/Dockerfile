# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source

# copy everything else and build app
COPY ./ ./aspnetapp/
WORKDIR /source/aspnetapp
RUN dotnet add package microsoft.entityframeworkcore -v 5.0.3
RUN dotnet add package microsoft.entityframeworkcore.Sqlite -v 5.0.3
RUN dotnet add package microsoft.entityframeworkcore.Design -v 5.0.3
RUN dotnet tool install --global dotnet-ef
ENV PATH="${PATH}:/root/.dotnet/tools"
RUN dotnet-ef database update
RUN dotnet publish -c release -o /app --no-restore
COPY ./Main.db /app

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app ./

ENTRYPOINT ["dotnet", "RestWebApi.dll"]
