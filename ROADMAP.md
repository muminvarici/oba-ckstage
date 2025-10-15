# Backstage Enterprise Geliştirme Yol Haritası

**Proje:** OBA Backstage Platform  
**Tarih:** 16 Ekim 2025  
**Durum:** Planlama ve Uygulama Aşamasında

---

## 📋 Genel Bakış

Bu dokümantasyon, enterprise Backstage platformunun geliştirilmesi için gereken tüm görevleri içerir. Her görev ayrı bir commit ile tamamlanacaktır.

---

## ✅ Tamamlanan Görevler

### 1. ✓ TODO Listesi ve Roadmap Oluşturma
- **Durum:** TAMAMLANDI
- **Açıklama:** Tüm gereksinimlerin detaylı analizi ve dokümantasyonu
- **Commit:** Initial roadmap and TODO list creation
- **Tarih:** 16 Ekim 2025

---

## 🔄 Devam Eden Görevler

_(Şu anda devam eden görev yok)_

---

## 📝 Yapılacak Görevler

### 2. GitHub Authentication Konfigürasyonu
- **Durum:** BEKLEMEDE
- **Öncelik:** YÜKSEK
- **Açıklama:** 
  - Mevcut GitHub OAuth yapılandırmasının kontrolü
  - `app-config.yaml` dosyasındaki auth ayarlarının doğrulanması
  - GitHub OAuth App credentials kontrolü
  - Kullanıcı giriş akışının test edilmesi
  - Hata durumlarının düzeltilmesi
- **Teknik Gereksinimler:**
  - GitHub OAuth App (Client ID ve Client Secret)
  - Backstage auth backend konfigürasyonu
- **Teknik Durum:** ✅ TEKNİK OLARAK MÜMKÜN

### 3. .NET Proje Template'i Ekleme
- **Durum:** BEKLEMEDE
- **Öncelik:** ORTA
- **Açıklama:**
  - .NET Core/ASP.NET Core için software template oluşturma
  - Template parametreleri tanımlama (proje adı, namespace, framework version)
  - GitHub repository oluşturma action'ı
  - CI/CD pipeline entegrasyonu
  - Template dosyalarını `examples/template/` klasörüne ekleme
- **Dosyalar:**
  - `examples/template/dotnet-template/template.yaml`
  - `examples/template/dotnet-template/content/` (skeleton files)
- **Teknik Durum:** ✅ TEKNİK OLARAK MÜMKÜN

### 4. Örnek Veri Setini Genişletme
- **Durum:** BEKLEMEDE
- **Öncelik:** ORTA
- **Açıklama:**
  - **10 Proje (Component):** Farklı tipte projeler (backend, frontend, mobile, library)
  - **15 Kullanıcı (User):** Farklı rollerle (developer, architect, manager)
  - **3 Ekip (Group):** Her ekip farklı sorumluluklara sahip
  - **4 API:** RESTful ve gRPC API tanımları
  - Kullanıcılar birden fazla grubun üyesi olabilir
  - Organizasyon hiyerarşisi (parent-child ilişkileri)
- **Dosyalar:**
  - `examples/org.yaml` - Kullanıcılar ve gruplar
  - `examples/entities.yaml` - Katalog referansları
  - `examples/catalog/components/*.yaml` - Proje tanımları
  - `examples/catalog/api/*.yaml` - API tanımları
- **Teknik Durum:** ✅ TEKNİK OLARAK MÜMKÜN

### 5. TechDocs Plugin Entegrasyonu
- **Durum:** BEKLEMEDE
- **Öncelik:** YÜKSEK
- **Açıklama:**
  - `@backstage/plugin-techdocs` frontend plugin kurulumu
  - `@backstage/plugin-techdocs-backend` backend plugin kurulumu
  - Dokümantasyon generatör konfigürasyonu (local/external)
  - Markdown dosyaları için MkDocs yapılandırması
  - Entity sayfalarına TechDocs tab'ı ekleme
- **Paketler:**
  - `@backstage/plugin-techdocs`
  - `@backstage/plugin-techdocs-backend`
  - `@techdocs/cli` (optional)
- **Teknik Durum:** ✅ TEKNİK OLARAK MÜMKÜN

### 6. Kubernetes Plugin (Rancher/Google Anthos)
- **Durum:** BEKLEMEDE
- **Öncelik:** YÜKSEK
- **Açıklama:**
  - `@backstage/plugin-kubernetes` kurulumu
  - Kubernetes cluster bağlantı yapılandırması
  - Rancher veya Google Anthos API entegrasyonu
  - ServiceAccount ve RBAC yapılandırması
  - Entity annotation'ları ile cluster ilişkilendirme
  - Pod, Deployment, Service görüntüleme
- **Paketler:**
  - `@backstage/plugin-kubernetes`
  - `@backstage/plugin-kubernetes-backend`
- **Teknik Durum:** ✅ TEKNİK OLARAK MÜMKÜN
- **Not:** Rancher ve Anthos API credentials gerekli

### 7. ArgoCD Plugin Entegrasyonu
- **Durum:** BEKLEMEDE
- **Öncelik:** YÜKSEK
- **Açıklama:**
  - ArgoCD plugin kurulumu (`@roadiehq/backstage-plugin-argo-cd` veya community plugin)
  - ArgoCD API bağlantısı yapılandırması
  - Uygulama listeleme ve detay görüntüleme
  - **Restart/Sync operasyonu ekleme**
  - Entity annotation'ları ile ArgoCD app ilişkilendirme
- **Paketler:**
  - `@roadiehq/backstage-plugin-argo-cd` veya
  - `@roadiehq/backstage-plugin-argo-cd-backend`
- **Teknik Durum:** ✅ TEKNİK OLARAK MÜMKÜN
- **Not:** ArgoCD server URL ve authentication token gerekli

### 8. GitHub Actions Plugin
- **Durum:** BEKLEMEDE
- **Öncelik:** YÜKSEK
- **Açıklama:**
  - `@backstage/plugin-github-actions` kurulumu
  - GitHub API entegrasyonu (token ile)
  - Workflow listesi görüntüleme
  - Workflow çalıştırma geçmişi
  - **Manuel workflow tetikleme özelliği**
  - Entity sayfalarına GitHub Actions tab'ı ekleme
- **Paketler:**
  - `@backstage/plugin-github-actions`
- **Teknik Durum:** ✅ TEKNİK OLARAK MÜMKÜN
- **Not:** GitHub Personal Access Token (repo ve workflow yetkileri)

### 9. Apicurio Entegrasyonu
- **Durum:** BEKLEMEDE
- **Öncelik:** ORTA
- **Açıklama:**
  - Apicurio Registry API entegrasyonu
  - Schema ve artifact görüntüleme
  - OpenAPI, AsyncAPI, Avro schema desteği
  - Entity annotation'ları ile Apicurio artifact ilişkilendirme
- **Olası Çözümler:**
  - Özel plugin geliştirme (custom plugin)
  - API Definition plugin ile entegrasyon
  - TechDocs üzerinden dokümantasyon
- **Teknik Durum:** ⚠️ ÖZEL GELİŞTİRME GEREKTİRİR
- **Not:** Backstage için hazır Apicurio plugin bulunmamaktadır. Custom plugin veya adapter geliştirme gerekir.

### 10. Grafana Plugin Aktivasyonu
- **Durum:** BEKLEMEDE
- **Öncelik:** YÜKSEK
- **Açıklama:**
  - `@k-phoen/backstage-plugin-grafana` veya `@backstage/plugin-grafana` kurulumu
  - Grafana API bağlantısı yapılandırması
  - Dashboard embedding
  - Metrics ve alertler görüntüleme
  - Entity annotation'ları ile dashboard ilişkilendirme
- **Paketler:**
  - `@k-phoen/backstage-plugin-grafana`
  - `@k-phoen/backstage-plugin-grafana-backend`
- **Teknik Durum:** ✅ TEKNİK OLARAK MÜMKÜN
- **Not:** Grafana API key veya service account token gerekli

### 11. gRPC Proto Dosyaları Görüntüleme
- **Durum:** BEKLEMEDE
- **Öncelik:** DÜŞÜK
- **Açıklama:**
  - gRPC .proto dosyalarının görüntülenmesi
  - Protocol Buffer schema viewer
  - Service ve message definition'ları
  - Entity annotation'ları ile proto dosya ilişkilendirme
- **Olası Çözümler:**
  1. TechDocs ile proto dosyaları dokümante etme
  2. API Definition plugin ile proto dosyalarını gösterme
  3. Özel bir proto viewer component geliştirme
  4. GitHub/GitLab file viewer entegrasyonu
- **Teknik Durum:** ⚠️ ÖZEL GELİŞTİRME GEREKEBİLİR
- **Not:** Hazır plugin bulunmamaktadır. En pratik çözüm TechDocs veya API Definition plugin kullanımıdır.

---

## 🚧 Teknik Kısıtlamalar ve Özel Geliştirme Gerektiren Özellikler

### ⚠️ Özel Geliştirme Gerektirenler:

1. **Apicurio Entegrasyonu (Görev #9)**
   - Backstage ekosisteminde hazır Apicurio plugin bulunmamaktadır
   - **Çözüm Önerileri:**
     - Custom Backstage plugin geliştirme
     - Apicurio Registry REST API ile entegrasyon
     - API Definition plugin ile adapte etme
   - **Geliştirme Süresi:** 2-3 hafta (custom plugin için)

2. **gRPC Proto Dosyaları Görüntüleme (Görev #11)**
   - Doğrudan proto viewer plugin bulunmamaktadır
   - **Çözüm Önerileri:**
     - TechDocs ile proto dosyalarını markdown olarak dokümante etme
     - GitHub/GitLab integration ile source code viewer kullanma
     - Basit bir proto syntax highlighter component geliştirme
   - **Geliştirme Süresi:** 1-2 hafta (basit viewer için)

### ✅ Hazır Plugin ile Çözülebilir:

- GitHub Authentication ✅
- .NET Template ✅
- TechDocs ✅
- Kubernetes (Rancher/Anthos) ✅
- ArgoCD ✅
- GitHub Actions ✅
- Grafana ✅

---

## 📦 Bağımlılıklar ve Önkoşullar

### External Services:
- GitHub (OAuth App, Personal Access Token)
- Kubernetes Cluster (Rancher/Anthos credentials)
- ArgoCD Server (API URL, Auth Token)
- Grafana Instance (API Key)
- Apicurio Registry (opsiyonel, eğer kullanılacaksa)

### Development Tools:
- Node.js (v18+)
- Yarn (v1.22+)
- Git
- Docker (opsiyonel, containerization için)

---

## 🔄 Commit Stratejisi

Her görev için ayrı commit atılacaktır:

```
commit #1: docs: add project roadmap and TODO list
commit #2: fix: verify and fix GitHub authentication configuration
commit #3: feat: add .NET Core project template
commit #4: feat: expand example data with 10 projects, 15 users, 3 teams, 4 APIs
commit #5: feat: integrate TechDocs plugin
commit #6: feat: add Kubernetes plugin with Rancher/Anthos support
commit #7: feat: integrate ArgoCD plugin with restart capability
commit #8: feat: add GitHub Actions plugin with trigger support
commit #9: feat: integrate Apicurio viewer (custom plugin)
commit #10: feat: activate Grafana plugin
commit #11: feat: add gRPC proto file viewer
```

---

## 📊 İlerleme Takibi

- **Toplam Görev:** 11
- **Tamamlanan:** 1 (9%)
- **Devam Eden:** 0
- **Bekleyen:** 10 (91%)

---

## 📞 İletişim ve Destek

Bu yol haritası ile ilgili sorularınız için lütfen proje ekibi ile iletişime geçin.

---

**Son Güncelleme:** 16 Ekim 2025
