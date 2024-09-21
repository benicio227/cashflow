FROM mcr.microsoft.com/dotnet/sdk:8.0.4 AS build-env
WORKDIR /app

COPY src/ .

WORKDIR /app/CashFlow3.Api

RUN dotnet restore

RUN dotnet publish -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:8.0.4
WORKDIR /app

COPY --from=build-env /app/out . 

ENTRYPOINT ["dotnet", "CashFlow3.Api.dll"]