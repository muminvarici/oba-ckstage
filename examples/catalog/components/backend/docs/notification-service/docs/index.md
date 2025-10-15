# Notification Service

Çok kanallı bildirim gönderimi için mikroservis.

## Desteklenen Kanallar

### 📧 Email

- SMTP entegrasyonu
- HTML templates
- Attachments
- Tracking (açılma, tıklama)

### 📱 SMS

- Netgsm, İleti Merkezi
- OTP desteği
- Bulk SMS

### 🔔 Push Notifications

- FCM (Firebase)
- APNS (iOS)
- Web Push

## Günlük İstatistikler

```
Email: 50,000 gönderim
SMS: 15,000 gönderim
Push: 100,000 gönderim
Başarı Oranı: 97%
```

## Hızlı Kullanım

### Email Gönderimi

```bash
POST /notifications/email
Content-Type: application/json

{
  "to": "user@example.com",
  "template": "order_confirmation",
  "data": {
    "orderNumber": "ORD-12345",
    "amount": 150.00
  }
}
```

### SMS Gönderimi

```bash
POST /notifications/sms
Content-Type: application/json

{
  "to": "+905551234567",
  "message": "Siparişiniz onaylandı. Takip No: 12345"
}
```

### Push Notification

```bash
POST /notifications/push
Content-Type: application/json

{
  "userId": "user-123",
  "title": "Sipariş Güncellesi",
  "body": "Siparişiniz kargoya verildi",
  "data": {
    "orderId": "order-456"
  }
}
```

## Template Yönetimi

Template'ler Handlebars formatında:

```handlebars
<h1>Merhaba {{customerName}},</h1>
<p>Siparişiniz <strong>{{orderNumber}}</strong> onaylandı.</p>
<p>Toplam Tutar: {{amount}} TL</p>
```

## Rate Limiting

| Kanal | Limit   | Pencere     |
| ----- | ------- | ----------- |
| Email | 100/dk  | User başına |
| SMS   | 10/dk   | User başına |
| Push  | 1000/dk | User başına |

## Retry Mekanizması

Başarısız bildirimlerde:

- 3 deneme
- Exponential backoff (1s, 2s, 4s)
- Dead letter queue

## Monitoring

- Prometheus metrics: `/metrics`
- Health check: `/health`
- Delivery logs: CloudWatch

## Destek

- Team: platform-team@company.com
- Slack: #notifications
