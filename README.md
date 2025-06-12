# 🏭 Mini Stok Takip API

ASP.NET Core ile geliştirilmiş basit bir stok yönetim sistemi API'sidir. Ürünlerin giriş/çıkış işlemleri takip edilir, her işlem kullanıcı ile ilişkilendirilir ve stok durumu otomatik güncellenir.

## 🚀 Özellikler

- 👤 Kullanıcı kayıt ve giriş (şifre düz metin)
- 📦 Ürün ekleme, listeleme, detay görüntüleme
- 🔄 Stok giriş / çıkış işlemleri
- 📊 Ürüne ait stok geçmişi görüntüleme
- ✅ `OUT` işlemlerinde stok yeterliliği kontrolü
- 🧠 Benzersiz ürün kodu kontrolü
- 🛠️ Swagger arayüzü ile test edilebilir

## ⚙️ Teknolojiler

- ASP.NET Core Web API
- Entity Framework Core
- MySQL (Pomelo EF Provider)
- Swagger UI (Swashbuckle)
- Visual Studio Code / Rider

## 🗂️ Proje Yapısı

```
MiniStokTakipAPI/
├── Controllers/
│   ├── UserController.cs
│   ├── ProductController.cs
│   └── StockTransactionController.cs
├── Models/
│   ├── User.cs
│   ├── Product.cs
│   └── StockTransaction.cs
├── Data/
│   └── AppDbContext.cs
├── Program.cs
├── appsettings.json
└── README.md
```

## 🔧 Kurulum ve Çalıştırma

### 1️⃣ Gereksinimler

- .NET 8 SDK
- MySQL 8+ (veya uyumlu MariaDB)
- Visual Studio Code

### 2️⃣ Bağlantı Ayarı (`appsettings.json`)

```json
"ConnectionStrings": {
  "DefaultConnection": "server=localhost;port=3306;database=StokDb;user=root;password=yourpassword"
}
```

### 3️⃣ Projeyi Çalıştırma

```bash
dotnet restore
dotnet ef database update
dotnet run
```

API'yi test etmek için: [http://localhost:5245/swagger](http://localhost:5245/swagger)

## 📦 Örnek JSON Formatları

### 📌 Kullanıcı Kaydı (POST /api/user/register)

```json
{
  "name": "Mustafa AYAZ",
  "email": "mustafa@example.com",
  "password": "123456"
}
```

### 📌 Kullanıcı Girişi (POST /api/user/login)

```json
{
  "email": "mustafa@example.com",
  "password": "123456"
}
```

### 📌 Ürün Ekleme (POST /api/product)

```json
{
  "name": "Mouse",
  "code": "PRD002",
  "unit": "adet",
  "totalStock": 0
}
```

### 📌 Stok Girişi (POST /api/stocktransaction)

```json
{
  "productId": 3,
  "quantity": 10,
  "type": "IN",
  "date": "2025-06-11T18:53:14.291Z",
  "userId": 1
}
```

### 📌 Stok Çıkışı (POST /api/stocktransaction)

```json
{
  "productId": 3,
  "quantity": 5,
  "type": "OUT",
  "date": "2025-06-12T10:15:00",
  "userId": 1
}
```

### 📌 Ürün Stok Geçmişi (GET /api/stocktransaction/product/3)

```json
[
  {
    "id": 5,
    "productId": 3,
    "quantity": 10,
    "type": "IN",
    "date": "2025-06-11T18:53:14.291Z",
    "userId": 1
  },
  {
    "id": 6,
    "productId": 3,
    "quantity": 5,
    "type": "OUT",
    "date": "2025-06-12T10:15:00",
    "userId": 1
  }
]
```
