# PostgreSQL Database Setup for Backstage

Bu dosya, Backstage için PostgreSQL veritabanı kurulumu ve yönetimi hakkında bilgi içerir.

## 🚀 Hızlı Başlangıç

### Docker ile PostgreSQL Başlatma

```powershell
# PostgreSQL container'ını başlat
docker-compose -f docker-compose.postgres.yml up -d

# Container'ın çalıştığını kontrol et
docker ps

# Logları kontrol et
docker logs backstage-postgres
```

### Docker Olmadan PostgreSQL

Eğer PostgreSQL zaten yüklüyse:

```powershell
# PostgreSQL'e bağlan
psql -U postgres

# Veritabanı ve kullanıcı oluştur
CREATE USER backstage WITH PASSWORD 'backstage';
CREATE DATABASE backstage_plugin_catalog OWNER backstage;
GRANT ALL PRIVILEGES ON DATABASE backstage_plugin_catalog TO backstage;
```

## 📋 Yapılandırma

`.env` dosyasında aşağıdaki ayarlar bulunmalıdır:

```properties
POSTGRES_HOST=localhost
POSTGRES_PORT=5432
POSTGRES_USER=backstage
POSTGRES_PASSWORD=backstage
```

## 🔧 Veritabanı Yönetimi

### Veritabanını Sıfırlama

```powershell
# Container'ı durdur ve verileri sil
docker-compose -f docker-compose.postgres.yml down -v

# Yeniden başlat
docker-compose -f docker-compose.postgres.yml up -d
```

### Veritabanına Bağlanma

```powershell
# Docker üzerinden
docker exec -it backstage-postgres psql -U backstage -d backstage_plugin_catalog

# Veya doğrudan (psql yüklüyse)
psql -h localhost -U backstage -d backstage_plugin_catalog
```

### Yararlı SQL Komutları

```sql
-- Tüm tabloları listele
\dt

-- Catalog entity'lerini görüntüle
SELECT * FROM entities LIMIT 10;

-- Veritabanı boyutunu kontrol et
SELECT pg_size_pretty(pg_database_size('backstage_plugin_catalog'));

-- Bağlantı sayısını kontrol et
SELECT count(*) FROM pg_stat_activity WHERE datname = 'backstage_plugin_catalog';
```

## 🔄 Backstage'i Başlatma

PostgreSQL hazır olduktan sonra:

```powershell
# Backstage'i başlat
yarn dev
```

İlk başlatmada, Backstage otomatik olarak gerekli tabloları oluşturacaktır.

## 📊 Avantajlar

✅ **Kalıcı Veri**: Tüm catalog verileriniz PostgreSQL'de saklanır
✅ **Performans**: SQLite'a göre daha iyi performans
✅ **Üretim Hazır**: Production ortamlarında da kullanılabilir
✅ **Ölçeklenebilir**: Daha fazla veri ve kullanıcı için optimize edilmiş
✅ **Yedekleme**: Kolay backup ve restore işlemleri

## 🛠️ Sorun Giderme

### Bağlantı Hatası

```
Error: connect ECONNREFUSED 127.0.0.1:5432
```

**Çözüm**: PostgreSQL container'ının çalıştığından emin olun:

```powershell
docker-compose -f docker-compose.postgres.yml up -d
```

### Authentication Hatası

```
Error: password authentication failed for user "backstage"
```

**Çözüm**: `.env` dosyasındaki şifrelerin doğru olduğundan emin olun.

### Schema Hatası

```
Error: relation "entities" does not exist
```

**Çözüm**: Backstage'i yeniden başlatın, tablolar otomatik oluşturulacak.

## 📦 Yedekleme

### Manuel Yedekleme

```powershell
# Veritabanını yedekle
docker exec backstage-postgres pg_dump -U backstage backstage_plugin_catalog > backup.sql

# Yedekten geri yükle
docker exec -i backstage-postgres psql -U backstage -d backstage_plugin_catalog < backup.sql
```

### Otomatik Yedekleme

Production ortamında düzenli yedekleme için cron job veya scheduled task kullanın.

## 🔐 Güvenlik

**Önemli**: Production ortamında:

- ✅ Güçlü şifreler kullanın
- ✅ Network erişimini sınırlayın
- ✅ SSL/TLS bağlantısı etkinleştirin
- ✅ Düzenli yedekleme yapın
- ✅ Environment variable'ları güvenli saklayın

## 📝 Notlar

- Bu yapılandırma hem local development hem de production için uygundur
- Connection pooling aktiftir (min: 2, max: 10 connection)
- Veritabanı adı: `backstage_plugin_catalog`
- Varsayılan port: 5432
