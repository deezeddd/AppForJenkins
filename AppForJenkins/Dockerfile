#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS=http://+:5194

# Expose ports
EXPOSE 80
EXPOSE 5194

# Create directories for volumes
RUN mkdir -p /root/.microsoft/usersecrets /root/.aspnet/https

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AppForJenkins/AppForJenkins.csproj", "."]
RUN dotnet restore "./AppForJenkins.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./AppForJenkins.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./AppForJenkins.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .


ENTRYPOINT ["dotnet", "AppForJenkins.dll"]