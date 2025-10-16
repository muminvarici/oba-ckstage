{%- if values.enableDocker %}
# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY ["${{ values.name }}.csproj", "./"]
RUN dotnet restore "${{ values.name }}.csproj"

# Copy everything else and build
COPY . .
RUN dotnet build "${{ values.name }}.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "${{ values.name }}.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 80
EXPOSE 443

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "${{ values.name }}.dll"]
{%- endif %}
