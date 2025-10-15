# API Reference

## Base URL

```
https://api.example.com/v1
```

## Authentication

All API requests require a JWT token in the Authorization header:

```
Authorization: Bearer <token>
```

## Endpoints

### User Management

#### GET /users

List all users with pagination.

**Query Parameters:**
- `page` (integer): Page number (default: 1)
- `limit` (integer): Items per page (default: 20, max: 100)
- `search` (string): Search term for username or email

**Response:**
```json
{
  "data": [
    {
      "id": "uuid",
      "username": "johndoe",
      "email": "john@example.com",
      "createdAt": "2025-01-01T00:00:00Z"
    }
  ],
  "pagination": {
    "page": 1,
    "limit": 20,
    "total": 150,
    "pages": 8
  }
}
```

#### GET /users/:id

Get user by ID.

**Response:**
```json
{
  "id": "uuid",
  "username": "johndoe",
  "email": "john@example.com",
  "profile": {
    "firstName": "John",
    "lastName": "Doe",
    "avatar": "https://..."
  },
  "createdAt": "2025-01-01T00:00:00Z",
  "updatedAt": "2025-01-15T10:30:00Z"
}
```

#### POST /users

Create a new user.

**Request Body:**
```json
{
  "username": "johndoe",
  "email": "john@example.com",
  "password": "SecurePass123!"
}
```

**Response:** `201 Created`

#### PUT /users/:id

Update user information.

**Request Body:**
```json
{
  "email": "newemail@example.com",
  "profile": {
    "firstName": "John",
    "lastName": "Doe"
  }
}
```

**Response:** `200 OK`

#### DELETE /users/:id

Delete a user.

**Response:** `204 No Content`

### Authentication

#### POST /auth/login

Authenticate user and get JWT token.

**Request Body:**
```json
{
  "email": "john@example.com",
  "password": "password123"
}
```

**Response:**
```json
{
  "token": "eyJhbGciOiJIUzI1NiIs...",
  "refreshToken": "refresh_token_here",
  "expiresIn": 3600,
  "user": {
    "id": "uuid",
    "username": "johndoe",
    "email": "john@example.com"
  }
}
```

#### POST /auth/refresh

Refresh access token using refresh token.

#### POST /auth/logout

Invalidate current session.

## Error Responses

```json
{
  "error": {
    "code": "VALIDATION_ERROR",
    "message": "Invalid email format",
    "details": [
      {
        "field": "email",
        "message": "Must be a valid email address"
      }
    ]
  }
}
```

## Rate Limiting

- 100 requests per minute per IP
- Headers returned:
  - `X-RateLimit-Limit`: 100
  - `X-RateLimit-Remaining`: 95
  - `X-RateLimit-Reset`: 1234567890
