FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["FrenetOrderSolution/FrenetOrder/FrenetOrder.csproj", "FrenetOrderSolution/FrenetOrder/"]
RUN dotnet restore "./FrenetOrderSolution/FrenetOrder/FrenetOrder.csproj"
COPY . .
WORKDIR "/src/FrenetOrderSolution/FrenetOrder"
RUN dotnet build "./FrenetOrder.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./FrenetOrder.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FrenetOrder.dll"]