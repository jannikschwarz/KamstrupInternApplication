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