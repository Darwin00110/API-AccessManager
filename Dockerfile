FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR ./API-AccessManeger

COPY . .

RUN dotnet restore ./API-AccessManeger.csproj
RUN dotnet ef database update
RUN dotnet publish ./API-AccessManeger.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:10000

EXPOSE 10000

ENTRYPOINT ["dotnet", "API-AccessManeger.dll"]