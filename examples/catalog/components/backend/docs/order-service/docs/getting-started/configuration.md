# Configuration

## Environment Variables

### Required Variables

| Variable       | Description                  | Example                               |
| -------------- | ---------------------------- | ------------------------------------- |
| `DATABASE_URL` | PostgreSQL connection string | `postgresql://user:pass@host:5432/db` |
| `RABBITMQ_URL` | RabbitMQ connection URL      | `amqp://localhost:5672`               |
| `REDIS_URL`    | Redis connection URL         | `redis://localhost:6379`              |
| `JWT_SECRET`   | JWT signing secret           | `your-secret-key-here`                |

### Optional Variables

| Variable        | Description             | Default       |
| --------------- | ----------------------- | ------------- |
| `PORT`          | Server port             | `3000`        |
| `NODE_ENV`      | Environment             | `development` |
| `LOG_LEVEL`     | Logging level           | `info`        |
| `RATE_LIMIT`    | Rate limit (req/min)    | `100`         |
| `ORDER_TIMEOUT` | Order timeout (seconds) | `300`         |

## Database Configuration

### Connection Pool

```typescript
{
  host: 'localhost',
  port: 5432,
  database: 'orders',
  user: 'postgres',
  password: 'password',
  max: 20,              // Max connections
  idleTimeoutMillis: 30000,
  connectionTimeoutMillis: 2000
}
```

### Migrations

```bash
# Create migration
npm run migration:create -- CreateOrdersTable

# Run migrations
npm run migration:run

# Revert migration
npm run migration:revert
```

## RabbitMQ Configuration

### Exchanges and Queues

```typescript
const config = {
  exchanges: [
    {
      name: 'orders',
      type: 'topic',
      durable: true,
    },
  ],
  queues: [
    {
      name: 'order.created',
      durable: true,
      arguments: {
        'x-message-ttl': 86400000, // 24 hours
      },
    },
    {
      name: 'order.completed',
      durable: true,
    },
  ],
};
```

### Routing Keys

- `order.created` - New order created
- `order.updated` - Order status updated
- `order.cancelled` - Order cancelled
- `order.completed` - Order completed

## Redis Configuration

### Cache Settings

```typescript
{
  host: 'localhost',
  port: 6379,
  db: 0,
  keyPrefix: 'order:',
  ttl: 3600,  // 1 hour
  maxRetriesPerRequest: 3
}
```

### Cached Data

- User cart data (TTL: 1 hour)
- Product inventory (TTL: 5 minutes)
- Order calculations (TTL: 15 minutes)

## Payment Gateway Configuration

### Iyzico Configuration

```typescript
{
  apiKey: process.env.IYZICO_API_KEY,
  secretKey: process.env.IYZICO_SECRET_KEY,
  baseUrl: 'https://api.iyzipay.com',
  timeout: 30000
}
```

### PayTR Configuration

```typescript
{
  merchantId: process.env.PAYTR_MERCHANT_ID,
  merchantKey: process.env.PAYTR_MERCHANT_KEY,
  merchantSalt: process.env.PAYTR_MERCHANT_SALT
}
```

## Cargo Configuration

### Supported Cargo Companies

```typescript
const cargoProviders = {
  aras: {
    apiUrl: 'https://api.araskargo.com.tr',
    username: process.env.ARAS_USERNAME,
    password: process.env.ARAS_PASSWORD,
  },
  yurtici: {
    apiUrl: 'https://api.yurticikargo.com',
    customerId: process.env.YURTICI_CUSTOMER_ID,
    apiKey: process.env.YURTICI_API_KEY,
  },
  mng: {
    apiUrl: 'https://api.mngkargo.com.tr',
    username: process.env.MNG_USERNAME,
    password: process.env.MNG_PASSWORD,
  },
};
```

## Logging Configuration

### Log Levels

- `error` - Error messages only
- `warn` - Warnings and errors
- `info` - Info, warnings, and errors (default)
- `debug` - All logs including debug info
- `verbose` - Maximum verbosity

### Winston Configuration

```typescript
{
  level: process.env.LOG_LEVEL || 'info',
  format: winston.format.combine(
    winston.format.timestamp(),
    winston.format.json()
  ),
  transports: [
    new winston.transports.Console(),
    new winston.transports.File({
      filename: 'logs/error.log',
      level: 'error'
    }),
    new winston.transports.File({
      filename: 'logs/combined.log'
    })
  ]
}
```

## Feature Flags

```typescript
{
  enableGraphQL: true,
  enableWebhooks: true,
  enable3DSecure: true,
  enableAutoCargoSelection: true,
  enableInventoryReservation: true,
  enableOrderCancellation: true
}
```

## Performance Tuning

### NestJS Settings

```typescript
{
  cors: true,
  bodyLimit: '10mb',
  requestTimeout: 30000,
  compression: true,
  helmet: true
}
```

### Rate Limiting

```typescript
{
  ttl: 60,           // Time window (seconds)
  limit: 100,        // Max requests per window
  ignoreUserAgents: [/bot/i, /crawler/i]
}
```

## Monitoring Configuration

### Prometheus Metrics

```typescript
{
  enabled: true,
  path: '/metrics',
  defaultLabels: {
    service: 'order-service',
    env: process.env.NODE_ENV
  }
}
```

### Health Check

```typescript
{
  healthCheckPath: '/health',
  checkInterval: 5000,  // 5 seconds
  timeout: 3000
}
```
