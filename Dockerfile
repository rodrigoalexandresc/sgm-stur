FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY /src/STUR-mvc/STUR-mvc.csproj .
COPY /src/STUR-mvc/appsettings.json .
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o /appstur

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build /appstur .
ENTRYPOINT ["dotnet", "STUR-mvc.dll"]
EXPOSE 8080