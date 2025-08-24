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

Branchler üzerinden geçiş yaparak projeyi çalıştırabilirsiniz.
Case1 için -> git branch case1
Case2 için -> git branch case2
Case3 için -> git branch case3
