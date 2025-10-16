# API Overview

## Base URL

```
https://api.example.com/payment/v1
```

## Request Format

All requests must include:

```http
POST /payments
Content-Type: application/json
Authorization: Bearer YOUR_API_KEY
X-Request-ID: unique-request-id
```

## Response Format

### Success Response

```json
{
  "success": true,
  "data": {
    "id": "pay_1234567890",
    "status": "succeeded",
    "amount": 100.0,
    "currency": "TRY"
  },
  "meta": {
    "requestId": "req_abc123",
    "timestamp": "2025-10-16T10:30:00Z"
  }
}
```

### Error Response

```json
{
  "success": false,
  "error": {
    "code": "invalid_card",
    "message": "The card number is invalid",
    "details": {
      "field": "cardNumber",
      "reason": "Invalid format"
    }
  },
  "meta": {
    "requestId": "req_abc123",
    "timestamp": "2025-10-16T10:30:00Z"
  }
}
```

## Rate Limiting

| Tier     | Rate Limit   | Burst |
| -------- | ------------ | ----- |
| Free     | 10 req/min   | 20    |
| Standard | 100 req/min  | 200   |
| Premium  | 1000 req/min | 2000  |

Rate limit headers:

```http
X-RateLimit-Limit: 100
X-RateLimit-Remaining: 95
X-RateLimit-Reset: 1697456789
```

## Idempotency

Use `X-Idempotency-Key` header to ensure safe retries:

```http
X-Idempotency-Key: unique-key-12345
```

Keys expire after 24 hours.

## Versioning

API version is included in URL:

```
/v1/payments  ← Current
/v2/payments  ← Beta (available for testing)
```

## Pagination

For list endpoints:

```http
GET /payments?page=1&limit=20&sort=createdAt:desc
```

Response includes pagination metadata:

```json
{
  "data": [...],
  "pagination": {
    "page": 1,
    "limit": 20,
    "total": 150,
    "pages": 8,
    "hasNext": true,
    "hasPrev": false
  }
}
```

## Filtering

```http
GET /payments?status=succeeded&minAmount=100&maxAmount=1000
GET /payments?createdAfter=2025-10-01&createdBefore=2025-10-31
```

## Sorting

```http
GET /payments?sort=amount:asc
GET /payments?sort=createdAt:desc,amount:asc
```

## Field Selection

Request specific fields only:

```http
GET /payments?fields=id,status,amount
```

## Expansion

Expand related resources:

```http
GET /payments/{id}?expand=customer,order
```

## Testing

Test mode using sandbox API key:

```
Sandbox: https://api-sandbox.example.com/payment/v1
```

### Test Cards

| Card Number      | Result             | 3D Secure |
| ---------------- | ------------------ | --------- |
| 4242424242424242 | Success            | No        |
| 5555555555554444 | Success            | Yes       |
| 4000000000000002 | Declined           | No        |
| 4000000000000341 | Insufficient funds | No        |
| 4000000000009995 | Timeout            | No        |

## SDKs

### Node.js

```bash
npm install @example/payment-sdk
```

```javascript
const Payment = require('@example/payment-sdk');
const client = new Payment('your_api_key');

const payment = await client.payments.create({
  amount: 100.0,
  currency: 'TRY',
  cardNumber: '4242424242424242',
});
```

### PHP

```bash
composer require example/payment-sdk
```

```php
use Example\Payment\PaymentClient;

$client = new PaymentClient('your_api_key');
$payment = $client->payments->create([
    'amount' => 100.00,
    'currency' => 'TRY',
    'cardNumber' => '4242424242424242'
]);
```

## Webhooks

Subscribe to events:

```http
POST /webhooks
{
  "url": "https://yoursite.com/webhook",
  "events": ["payment.succeeded", "payment.failed"]
}
```

See [Webhooks](webhooks.md) for details.
