FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.csproj ./UserService/
WORKDIR /app/UserService
RUN dotnet restore

# copy and publish app and libraries
WORKDIR /app/
COPY . ./UserService/
WORKDIR /app/UserService
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS runtime
WORKDIR /app
COPY --from=build /app/UserService/out ./
ENTRYPOINT ["dotnet", "UserService.dll"]