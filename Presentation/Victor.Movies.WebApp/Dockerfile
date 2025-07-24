#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Presentation/Victor.Movies.WebApp/Victor.Movies.WebApp.csproj", "Presentation/Victor.Movies.WebApp/"]
COPY ["Infra/Victor.Movies.DataAccess/Victor.Movies.DataAccess.csproj", "Infra/Victor.Movies.DataAccess/"]
COPY ["IOC/Victor.Movies.IOC/Victor.Movies.IOC.csproj", "IOC/Victor.Movies.IOC/"]
COPY ["Business/Victor.Movies.Business/Victor.Movies.Business.csproj", "Business/Victor.Movies.Business/"]
RUN dotnet restore "./Presentation/Victor.Movies.WebApp/Victor.Movies.WebApp.csproj"
COPY . .
WORKDIR "/src/Presentation/Victor.Movies.WebApp"
RUN dotnet build "./Victor.Movies.WebApp.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Victor.Movies.WebApp.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Victor.Movies.WebApp.dll"]