# Development Guide

## Prerequisites

- Node.js v18 or higher
- PostgreSQL 14+
- Redis 7+
- Docker (optional)

## Setup

### 1. Clone and Install

```bash
git clone https://github.com/example-org/user-service
cd user-service
npm install
```

### 2. Environment Configuration

Create a `.env` file:

```bash
# Database
DATABASE_URL=postgresql://user:password@localhost:5432/userdb

# Redis
REDIS_URL=redis://localhost:6379

# JWT
JWT_SECRET=your-secret-key-here
JWT_EXPIRATION=1h

# Server
PORT=3000
NODE_ENV=development
```

### 3. Database Setup

```bash
# Run migrations
npm run migrate

# Seed database (optional)
npm run seed
```

### 4. Start Development Server

```bash
npm run dev
```

Server will start at `http://localhost:3000`

## Project Structure

```
user-service/
├── src/
│   ├── controllers/     # Request handlers
│   ├── services/        # Business logic
│   ├── repositories/    # Data access
│   ├── middlewares/     # Express middlewares
│   ├── models/          # Data models
│   ├── utils/           # Utility functions
│   └── index.ts         # Entry point
├── tests/
│   ├── unit/           # Unit tests
│   ├── integration/    # Integration tests
│   └── e2e/            # End-to-end tests
├── migrations/         # Database migrations
└── docs/              # Documentation
```

## Testing

### Unit Tests

```bash
npm test
```

### Integration Tests

```bash
npm run test:integration
```

### E2E Tests

```bash
npm run test:e2e
```

### Coverage

```bash
npm run test:coverage
```

## Code Quality

### Linting

```bash
npm run lint
```

### Formatting

```bash
npm run format
```

### Type Checking

```bash
npm run type-check
```

## Debugging

### VS Code

`.vscode/launch.json`:

```json
{
  "version": "0.2.0",
  "configurations": [
    {
      "type": "node",
      "request": "launch",
      "name": "Debug",
      "skipFiles": ["<node_internals>/**"],
      "program": "${workspaceFolder}/src/index.ts",
      "preLaunchTask": "tsc: build - tsconfig.json",
      "outFiles": ["${workspaceFolder}/dist/**/*.js"]
    }
  ]
}
```

## Common Tasks

### Adding a New Endpoint

1. Create controller in `src/controllers/`
2. Add route in `src/routes/`
3. Implement service logic in `src/services/`
4. Add tests in `tests/`

### Database Migration

```bash
# Create migration
npm run migration:create -- AddUserProfile

# Run migrations
npm run migrate

# Rollback
npm run migrate:rollback
```

## Troubleshooting

### Port Already in Use

```bash
# Kill process on port 3000
npx kill-port 3000
```

### Database Connection Issues

Check PostgreSQL is running:
```bash
pg_isready
```

### Redis Connection Issues

Check Redis is running:
```bash
redis-cli ping
```
