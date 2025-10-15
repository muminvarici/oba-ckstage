# API Endpoints

## Create Payment

```http
POST /payments
```

Create a new payment transaction.

**Request:**

```json
{
  "amount": 100.0,
  "currency": "TRY",
  "orderId": "order_123",
  "customerId": "cust_456",
  "card": {
    "number": "4242424242424242",
    "expMonth": 12,
    "expYear": 2025,
    "cvc": "123",
    "holderName": "AHMET YILMAZ"
  },
  "billingAddress": {
    "street": "Atatürk Cad. No:123",
    "city": "Istanbul",
    "zipCode": "34000",
    "country": "TR"
  },
  "metadata": {
    "orderNumber": "ORD-2025-1234"
  }
}
```

**Response:**

```json
{
  "success": true,
  "data": {
    "id": "pay_1234567890",
    "status": "succeeded",
    "amount": 100.0,
    "currency": "TRY",
    "orderId": "order_123",
    "customerId": "cust_456",
    "threeDSecure": false,
    "createdAt": "2025-10-16T10:30:00Z"
  }
}
```

## Get Payment

```http
GET /payments/{id}
```

Retrieve payment details.

**Response:**

```json
{
  "success": true,
  "data": {
    "id": "pay_1234567890",
    "status": "succeeded",
    "amount": 100.0,
    "currency": "TRY",
    "orderId": "order_123",
    "customerId": "cust_456",
    "card": {
      "brand": "visa",
      "last4": "4242",
      "expMonth": 12,
      "expYear": 2025
    },
    "gateway": "iyzico",
    "gatewayTransactionId": "12345678",
    "createdAt": "2025-10-16T10:30:00Z",
    "updatedAt": "2025-10-16T10:30:05Z"
  }
}
```

## List Payments

```http
GET /payments
```

List all payments with filters.

**Query Parameters:**

| Parameter     | Type    | Description                            |
| ------------- | ------- | -------------------------------------- |
| page          | integer | Page number (default: 1)               |
| limit         | integer | Items per page (default: 20, max: 100) |
| status        | string  | Filter by status                       |
| customerId    | string  | Filter by customer                     |
| orderId       | string  | Filter by order                        |
| minAmount     | number  | Minimum amount                         |
| maxAmount     | number  | Maximum amount                         |
| createdAfter  | date    | Created after date                     |
| createdBefore | date    | Created before date                    |

**Example:**

```http
GET /payments?status=succeeded&minAmount=100&page=1&limit=20
```

**Response:**

```json
{
  "success": true,
  "data": [
    {
      "id": "pay_1234567890",
      "status": "succeeded",
      "amount": 100.0,
      "currency": "TRY",
      "createdAt": "2025-10-16T10:30:00Z"
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

## Refund Payment

```http
POST /payments/{id}/refunds
```

Refund a payment (full or partial).

**Request:**

```json
{
  "amount": 50.0,
  "reason": "customer_request",
  "metadata": {
    "ticketId": "TICKET-123"
  }
}
```

**Response:**

```json
{
  "success": true,
  "data": {
    "id": "ref_9876543210",
    "paymentId": "pay_1234567890",
    "amount": 50.0,
    "currency": "TRY",
    "status": "succeeded",
    "reason": "customer_request",
    "createdAt": "2025-10-16T11:00:00Z"
  }
}
```

## Capture Payment

```http
POST /payments/{id}/capture
```

Capture a previously authorized payment.

**Request:**

```json
{
  "amount": 100.0
}
```

**Response:**

```json
{
  "success": true,
  "data": {
    "id": "pay_1234567890",
    "status": "captured",
    "amount": 100.0,
    "capturedAt": "2025-10-16T11:30:00Z"
  }
}
```

## Cancel Payment

```http
POST /payments/{id}/cancel
```

Cancel an uncaptured authorization.

**Request:**

```json
{
  "reason": "order_cancelled"
}
```

**Response:**

```json
{
  "success": true,
  "data": {
    "id": "pay_1234567890",
    "status": "cancelled",
    "cancelledAt": "2025-10-16T12:00:00Z"
  }
}
```

## 3D Secure Payment

For 3D Secure payments, the flow is:

### 1. Initialize Payment

```http
POST /payments
```

With `threeDSecure: true`:

```json
{
  "amount": 100.00,
  "currency": "TRY",
  "threeDSecure": true,
  "card": { ... },
  "returnUrl": "https://yoursite.com/payment/callback"
}
```

### 2. Response with Redirect

```json
{
  "success": true,
  "data": {
    "id": "pay_1234567890",
    "status": "requires_action",
    "threeDSecure": {
      "required": true,
      "redirectUrl": "https://3dsecure.bank.com/auth?token=xyz"
    }
  }
}
```

### 3. Redirect User

Redirect user to `redirectUrl` for 3D Secure authentication.

### 4. Handle Callback

User returns to `returnUrl` with `paymentId` parameter:

```http
GET https://yoursite.com/payment/callback?paymentId=pay_1234567890
```

### 5. Confirm Payment

```http
GET /payments/{id}
```

Check final status:

```json
{
  "success": true,
  "data": {
    "id": "pay_1234567890",
    "status": "succeeded",
    "threeDSecure": {
      "authenticated": true,
      "transactionId": "3DS_12345"
    }
  }
}
```

## Installment Plans

```http
POST /payments/installments/calculate
```

Calculate installment options.

**Request:**

```json
{
  "amount": 1000.0,
  "currency": "TRY",
  "cardBin": "424242"
}
```

**Response:**

```json
{
  "success": true,
  "data": {
    "amount": 1000.0,
    "plans": [
      {
        "installments": 1,
        "totalAmount": 1000.0,
        "monthlyAmount": 1000.0,
        "interestRate": 0
      },
      {
        "installments": 3,
        "totalAmount": 1030.0,
        "monthlyAmount": 343.33,
        "interestRate": 3.0
      },
      {
        "installments": 6,
        "totalAmount": 1060.0,
        "monthlyAmount": 176.67,
        "interestRate": 6.0
      }
    ]
  }
}
```

## Payment Status

| Status               | Description                                   |
| -------------------- | --------------------------------------------- |
| `pending`            | Payment initiated                             |
| `requires_action`    | Requires 3D Secure or additional verification |
| `processing`         | Payment being processed                       |
| `succeeded`          | Payment successful                            |
| `failed`             | Payment failed                                |
| `cancelled`          | Payment cancelled                             |
| `refunded`           | Full refund processed                         |
| `partially_refunded` | Partial refund processed                      |
