#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 4040
EXPOSE 4041

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Gestion-Notes.api/Gestion-Notes.api.csproj", "Gestion-Notes.api/"]
RUN dotnet restore "./Gestion-Notes.api/Gestion-Notes.api.csproj"
COPY . .
WORKDIR "/src/Gestion-Notes.api"
RUN dotnet build "./Gestion-Notes.api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Gestion-Notes.api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gestion-Notes.api.dll"]