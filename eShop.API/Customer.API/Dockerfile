FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Customer.API/Customer.API.csproj", "Customer.API/"]
COPY ["JWTAuth/JWTAuth.csproj", "JWTAuth/"]
COPY ["Customer.Infrustructure/Customer.Infrustructure.csproj", "Customer.Infrustructure/"]
COPY ["Customer.ApplicationCore/Customer.ApplicationCore.csproj", "Customer.ApplicationCore/"]
RUN dotnet restore "Customer.API/Customer.API.csproj"
COPY . .
WORKDIR "/src/Customer.API"
RUN dotnet build "Customer.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Customer.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Customer.API.dll"]
