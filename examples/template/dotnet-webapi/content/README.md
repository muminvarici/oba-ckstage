# ${{ values.name }}

${{ values.description }}

## Overview

This project was created using the Backstage .NET Web API Template.

## Prerequisites

- .NET SDK ${{ values.dotnetVersion }}
- Visual Studio 2022 / VS Code / Rider

## Getting Started

### Running Locally

```bash
# Restore dependencies
dotnet restore

# Build the project
dotnet build

# Run the application
dotnet run
```

The API will be available at:
- HTTP: `http://localhost:5000`
- HTTPS: `https://localhost:5001`

{%- if values.enableSwagger %}

### API Documentation

Swagger UI is available at: `https://localhost:5001/swagger`

{%- endif %}

{%- if values.enableHealthChecks %}

### Health Checks

- Health: `https://localhost:5001/health`
- Readiness: `https://localhost:5001/health/ready`
- Liveness: `https://localhost:5001/health/live`

{%- endif %}

{%- if values.enableDocker %}

### Running with Docker

```bash
# Build the Docker image
docker build -t ${{ values.name | lower }} .

# Run the container
docker run -p 5000:80 -p 5001:443 ${{ values.name | lower }}
```

Or use docker-compose:

```bash
docker-compose up
```

{%- endif %}

## Project Structure

```
${{ values.name }}/
├── Controllers/          # API Controllers
├── Program.cs           # Application entry point
├── appsettings.json     # Configuration
{%- if values.enableDocker %}
├── Dockerfile           # Docker configuration
├── docker-compose.yml   # Docker Compose configuration
{%- endif %}
└── catalog-info.yaml    # Backstage catalog metadata
```

## Development

### Building

```bash
dotnet build
```

### Testing

```bash
dotnet test
```

### Publishing

```bash
dotnet publish -c Release -o ./publish
```

## Deployment

This service is configured for deployment with:
- GitHub Actions CI/CD
- Docker containerization
- Kubernetes/ArgoCD deployment

## Contributing

Please read [CONTRIBUTING.md](CONTRIBUTING.md) for details on our code of conduct and the process for submitting pull requests.

## License

Copyright © 2025 ${{ values.orgName }}

## Support

For issues and questions, please create an issue in the GitHub repository.

---

**Owner:** ${{ values.owner }}
