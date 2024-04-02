FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
ENV eShopDb="Server=10.0.0.29,1433; Database=eShopApiDb; User=SA; Password=NewStrongPassword456; TrustServerCertificate=True;"
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Customer/Customer.csproj", "Customer/"]
COPY ["Customer.Infrustructure/Customer.Infrustructure.csproj", "Customer.Infrustructure/"]
COPY ["Customer.ApplicationCore/Customer.ApplicationCore.csproj", "Customer.ApplicationCore/"]
COPY ["JWTAuth/JWTAuth.csproj", "JWTAuth/"]
RUN dotnet restore "Customer/Customer.csproj"
COPY . .
WORKDIR "/src/Customer"
RUN dotnet build "Customer.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Customer.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Customer.dll"]
