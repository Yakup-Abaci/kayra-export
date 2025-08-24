#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Presentation/KayraExportAPI/KayraExportAPI.csproj", "Presentation/KayraExportAPI/"]
COPY ["Core/Application/Application.csproj", "Core/Application/"]
COPY ["Core/Domain/Domain.csproj", "Core/Domain/"]
COPY ["Infrastructure/Infrastructure/Infrastructure.csproj", "Infrastructure/Infrastructure/"]
COPY ["Infrastructure/Persistence/Persistence.csproj", "Infrastructure/Persistence/"]
RUN dotnet restore "Presentation/KayraExportAPI/KayraExportAPI.csproj"
COPY . .
WORKDIR "/src/Presentation/KayraExportAPI"
RUN dotnet build "KayraExportAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KayraExportAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KayraExportAPI.dll"]