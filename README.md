# [Backstage](https://backstage.io)

This is your newly scaffolded Backstage App, Good Luck!

## 🚀 Quick Start

### 1. Start PostgreSQL Database

```powershell
# Start PostgreSQL using Docker Compose
docker-compose -f docker-compose.postgres.yml up -d

# Verify it's running
docker ps
```

### 2. Install Dependencies and Start Backstage

```powershell
# Install dependencies
yarn install

# Start Backstage (frontend & backend)
yarn dev
```

The app will be available at:

- **Frontend**: http://localhost:3000
- **Backend**: http://localhost:7007

## 📦 Database

This project uses **PostgreSQL** for persistent data storage. All catalog data, user information, and configurations are stored in the database.

For detailed database management instructions, see [DATABASE.md](./DATABASE.md).

### Database Configuration

Connection settings are defined in `.env`:

```properties
POSTGRES_HOST=localhost
POSTGRES_PORT=5432
POSTGRES_USER=backstage
POSTGRES_PASSWORD=backstage
```
