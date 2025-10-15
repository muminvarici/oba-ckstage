# Payment Service

Ödeme işlemleri ve transaction yönetimi için mikroservis.

## 🚀 Özellikler

- ✅ Çoklu ödeme gateway desteği (Iyzico, PayTR)
- ✅ 3D Secure entegrasyonu
- ✅ Taksit desteği
- ✅ Ödeme iadesi
- ✅ Webhook yönetimi
- ✅ PCI-DSS uyumlu

## 📊 Servis İstatistikleri

```
Günlük Transaction: 25,000+
Başarı Oranı: 98.5%
Ortalama Yanıt: 230ms
Uptime: 99.95%
```

## 🔗 Quick Links

- [API Reference](api/overview.md)
- [Authentication](api/authentication.md)
- [Error Codes](api/errors.md)
- [Webhooks](api/webhooks.md)

## 📦 Base URL

```
Production: https://api.example.com/payment/v1
Staging: https://api-staging.example.com/payment/v1
```

## 🔐 Authentication

```bash
Authorization: Bearer <api_key>
```

API key'inizi [developer portal](https://developer.example.com)'dan alabilirsiniz.

## 💳 Desteklenen Kartlar

| Kart Tipi        | Debit | Credit | 3D Secure |
| ---------------- | ----- | ------ | --------- |
| Visa             | ✅    | ✅     | ✅        |
| Mastercard       | ✅    | ✅     | ✅        |
| American Express | ❌    | ✅     | ✅        |
| Troy             | ✅    | ✅     | ✅        |

## 🌍 Desteklenen Para Birimleri

- TRY (Turkish Lira)
- USD (US Dollar)
- EUR (Euro)
- GBP (British Pound)

## 📞 Destek

- Email: payment-team@company.com
- Slack: #payment-service
- Docs: https://docs.example.com/payment
