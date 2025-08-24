# Kayra Export Case Çalışması

Bu proje, **ASP.NET Core 6 Web API** kullanılarak geliştirilmiş tekil bir servis uygulamasıdır.  
Uygulama içerisinde ürün yönetimi, kullanıcı işlemleri ve diğer temel modüller aynı API altında toplanmıştır.  

## Proje Yapısı
KayraExportAPI/
│
├── Core/ → Domain modelleri, interface’ler
├── Infrastructure/ → Harici servis bağlantıları
├── Persistence/ → Entity Framework Core, DbContext, Migration
└── Presentation/ → Web API katmanı (Swagger, Controller, Program.cs)

## 🚀 Başlarken

### Gereksinimler
- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- SQL Server (veya başka veritabanı)
- (Opsiyonel) Visual Studio / VS Code


### 1. Repository Klonlama
git clone https://github.com/kullaniciadi/kayra-export.git
cd kayra-export

### 2. Case1 Çalıştırma
cd KayraExportAPI
dotnet run
### PI çalıştığında şu adresten test edebilirsiniz:
https://localhost:5002/swagger/index.html
### appsettings.json dosyasında veritabanı bağlantısı ayarlanabilir:
{
  "ConnectionStrings": {
    "sqlConnection": "Server=localhost,1433;Database=KayraExportDb;User Id=sa;Password=YourPassword123;"
  }
}

### 3. Case2 Çalıştırma
cd Presentation/KayraExportAPI
dotnet run
### Migration Basma
cd Persistence
dotnet ef migrations add InitialCreate -s ../Presentation/KayraExportAPI
dotnet ef database update -s ../Presentation/KayraExportAPI
### PI çalıştığında şu adresten test edebilirsiniz:
https://localhost:5002/swagger/index.html

### 3. Case3 Çalıştırma
cd Presentation/KayraExportAPI
dotnet run
### Migration Basma
cd Persistence
dotnet ef migrations add InitialCreate -s ../Presentation/KayraExportAPI
dotnet ef database update -s ../Presentation/KayraExportAPI
### PI çalıştığında şu adresten test edebilirsiniz:
https://localhost:5002/swagger/index.html

Ürün yönetimi (ekleme, güncelleme, listeleme, silme)
Kullanıcı işlemleri
Swagger UI ile dokümantasyon
Katmanlı mimari yaklaşımı
