# TechDocs Entegrasyonu

Bu dizin, Backstage TechDocs eklentisinin nasıl kullanılacağını gösteren örnek dokümantasyon içerir.

## Kurulum

TechDocs eklentileri zaten kurulmuş durumda:
- Frontend: `@backstage/plugin-techdocs`
- Backend: `@backstage/plugin-techdocs-backend`

## Yapılandırma

`app-config.yaml` dosyasında TechDocs yapılandırması:

```yaml
techdocs:
  builder: 'local'
  generator:
    runIn: 'docker'  # Docker ile MkDocs kullanılır
  publisher:
    type: 'local'    # Yerel geliştirme için
```

## Dokümantasyon Ekleme

Bir component'e dokümantasyon eklemek için:

### 1. Dizin Yapısı Oluştur

```
component-name-docs/
├── mkdocs.yml
└── docs/
    ├── index.md
    ├── api.md
    └── ...
```

### 2. mkdocs.yml Yapılandır

```yaml
site_name: 'Component Name'
site_description: 'Component documentation'

nav:
  - Home: index.md
  - API: api.md

plugins:
  - techdocs-core
```

### 3. Component YAML'ına Annotation Ekle

```yaml
metadata:
  annotations:
    backstage.io/techdocs-ref: dir:./component-name-docs
```

## Örnek Dokümantasyon

`user-service` için tam dokümantasyon örneği hazırlanmıştır:

- **index.md**: Genel bakış ve başlangıç
- **architecture.md**: Sistem mimarisi ve tasarım
- **api.md**: API referans dokümantasyonu
- **development.md**: Geliştirme ortamı kurulumu
- **deployment.md**: Deployment ve operasyon

## Dokümantasyonu Görüntüleme

1. Backstage'i başlat: `yarn start`
2. Component sayfasına git: http://localhost:3000/catalog/default/component/user-service
3. "DOCS" sekmesine tıkla

## Docker Gereksinimi

TechDocs, MkDocs'u Docker içinde çalıştırır. Docker'ın kurulu ve çalışır durumda olması gerekir.

Docker yoksa, `app-config.yaml`'da generator'ı değiştir:

```yaml
techdocs:
  generator:
    runIn: 'local'  # Docker yerine lokal MkDocs
```

Bu durumda MkDocs'u manuel yüklemeniz gerekir:
```bash
pip install mkdocs-techdocs-core
```

## MkDocs Özellikleri

TechDocs, MkDocs'un tüm özelliklerini destekler:

- **Markdown**: Standart Markdown syntax
- **Code Highlighting**: Syntax highlighting
- **Navigation**: Otomatik navigasyon menüsü
- **Search**: Tam metin arama
- **Extensions**: Admonitions, tables, code blocks, etc.

## Markdown Örnekleri

### Kod Blokları

\`\`\`python
def hello():
    print("Hello, World!")
\`\`\`

### Uyarılar

!!! note
    Bu bir bilgi notudur.

!!! warning
    Bu bir uyarıdır.

### Tablolar

| Header 1 | Header 2 |
|----------|----------|
| Cell 1   | Cell 2   |

## En İyi Pratikler

1. **Modüler Yapı**: Her component'in kendi docs dizini olsun
2. **Tutarlı Navigasyon**: Benzer yapıda nav menüleri kullanın
3. **Güncelleme**: Kod değiştiğinde dokümantasyonu güncelleyin
4. **Örnekler**: Kod örnekleri ve use case'ler ekleyin
5. **Diyagramlar**: Mermaid, PlantUML gibi diyagram araçları kullanın

## Troubleshooting

### Docs Görünmüyor

1. Component YAML'da annotation doğru mu kontrol edin
2. mkdocs.yml dosyası var mı kontrol edin
3. Docker çalışıyor mu kontrol edin
4. Backend loglarını kontrol edin

### Docker Hatası

Docker servisinin çalıştığından emin olun:
```powershell
docker ps
```

### Build Hatası

MkDocs yapılandırmasını manuel test edin:
```bash
cd component-docs
docker run --rm -v ${PWD}:/docs squidfunk/mkdocs-material build
```

## Kaynaklar

- [TechDocs Documentation](https://backstage.io/docs/features/techdocs/)
- [MkDocs Documentation](https://www.mkdocs.org/)
- [Material for MkDocs](https://squidfunk.github.io/mkdocs-material/)
