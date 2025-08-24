### Case1 Çalıştırma
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

### Migration Basma
cd Persistence/KayraExportAPI
dotnet ef migrations add InitialCreate -s KayraExportAPI
dotnet ef database update -s KayraExportAPI

### PI çalıştığında şu adresten test edebilirsiniz:
https://localhost:5002/swagger/index.html

### Proje ÖZellikleri
Ürün yönetimi (ekleme, güncelleme, listeleme, silme)
Swagger UI ile dokümantasyon
