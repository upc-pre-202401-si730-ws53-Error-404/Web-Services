# Utiliza la imagen base oficial de .NET 8.0 para construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia los archivos del proyecto y restaura las dependencias
COPY ["ChaquitacllaError404.API/ChaquitacllaError404.API.csproj", "ChaquitacllaError404.API/"]
RUN dotnet restore "ChaquitacllaError404.API/ChaquitacllaError404.API.csproj"

# Copia el resto de los archivos y construye el proyecto
COPY . .
WORKDIR "/src/ChaquitacllaError404.API"
RUN dotnet build "ChaquitacllaError404.API.csproj" -c Release -o /app/build

# Publica el proyecto
RUN dotnet publish "ChaquitacllaError404.API.csproj" -c Release -o /app/publish

# Utiliza una imagen runtime de .NET 8.0 para ejecutar la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ChaquitacllaError404.API.dll"]
