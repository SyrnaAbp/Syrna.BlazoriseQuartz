#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["host/Syrna.BlazoriseQuartz.Web.Unified/Syrna.BlazoriseQuartz.Web.Unified.csproj", "host/Syrna.BlazoriseQuartz.Web.Unified/"]
COPY ["src/Syrna.BlazoriseQuartz.Web/Syrna.BlazoriseQuartz.Web.csproj", "src/Syrna.BlazoriseQuartz.Web/"]
COPY ["src/Syrna.BlazoriseQuartz.HttpApi/Syrna.BlazoriseQuartz.HttpApi.csproj", "src/Syrna.BlazoriseQuartz.HttpApi/"]
COPY ["src/Syrna.BlazoriseQuartz.Application.Contracts/Syrna.BlazoriseQuartz.Application.Contracts.csproj", "src/Syrna.BlazoriseQuartz.Application.Contracts/"]
COPY ["src/Syrna.BlazoriseQuartz.Domain.Shared/Syrna.BlazoriseQuartz.Domain.Shared.csproj", "src/Syrna.BlazoriseQuartz.Domain.Shared/"]
COPY ["src/Syrna.BlazoriseQuartz.Application/Syrna.BlazoriseQuartz.Application.csproj", "src/Syrna.BlazoriseQuartz.Application/"]
COPY ["src/Syrna.BlazoriseQuartz.Domain/Syrna.BlazoriseQuartz.Domain.csproj", "src/Syrna.BlazoriseQuartz.Domain/"]
COPY ["src/Syrna.BlazoriseQuartz.EntityFrameworkCore/Syrna.BlazoriseQuartz.EntityFrameworkCore.csproj", "src/Syrna.BlazoriseQuartz.EntityFrameworkCore/"]
COPY ["host/Syrna.BlazoriseQuartz.Host.Shared/Syrna.BlazoriseQuartz.Host.Shared.csproj", "host/Syrna.BlazoriseQuartz.Host.Shared/"]
COPY Directory.Build.props .
RUN dotnet restore "host/Syrna.BlazoriseQuartz.Web.Unified/Syrna.BlazoriseQuartz.Web.Unified.csproj"
COPY . .
WORKDIR "/src/host/Syrna.BlazoriseQuartz.Web.Unified"
RUN dotnet build "Syrna.BlazoriseQuartz.Web.Unified.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Syrna.BlazoriseQuartz.Web.Unified.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Syrna.BlazoriseQuartz.Web.Unified.dll"]