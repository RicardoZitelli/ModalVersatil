#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 81
EXPOSE 444

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ModaVesatilInfrastructure/ModaVesatilInfrastructure.csproj","ModaVesatilInfrastructure/"]
COPY ["ModaVersatilIoC/ModaVersatilIoC.csproj","ModaVersatilIoC/"]
COPY ["ModaVersatilDomain/ModaVersatilDomain.csproj","ModaVersatilDomain/"]
COPY ["ModaVersatilApplication/ModaVersatilApplication.csproj","ModaVersatilApplication/"]
COPY ["ModaVersatil/ModaVersatil.csproj", "ModaVersatil/"]
RUN dotnet restore "ModaVersatil/ModaVersatil.csproj"
COPY . .
WORKDIR "/src/ModaVersatil"
RUN dotnet build "ModaVersatil.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ModaVersatil.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ModaVersatil.dll"]