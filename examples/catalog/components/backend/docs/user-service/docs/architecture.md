# Architecture

## System Design

The User Service follows a layered architecture pattern:

```
┌─────────────────┐
│   API Layer     │ ← REST API endpoints
├─────────────────┤
│ Business Logic  │ ← Service layer
├─────────────────┤
│  Data Access    │ ← Repository pattern
├─────────────────┤
│    Database     │ ← PostgreSQL
└─────────────────┘
```

## Components

### API Layer
- Express.js router
- Request validation (Joi)
- Authentication middleware (JWT)
- Rate limiting

### Business Logic
- User service
- Authentication service
- Authorization service
- Validation rules

### Data Access
- User repository
- Session repository
- Cache layer (Redis)

## Database Schema

```sql
CREATE TABLE users (
    id UUID PRIMARY KEY,
    username VARCHAR(50) UNIQUE NOT NULL,
    email VARCHAR(255) UNIQUE NOT NULL,
    password_hash VARCHAR(255) NOT NULL,
    created_at TIMESTAMP DEFAULT NOW(),
    updated_at TIMESTAMP DEFAULT NOW()
);

CREATE INDEX idx_users_email ON users(email);
CREATE INDEX idx_users_username ON users(username);
```

## Security

- Passwords hashed with bcrypt (cost factor: 12)
- JWT tokens with 1-hour expiration
- Refresh tokens stored in Redis
- Rate limiting: 100 requests/minute per IP

## Performance

- Response time: <100ms (95th percentile)
- Cache hit ratio: >80%
- Database connection pool: 20 connections
