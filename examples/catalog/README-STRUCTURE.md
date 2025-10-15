# Catalog Structure - Modular Location Management

Bu dizin, Backstage catalog yapısının modüler organizasyonunu içerir.

## 📁 Dizin Yapısı

```
catalog/
├── all.yaml                          # Ana giriş noktası - Tüm catalog'u yükler
│
├── systems/
│   ├── all.yaml                      # Tüm sistemleri yükler
│   └── examples-system.yaml          # E-commerce platform sistemi
│
├── components/
│   ├── all.yaml                      # Tüm component kategorilerini yükler
│   │
│   ├── backend/
│   │   ├── all.yaml                  # Tüm backend servisleri yükler
│   │   ├── user-service.yaml
│   │   ├── order-service.yaml
│   │   ├── payment-service.yaml
│   │   ├── notification-service.yaml
│   │   ├── analytics-service.yaml
│   │   └── docs/                     # TechDocs dokümantasyonları
│   │       ├── README.md
│   │       ├── user-service/
│   │       ├── order-service/
│   │       ├── payment-service/
│   │       ├── notification-service/
│   │       └── analytics-service/
│   │
│   ├── frontend/
│   │   ├── all.yaml                  # Tüm frontend uygulamaları yükler
│   │   ├── mobile-app.yaml
│   │   ├── admin-dashboard.yaml
│   │   └── example-website.yaml
│   │
│   └── infrastructure/
│       ├── all.yaml                  # Tüm infrastructure kaynaklarını yükler
│       ├── api-gateway.yaml
│       ├── message-queue.yaml
│       └── database-cluster.yaml
│
└── apis/
    ├── all.yaml                      # Tüm API'leri yükler
    ├── user-api.yaml
    ├── order-api.yaml
    ├── payment-api.yaml
    ├── analytics-api.yaml
    └── example-grpc-api.yaml
```

## 🔗 Location Hiyerarşisi

### Seviye 1: Ana Giriş Noktası
```yaml
# catalog/all.yaml
- systems/all.yaml
- components/all.yaml
- apis/all.yaml
```

### Seviye 2: Kategori Düzeyi
```yaml
# components/all.yaml
- backend/all.yaml
- frontend/all.yaml
- infrastructure/all.yaml
```

### Seviye 3: Servis Düzeyi
```yaml
# backend/all.yaml
- user-service.yaml
- order-service.yaml
- payment-service.yaml
- notification-service.yaml
- analytics-service.yaml
```

## 🎯 Avantajlar

### 1. Modülerlik
- Her kategori bağımsız yönetilebilir
- Servisler kolayca eklenip çıkarılabilir
- Değişiklikler izole edilebilir

### 2. Okunabilirlik
- Açık ve anlaşılır hiyerarşi
- Her all.yaml dosyası kendi kategorisini yönetir
- Dokümantasyon kolay takip edilir

### 3. Bakım Kolaylığı
- Yeni servis eklemek için sadece ilgili all.yaml güncellenir
- Global değişiklik gerekmez
- Conflict riski düşük

### 4. Ölçeklenebilirlik
- Yeni kategoriler kolayca eklenebilir
- Servis sayısı arttıkça yapı bozulmaz
- Team bazlı yönetim mümkün

## 🚀 Kullanım

### Tüm Catalog'u Yükle

`app-config.yaml` içinde:

```yaml
catalog:
  locations:
    - type: file
      target: ../../examples/catalog/all.yaml
```

### Sadece Backend Servisleri Yükle

```yaml
catalog:
  locations:
    - type: file
      target: ../../examples/catalog/components/backend/all.yaml
```

### Tek Bir Servisi Yükle

```yaml
catalog:
  locations:
    - type: file
      target: ../../examples/catalog/components/backend/user-service.yaml
```

## 📝 Yeni Servis Ekleme

### Backend Servis Ekleme

1. Servis YAML dosyasını oluştur:
   ```bash
   touch examples/catalog/components/backend/new-service.yaml
   ```

2. `backend/all.yaml` dosyasını güncelle:
   ```yaml
   ---
   apiVersion: backstage.io/v1alpha1
   kind: Location
   metadata:
     name: backend-new-service
     description: New service description
   spec:
     type: file
     targets:
       - ./new-service.yaml
   ```

3. TechDocs eklemek için:
   ```bash
   mkdir -p examples/catalog/components/backend/docs/new-service
   ```

### Frontend/Infrastructure için benzer adımlar

Frontend veya Infrastructure için de aynı yaklaşım geçerlidir.

## 🔧 Location Metadata

Her Location şu yapıyı kullanır:

```yaml
apiVersion: backstage.io/v1alpha1
kind: Location
metadata:
  name: unique-location-name           # Benzersiz isim
  description: Human-readable desc      # Açıklama
spec:
  type: file                           # Location tipi
  targets:                             # Hedef dosyalar
    - ./relative-path.yaml
```

## 📊 Inventory

### Mevcut Servisler

**Backend (5):**
- user-service
- order-service
- payment-service
- notification-service
- analytics-service

**Frontend (3):**
- mobile-app
- admin-dashboard
- example-website

**Infrastructure (3):**
- api-gateway
- message-queue
- database-cluster

**APIs (5):**
- user-api (REST)
- order-api (REST)
- payment-api (REST)
- analytics-api (GraphQL)
- example-grpc-api (gRPC)

**Systems (1):**
- examples (E-commerce Platform)

## 🏷️ Naming Convention

### Location Names
Format: `{category}-{service-name}`

Örnekler:
- `backend-user-service`
- `frontend-mobile-app`
- `infrastructure-api-gateway`
- `api-user-api`

### File Names
Format: `{service-name}.yaml`

Örnekler:
- `user-service.yaml`
- `mobile-app.yaml`
- `api-gateway.yaml`

## 🔍 Best Practices

1. **Single Responsibility**: Her all.yaml sadece kendi kategorisinden sorumlu
2. **Relative Paths**: Her zaman relative path kullan
3. **Descriptive Names**: Metadata name ve description açıklayıcı olmalı
4. **Consistent Structure**: Tüm kategorilerde aynı yapıyı kullan
5. **Documentation**: Her seviyede README.md bulundur

## 🐛 Troubleshooting

### Location Yüklenmiyor

```bash
# Backstage loglarını kontrol et
yarn dev

# Catalog sync durumunu kontrol et
# http://localhost:3000/catalog-import
```

### Relative Path Hatası

Location'lar her zaman bulundukları dizine göre relative path kullanır:

```yaml
# ✅ Doğru (backend/all.yaml içinden)
targets:
  - ./user-service.yaml

# ❌ Yanlış
targets:
  - ./backend/user-service.yaml  # Zaten backend içindeyiz
```

### Duplicate Location

Her Location'un unique bir `metadata.name` olmalı:

```yaml
# ✅ Doğru
name: backend-user-service

# ❌ Yanlış (duplicate)
name: user-service  # Başka yerde de kullanılmış olabilir
```

## 📞 Destek

- **Catalog Issues**: #catalog-help (Slack)
- **Location Errors**: #backstage-support (Slack)
- **Documentation**: platform-team@company.com
