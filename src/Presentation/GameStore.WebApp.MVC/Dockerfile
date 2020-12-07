#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Presentation/GameStore.WebApp.MVC/GameStore.WebApp.MVC.csproj", "src/Presentation/GameStore.WebApp.MVC/"]
COPY ["src/services/GameStore.API/GameStore.API.csproj", "src/services/GameStore.API/"]
COPY ["src/Infra/GameStore.Data/GameStore.Data.csproj", "src/Infra/GameStore.Data/"]
COPY ["src/Domain/GameStore.Domain/GameStore.Domain.csproj", "src/Domain/GameStore.Domain/"]
RUN dotnet restore "src/Presentation/GameStore.WebApp.MVC/GameStore.WebApp.MVC.csproj"
COPY . .
WORKDIR "/src/src/Presentation/GameStore.WebApp.MVC"
RUN dotnet build "GameStore.WebApp.MVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GameStore.WebApp.MVC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GameStore.WebApp.MVC.dll"]