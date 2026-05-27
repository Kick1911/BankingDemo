FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies (optimises Docker caching)
COPY csharp.csproj ./
RUN dotnet restore "csharp.csproj"

# Copy everything else and build the release
COPY . .
RUN dotnet publish "-c" "Release" "-o" "/app/publish" --no-restore /p:UseAppHost=false

# Stage 2: Run the application using the lightweight runtime image
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app


COPY --from=build --chown=app:app /app/publish .
USER app

EXPOSE 8080
ENTRYPOINT ["dotnet", "/app/csharp.dll"]
