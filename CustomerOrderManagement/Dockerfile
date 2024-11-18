# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CustomerOrderManagement/CustomerOrderManagement.csproj", "CustomerOrderManagement/"]
COPY ["CustomerOrderManagement.Configurations/CustomerOrderManagement.Configurations.csproj", "CustomerOrderManagement.Configurations/"]
COPY ["CustomerOrderManagement.Models/CustomerOrderManagement.Models.csproj", "CustomerOrderManagement.Models/"]
COPY ["CustomerOrderManagement.Repository.Abstraction/CustomerOrderManagement.Repository.Abstractions.csproj", "CustomerOrderManagement.Repository.Abstraction/"]
COPY ["CustomerOrderManagement.Repository/CustomerOrderManagement.Repository.csproj", "CustomerOrderManagement.Repository/"]
COPY ["CustomerOrderManagement.Service.Abstractions/CustomerOrderManagement.Service.Abstractions.csproj", "CustomerOrderManagement.Service.Abstractions/"]
COPY ["CustomerOrderManagement.Service/CustomerOrderManagement.Service.csproj", "CustomerOrderManagement.Service/"]
RUN dotnet restore "./CustomerOrderManagement/CustomerOrderManagement.csproj"
COPY . .
WORKDIR "/src/CustomerOrderManagement"
RUN dotnet build "./CustomerOrderManagement.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CustomerOrderManagement.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CustomerOrderManagement.dll"]