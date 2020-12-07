#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["./Presentation/GameStore.WebApp.MVC/GameStore.WebApp.MVC.csproj", "Presentation/GameStore.WebApp.MVC/"]
COPY ["./Services/GameStore.API/GameStore.API.csproj", "Services/GameStore.API/"]
COPY ["./Infra/GameStore.Data/GameStore.Data.csproj", "Infra/GameStore.Data/"]
COPY ["./Domain/GameStore.Domain/GameStore.Domain.csproj", "Domain/GameStore.Domain/"]
RUN dotnet restore "Presentation/GameStore.WebApp.MVC/GameStore.WebApp.MVC.csproj"
COPY . .
WORKDIR "Presentation/GameStore.WebApp.MVC"
RUN dotnet build "GameStore.WebApp.MVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GameStore.WebApp.MVC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GameStore.WebApp.MVC.dll"]