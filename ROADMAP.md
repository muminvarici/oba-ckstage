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

- **Durum:** TAMAMLANDI ✅
- **Açıklama:** Tüm gereksinimlerin detaylı analizi ve dokümantasyonu
- **Commit:** `06ab482 - docs: add project roadmap and TODO list`
- **Tarih:** 16 Ekim 2025

### 2. ✓ GitHub Authentication Konfigürasyonu

- **Durum:** TAMAMLANDI ✅
- **Açıklama:** GitHub OAuth yapılandırması tamamlandı (önceki commitlere göre)
- **Commit:** `f7f46c5 - Github authentication support added`
- **Tarih:** Önceki tarih

### 3. ✓ .NET Proje Template'i Ekleme

- **Durum:** TAMAMLANDI ✅
- **Açıklama:**
  - .NET Core Web API template'i oluşturuldu
  - Template parametreleri ve skeleton dosyaları eklendi
  - `examples/template/dotnet-webapi/` altında tüm dosyalar hazır
- **Commit:** `8b718ac - feat: add .NET Core Web API template`
- **Tarih:** 16 Ekim 2025

### 4. ✓ Örnek Veri Setini Genişletme

- **Durum:** TAMAMLANDI ✅
- **Açıklama:**
  - Modüler katalog yapısı oluşturuldu
  - Backend servisleri (5 adet), Frontend uygulamaları (3 adet), Infrastructure bileşenleri eklendi
  - API tanımları (5 adet) eklendi
  - Ekipler (5 adet) ve kullanıcılar organizasyonu oluşturuldu
  - Tüm dosyalar modüler yapıda `examples/catalog/` altında düzenlendi
- **Commit:**
  - `39a49e2 - feat: refactor catalog to modular enterprise structure`
  - `17cb4c4 - feat: Catalog yapısı tam modüler hale getirildi ve TechDocs eklendi`
- **Tarih:** 16 Ekim 2025

### 5. ✓ TechDocs Plugin Entegrasyonu

- **Durum:** TAMAMLANDI ✅
- **Açıklama:**
  - TechDocs hazırlığı yapıldı
  - Backend servisleri için docs klasörleri oluşturuldu
  - README.md dosyaları eklendi
- **Commit:** `17cb4c4 - feat: Catalog yapısı tam modüler hale getirildi ve TechDocs eklendi`
- **Tarih:** 16 Ekim 2025

### 6. ✓ GitHub Actions Plugin

- **Durum:** TAMAMLANDI ✅
- **Açıklama:**
  - `@backstage/plugin-github-actions` kurulumu yapıldı
  - EntityPage.tsx'e GitHub Actions tab'ı eklendi
  - GitHub entegrasyonu zaten mevcuttu (token ile)
  - Örnek katalog entity'lerine workflow annotations eklendi
  - Manuel workflow tetikleme özelliği kullanıma hazır
- **Paketler:** `@backstage/plugin-github-actions@0.6.16`
- **Commit:** `feat: add GitHub Actions plugin with trigger support`
- **Tarih:** 16 Ekim 2025
- **Not:** GitHub token'ın repo ve workflow scope'larına sahip olması gerekiyor

---

## 🔄 Devam Eden Görevler

_(Şu anda devam eden görev yok)_

---

## 📝 Yapılacak Görevler

### 7. Kubernetes Plugin (Rancher/Google Anthos)

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

### 8. ArgoCD Plugin Entegrasyonu

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
✅ commit #1: docs: add project roadmap and TODO list (06ab482)
✅ commit #2: Github authentication support added (f7f46c5)
✅ commit #3: feat: add .NET Core Web API template (8b718ac)
✅ commit #4: feat: refactor catalog to modular enterprise structure (39a49e2)
✅ commit #5: feat: Catalog yapısı tam modüler hale getirildi ve TechDocs eklendi (17cb4c4)
✅ commit #6: feat: add GitHub Actions plugin with trigger support
⏳ commit #7: feat: add Kubernetes plugin with Rancher/Anthos support
⏳ commit #8: feat: integrate ArgoCD plugin with restart capability
⏳ commit #9: feat: integrate Apicurio viewer (custom plugin)
⏳ commit #10: feat: activate Grafana plugin
⏳ commit #11: feat: add gRPC proto file viewer
```

---

## 📊 İlerleme Takibi

- **Toplam Görev:** 11
- **Tamamlanan:** 6 ✅ (55%)
- **Devam Eden:** 0
- **Bekleyen:** 5 ⏳ (45%)

---

## 📞 İletişim ve Destek

Bu yol haritası ile ilgili sorularınız için lütfen proje ekibi ile iletişime geçin.

---

**Son Güncelleme:** 16 Ekim 2025
