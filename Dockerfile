#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Univan.Api/Univan.Api.csproj", "Univan.Api/"]
COPY ["Univan.Application/Univan.Application.csproj", "Univan.Application/"]
COPY ["Univan.Domain/Univan.Domain.csproj", "Univan.Domain/"]
COPY ["Univan.Infrastructure/Univan.Infrastructure.csproj", "Univan.Infrastructure/"]
COPY ./nuget.config .
RUN dotnet restore "Univan.Api/Univan.Api.csproj"
COPY . .
WORKDIR "/src/Univan.Api"
RUN dotnet build "Univan.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Univan.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Univan.Api.dll"]