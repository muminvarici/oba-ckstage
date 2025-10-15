# Backend Services Documentation

Bu dizin, tüm backend servislerimizin TechDocs dokümantasyonlarını içerir.

## 📁 Modüler Yapı

```
docs/
├── user-service/           # Kullanıcı yönetimi servisi
│   ├── mkdocs.yml
│   ├── README.md
│   └── docs/
│       ├── index.md
│       ├── architecture.md
│       ├── api.md
│       ├── development.md
│       └── deployment.md
│
├── order-service/          # Sipariş yönetimi servisi
│   ├── mkdocs.yml
│   └── docs/
│       ├── index.md
│       ├── getting-started/
│       │   ├── quickstart.md
│       │   └── configuration.md
│       ├── features/
│       │   ├── order-processing.md
│       │   ├── payment-integration.md
│       │   └── inventory.md
│       ├── api/
│       │   ├── rest.md
│       │   ├── webhooks.md
│       │   └── events.md
│       └── ops/
│           ├── monitoring.md
│           └── troubleshooting.md
│
├── payment-service/        # Ödeme servisi
│   ├── mkdocs.yml
│   └── docs/
│       ├── index.md
│       ├── api/
│       │   ├── overview.md
│       │   ├── authentication.md
│       │   ├── endpoints.md
│       │   ├── webhooks.md
│       │   └── errors.md
│       ├── integrations/
│       │   ├── iyzico.md
│       │   └── paytr.md
│       └── security.md
│
├── notification-service/   # Bildirim servisi
│   ├── mkdocs.yml
│   └── docs/
│       ├── index.md
│       ├── channels/
│       │   ├── email.md
│       │   ├── sms.md
│       │   └── push.md
│       ├── templates.md
│       └── troubleshooting.md
│
└── analytics-service/      # Analitik servisi
    ├── mkdocs.yml
    └── docs/
        ├── index.md
        ├── architecture.md
        ├── pipeline/
        │   ├── ingestion.md
        │   ├── processing.md
        │   └── storage.md
        ├── analytics/
        │   ├── realtime.md
        │   ├── batch.md
        │   └── ml.md
        ├── dashboards.md
        └── data-catalog.md
```

## 🎨 Dokümantasyon Stilleri

Her servis için farklı dokümantasyon yaklaşımları kullanılmıştır:

### 1. User Service - **Comprehensive Technical**

- Detaylı teknik dokümantasyon
- Architecture deep-dive
- API referansı
- Development ve deployment kılavuzları
- **Hedef Kitle**: Backend developers, DevOps engineers

### 2. Order Service - **Feature-Focused**

- İş süreçleri odaklı
- Feature-by-feature açıklamalar
- Use case örnekleri
- Configuration detayları
- **Hedef Kitle**: Product owners, backend developers

### 3. Payment Service - **API-First**

- API odaklı dokümantasyon
- Endpoint detayları
- Code örnekleri
- Integration guides
- **Hedef Kitle**: Integration developers, external partners

### 4. Notification Service - **Operations-Focused**

- Hızlı başlangıç
- Channel-specific guides
- Troubleshooting
- Template yönetimi
- **Hedef Kitle**: Operations team, support engineers

### 5. Analytics Service - **Data Science**

- Data pipeline mimarisi
- Analytics use cases
- ML model documentation
- Data catalog
- **Hedef Kitle**: Data scientists, data engineers

## 🔧 Component Annotations

Her component YAML dosyasında TechDocs referansı:

```yaml
metadata:
  annotations:
    backstage.io/techdocs-ref: dir:./docs/SERVICE_NAME
```

## 📝 MkDocs Yapılandırması

Her servisin `mkdocs.yml` dosyası:

```yaml
site_name: 'Service Name'
site_description: 'Service description'

nav:
  - Home: index.md
  - Section:
      - Page: section/page.md

plugins:
  - techdocs-core
```

## 🚀 Dokümantasyon Oluşturma

### Lokal Önizleme

```bash
cd docs/SERVICE_NAME
docker run --rm -it -p 8000:8000 -v ${PWD}:/docs squidfunk/mkdocs-material
```

Tarayıcıda: http://localhost:8000

### Backstage'de Görüntüleme

1. Backstage'i başlat: `yarn start`
2. Component sayfasına git
3. "DOCS" sekmesine tıkla

## 📚 Markdown Özellikleri

### Code Blocks

\`\`\`typescript
const example = "code";
\`\`\`

### Admonitions

!!! note "Not"
Önemli bilgi

!!! warning "Uyarı"
Dikkat edilmesi gereken

!!! tip "İpucu"
Faydalı tavsiye

### Tables

| Header 1 | Header 2 |
| -------- | -------- |
| Cell 1   | Cell 2   |

### Links

[Link text](page.md)
[External link](https://example.com)

### Images

![Alt text](images/diagram.png)

## 🎯 Best Practices

### 1. Dosya Organizasyonu

- Her servis için ayrı dizin
- Mantıksal bölümlere ayır (api/, features/, ops/)
- Index.md her zaman giriş noktası

### 2. İçerik Yazımı

- Açık ve anlaşılır dil kullan
- Code örnekleri ekle
- Güncel tut
- Screenshots/diagrams ekle

### 3. Navigation

- Mantıklı hiyerarşi oluştur
- Çok derin nested yapılardan kaçın (max 3 seviye)
- İlgili sayfalar arası linkler ekle

### 4. Maintenance

- Deprecation notları ekle
- Version bilgisi belirt
- Changelog tut
- Dead link kontrolü yap

## 🔍 Arama

TechDocs otomatik arama indeksi oluşturur. Tüm dokümanlarda arama yapılabilir.

## 📊 Metrics

Dokümantasyon kullanım metrikleri:

- Sayfa görüntüleme
- Arama terimleri
- En çok okunan sayfalar

## 🤝 Katkıda Bulunma

### Yeni Dokümantasyon Ekleme

1. Servis dizini oluştur: `docs/NEW_SERVICE/`
2. `mkdocs.yml` yapılandır
3. `docs/index.md` oluştur
4. Component YAML'a annotation ekle
5. PR aç

### Mevcut Dokümantasyonu Güncelleme

1. İlgili .md dosyasını düzenle
2. Lokal önizleme yap
3. PR aç
4. Review sonrası merge

## 📧 Destek

- **Documentation Issues**: #docs-feedback (Slack)
- **Technical Questions**: #backstage-help (Slack)
- **Content Requests**: docs-team@company.com
