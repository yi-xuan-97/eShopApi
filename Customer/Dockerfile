﻿FROM mcr.microsoft.com/dotnet/aspnet:6.0-bullseye-slim-amd64 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
#ENV eShopDb="Server=10.0.0.29,1433; Database=eShopApiDb; User=SA; Password=NewStrongPassword456; TrustServerCertificate=True;"
ENV eShopDb="Server=tcp:yfeng.database.windows.net,1433;Initial Catalog=eShopDb;Persist Security Info=False;User ID=yfeng;Password=NewStrongPassword456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
ENV angularURL="https://localhost:4200"
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
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
RUN dotnet publish "Customer.csproj" -c $BUILD_CONFIGURATION -o /app/publish -r linux-x64 --self-contained false /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Customer.dll"]
