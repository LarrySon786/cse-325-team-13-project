# -----------------------------
# Development Stage (fast updates)
# -----------------------------
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS dev

WORKDIR /src

# Copy only project file first for caching
COPY StudentPortal.csproj ./
RUN dotnet restore StudentPortal.csproj

# Copy everything else
COPY . .

ENV ASPNETCORE_URLS=http://0.0.0.0:8080
ENV DOTNET_USE_POLLING_FILE_WATCHER=true
ENV ASPNETCORE_ENVIRONMENT=Development

EXPOSE 8080

CMD ["dotnet", "watch", "run", "--urls", "http://0.0.0.0:8080"]

# -----------------------------
# Build Stage (production)
# -----------------------------
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /src

COPY StudentPortal.csproj ./
RUN dotnet restore StudentPortal.csproj

COPY . .

RUN dotnet publish StudentPortal.csproj -c Release -o /app/publish

# -----------------------------
# Runtime Stage (production)
# -----------------------------
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final

WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://0.0.0.0:8080
ENV DOTNET_RUNNING_IN_CONTAINER=true

EXPOSE 8080

ENTRYPOINT ["dotnet", "StudentPortal.dll"]






# Stage 1: Build with SDK
# FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
# WORKDIR /src

# # Copy csproj first and restore (better caching)
# COPY StudentPortal.csproj ./
# RUN dotnet restore StudentPortal.csproj

# # Copy everything else
# COPY . .

# # Publish the app to /app/publish
# RUN dotnet publish StudentPortal.csproj -c Release -o /app/publish

# # Stage 2: Runtime
# FROM mcr.microsoft.com/dotnet/aspnet:9.0
# WORKDIR /app

# # Copy the published app from the build stage
# COPY --from=build /app/publish ./

# # Make sure Kestrel listens on all interfaces
# ENV ASPNETCORE_URLS=http://0.0.0.0:8080
# ENV DOTNET_RUNNING_IN_CONTAINER=true

# EXPOSE 8080

# ENTRYPOINT ["dotnet", "StudentPortal.dll"]











# Stage 1: Build with SDK
# FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
# WORKDIR /src

# # Copy everything (Program.cs, .csproj, etc)
# COPY . .

# # Restore dependencies
# RUN dotnet restore

# # Publish the app to /app/publish
# RUN dotnet publish -c Release -o /app/publish

# # Stage 2: Runtime
# FROM mcr.microsoft.com/dotnet/aspnet:9.0
# WORKDIR /app

# # Copy the published app from the build stage
# COPY --from=build /app/publish ./

# # Make sure Kestrel listens on all interfaces
# ENV ASPNETCORE_URLS=http://0.0.0.0:8080
# ENV DOTNET_RUNNING_IN_CONTAINER=true

# EXPOSE 8080

# ENTRYPOINT ["dotnet", "StudentPortal.dll"]