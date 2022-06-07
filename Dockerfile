FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

RUN mkdir data
ENV PATH="${PATH}:/root/.dotnet/tools"

RUN dotnet tool install --global dotnet-ef || echo "dotnet-ef already installed"

COPY CompanyApi.sln .
COPY CompanyApi/CompanyApi.csproj ./CompanyApi/
COPY SqlLiteMigrations/SqlLiteMigrations.csproj ./SqlLiteMigrations/
COPY SqlServerMigrations/SqlServerMigrations.csproj ./SqlServerMigrations/
RUN dotnet restore

COPY . .
RUN dotnet build
RUN dotnet ef database update --no-build -p CompanyApi
RUN dotnet publish -c Release -o publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS run-env
WORKDIR /app

COPY --from=build-env /app/publish .
COPY --from=build-env /app/data ./data

EXPOSE 80
EXPOSE 443

ENTRYPOINT ["dotnet", "CompanyApi.dll"]