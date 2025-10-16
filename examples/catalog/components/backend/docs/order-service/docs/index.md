# Order Service

## Genel Bakış

Order Service, e-ticaret platformumuzun sipariş yönetimi ve işleme sisteminin kalbidir. Sipariş oluşturma, ödeme işleme, envanter senkronizasyonu ve teslimat takibi gibi kritik işlemleri yönetir.

## Temel Özellikler

### 🛒 Sipariş Yönetimi

- Sipariş oluşturma ve güncelleme
- Sipariş durumu takibi
- Sipariş iptali ve iade işlemleri

### 💳 Ödeme Entegrasyonu

- Çoklu ödeme gateway desteği
- 3D Secure entegrasyonu
- Ödeme planı ve taksitlendirme

### 📦 Envanter Senkronizasyonu

- Gerçek zamanlı stok kontrolü
- Otomatik rezervasyon sistemi
- Stok eksikliği uyarıları

### 🚚 Kargo Entegrasyonu

- Çoklu kargo firması desteği
- Otomatik kargo seçimi
- Takip numarası yönetimi

## Mimari

```
┌──────────────┐
│  API Gateway │
└──────┬───────┘
       │
┌──────▼───────────────────────┐
│     Order Service            │
│  ┌────────────────────────┐  │
│  │  Order Management      │  │
│  │  Payment Processing    │  │
│  │  Inventory Integration │  │
│  └────────────────────────┘  │
└──────┬───────────────────────┘
       │
┌──────▼───────┐  ┌──────────┐
│  PostgreSQL  │  │  RabbitMQ│
└──────────────┘  └──────────┘
```

## Teknoloji Stack

| Kategori      | Teknoloji      |
| ------------- | -------------- |
| Runtime       | Node.js 18+    |
| Framework     | NestJS         |
| Database      | PostgreSQL 14  |
| Message Queue | RabbitMQ       |
| Cache         | Redis          |
| API Protocol  | REST + GraphQL |

## Hızlı Başlangıç

```bash
# Projeyi klonla
git clone https://github.com/example-org/order-service

# Bağımlılıkları yükle
npm install

# Geliştirme modunda başlat
npm run dev
```

Daha fazla bilgi için [Quick Start](getting-started/quickstart.md) sayfasına bakın.

## Servis Metrikleri

- **Ortalama Yanıt Süresi**: 50ms
- **Günlük Sipariş**: ~50,000
- **Peak Load**: 200 req/s
- **Availability**: 99.9%

## İlgili Servisler

- [Payment Service](../../payment-service) - Ödeme işlemleri
- [Notification Service](../../notification-service) - Bildirim gönderimi
- [User Service](../../user-service) - Kullanıcı yönetimi

## Destek

- **Email**: backend-team@company.com
- **Slack**: #order-service
- **On-call**: PagerDuty rotation
