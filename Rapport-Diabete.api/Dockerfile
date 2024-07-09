#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 3030
EXPOSE 3031

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Rapport-Diabete.api/Rapport-Diabete.api.csproj", "Rapport-Diabete.api/"]
RUN dotnet restore "./Rapport-Diabete.api/Rapport-Diabete.api.csproj"
COPY . .
WORKDIR "/src/Rapport-Diabete.api"
RUN dotnet build "./Rapport-Diabete.api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Rapport-Diabete.api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Rapport-Diabete.api.dll"]