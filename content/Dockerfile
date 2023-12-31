FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /app

# Copy everything else and build
COPY ["API", "API"]
COPY ["Domain", "Domain"]
COPY ["Infrastructure", "Infrastructure"]
RUN dotnet publish "API/API.csproj" -c Release -o /app/out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine
WORKDIR /app
COPY --from=build /app/out .

# create a new user and change directory ownership
RUN adduser --disabled-password \
  --home /app \
  --gecos '' dotnetuser && chown -R dotnetuser /app

# impersonate into the new user
USER dotnetuser

EXPOSE 8080

ENTRYPOINT ["dotnet", "API.dll"]
