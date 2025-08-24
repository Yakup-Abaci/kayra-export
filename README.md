### Case2 Çalıştırma
cd Presentation/KayraExportAPI
dotnet run

### Migration Basma
cd Infrastructure/Persistence
dotnet ef migrations add InitialCreate -s Persistence
dotnet ef database update -s Persistence

### PI çalıştığında şu adresten test edebilirsiniz:
https://localhost:5002/swagger/index.html
