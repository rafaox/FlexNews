#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Piagro.DataAccessLayer/Piagro.DataAccessLayer.csproj", "Piagro.DataAccessLayer/"]
COPY ["Piagro.Services/Piagro.Services.csproj", "Piagro.Services/"]
COPY ["Piagro.Api/Piagro.Api.csproj", "piagro-adm/"]
RUN dotnet restore "Piagro.Api/Piagro.Api.csproj"
COPY . .
WORKDIR "/src/piagro-adm"
RUN dotnet build "Piagro.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Piagro.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Piagro.Api.dll"]