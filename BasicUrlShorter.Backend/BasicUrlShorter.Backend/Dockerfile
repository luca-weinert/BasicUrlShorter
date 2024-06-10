# Use the official ASP.NET Core runtime as a parent image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

# Use the SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["BasicUrlShorter.Backend.csproj", "./"]
RUN dotnet restore "./BasicUrlShorter.Backend.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "BasicUrlShorter.Backend.csproj" -c Release -o /app/build

# Publish the app
FROM build AS publish
RUN dotnet publish "BasicUrlShorter.Backend.csproj" -c Release -o /app/publish

# Copy the app to the runtime container
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BasicUrlShorter.Backend.dll"]
