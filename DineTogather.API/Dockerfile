FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DineTogather.API/DineTogather.API.csproj", "DineTogather.API/"]
RUN dotnet restore "DineTogather.API/DineTogather.API.csproj"
COPY . .
WORKDIR "/src/DineTogather.API"
RUN dotnet build "DineTogather.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DineTogather.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DineTogather.API.dll"]