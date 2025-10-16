# Quick Start Guide

## Ön Gereksinimler

- Node.js v18 veya üzeri
- PostgreSQL 14+
- RabbitMQ 3.11+
- Redis 7+
- Docker (opsiyonel)

## Kurulum Adımları

### 1. Repository'yi Klonla

```bash
git clone https://github.com/example-org/order-service.git
cd order-service
```

### 2. Bağımlılıkları Yükle

```bash
npm install
```

### 3. Environment Değişkenlerini Ayarla

`.env` dosyası oluştur:

```bash
# Database
DATABASE_URL=postgresql://user:password@localhost:5432/orders

# RabbitMQ
RABBITMQ_URL=amqp://localhost:5672

# Redis
REDIS_URL=redis://localhost:6379

# Payment Service
PAYMENT_SERVICE_URL=http://localhost:3001

# JWT
JWT_SECRET=your-secret-key
```

### 4. Database Migration

```bash
npm run migration:run
```

### 5. Seed Data (Opsiyonel)

```bash
npm run seed
```

### 6. Servisi Başlat

```bash
# Development mode
npm run dev

# Production mode
npm run build
npm start
```

## Docker ile Kurulum

```bash
# Docker Compose ile tüm servisleri başlat
docker-compose up -d

# Logları izle
docker-compose logs -f order-service
```

## İlk Sipariş Oluşturma

### REST API

```bash
curl -X POST http://localhost:3000/api/v1/orders \
  -H "Content-Type: application/json" \
  -H "Authorization: Bearer YOUR_TOKEN" \
  -d '{
    "userId": "user-123",
    "items": [
      {
        "productId": "prod-456",
        "quantity": 2,
        "price": 29.99
      }
    ],
    "shippingAddress": {
      "street": "123 Main St",
      "city": "Istanbul",
      "zipCode": "34000"
    }
  }'
```

### GraphQL

```graphql
mutation CreateOrder {
  createOrder(
    input: {
      userId: "user-123"
      items: [{ productId: "prod-456", quantity: 2, price: 29.99 }]
      shippingAddress: {
        street: "123 Main St"
        city: "Istanbul"
        zipCode: "34000"
      }
    }
  ) {
    id
    status
    total
    createdAt
  }
}
```

## Servis Kontrolü

### Health Check

```bash
curl http://localhost:3000/health
```

**Response:**

```json
{
  "status": "ok",
  "info": {
    "database": { "status": "up" },
    "redis": { "status": "up" },
    "rabbitmq": { "status": "up" }
  }
}
```

### Metrics

```bash
curl http://localhost:3000/metrics
```

## Test Çalıştırma

```bash
# Unit tests
npm test

# E2E tests
npm run test:e2e

# Coverage
npm run test:cov
```

## Troubleshooting

### Database Bağlantı Hatası

```bash
# PostgreSQL'in çalıştığını kontrol et
psql -U postgres -c "SELECT version();"
```

### RabbitMQ Bağlantı Hatası

```bash
# RabbitMQ durumunu kontrol et
rabbitmqctl status
```

### Port Çakışması

```bash
# Port 3000'i kullanan process'i bul
netstat -ano | findstr :3000

# Process'i sonlandır
taskkill /PID <PID> /F
```

## Sonraki Adımlar

- [Configuration](configuration.md) - Detaylı yapılandırma
- [API Documentation](../api/rest.md) - API referansı
- [Order Processing](../features/order-processing.md) - Sipariş akışları
