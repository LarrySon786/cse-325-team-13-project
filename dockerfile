# Stage 1: Build with SDK
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy everything (Program.cs, .csproj, etc)
COPY . .

# Restore dependencies
RUN dotnet restore

# Publish the app to /app/publish
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

# Copy the published app from the build stage
COPY --from=build /app/publish ./

# Make sure Kestrel listens on all interfaces
ENV ASPNETCORE_URLS=http://0.0.0.0:8080
ENV DOTNET_RUNNING_IN_CONTAINER=true

EXPOSE 8080

ENTRYPOINT ["dotnet", "cse-325-team-13-project.dll"]