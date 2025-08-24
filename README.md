### Case2 Çalıştırma
cd Presentation/KayraExportAPI
dotnet run

### Migration Basma
cd Infrastructure/Persistence
dotnet ef migrations add InitialCreate -s Persistence
dotnet ef database update -s Persistence

### PI çalıştığında şu adresten test edebilirsiniz:
https://localhost:5002/swagger/index.html

### Proje ÖZellikleri
Onion Mimarisi (Application, Domain, Infrastructure ve Presentation Katmanları)
Ürün yönetimi (ekleme, güncelleme, listeleme, silme)
Kullanıcı Yönetimi (Ekleme, Listeleme)
Authentication Yönetimi (JWT ile Access ve Refresh token üretimi)
CQRS Design Pattern (Command ve Query ayrımı)
Loglama Mekanizması (Serilog)
Redis Cache Entegrasyonu
Swagger UI ile dokümantasyon
