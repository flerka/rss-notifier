FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["SubscriptionService/SubscriptionService.csproj", "SubscriptionService/"]
COPY ["SubscriptionService.Api/SubscriptionService.Api.csproj", "SubscriptionService.Api/"]
RUN dotnet restore "SubscriptionService/SubscriptionService.csproj"
COPY . .
WORKDIR "/src/SubscriptionService"
RUN dotnet build "SubscriptionService.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "SubscriptionService.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SubscriptionService.dll"]