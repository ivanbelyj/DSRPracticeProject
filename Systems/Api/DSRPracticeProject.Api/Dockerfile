#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Systems/Api/DSRPracticeProject.Api/DSRPracticeProject.Api.csproj", "Systems/Api/DSRPracticeProject.Api/"]
COPY ["Services/DSRPracticeProject.Services.Settings/DSRPracticeProject.Services.Settings.csproj", "Services/DSRPracticeProject.Services.Settings/"]
COPY ["Shared/DSRPracticeProject.Settings/DSRPracticeProject.Settings.csproj", "Shared/DSRPracticeProject.Settings/"]
COPY ["Shared/DSRPracticeProject.Common/DSRPracticeProject.Common.csproj", "Shared/DSRPracticeProject.Common/"]
COPY ["Systems/Api/DSRPracticeProject.Api.Settings/DSRPracticeProject.Api.Settings.csproj", "Systems/Api/DSRPracticeProject.Api.Settings/"]
RUN dotnet restore "Systems/Api/DSRPracticeProject.Api/DSRPracticeProject.Api.csproj"
COPY . .
WORKDIR "/src/Systems/Api/DSRPracticeProject.Api"
RUN dotnet build "DSRPracticeProject.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DSRPracticeProject.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DSRPracticeProject.Api.dll"]