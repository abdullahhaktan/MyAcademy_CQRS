# 🛒 CQRS & Mediator E-Commerce Project

> CQRS, MediatR ve kurumsal tasarım desenleriyle inşa edilmiş, ölçeklenebilir uçtan uca e-ticaret sistemi.
> A scalable end-to-end e-commerce system built with CQRS, MediatR, and enterprise design patterns.

[![.NET 8](https://img.shields.io/badge/.NET-8.0-512bd4?logo=dotnet)](https://dotnet.microsoft.com/en-us/)
[![C#](https://img.shields.io/badge/Language-C%23-blue.svg)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![CQRS](https://img.shields.io/badge/Pattern-CQRS_%26_MediatR-blueviolet.svg)]()
[![Cloud](https://img.shields.io/badge/Storage-Google_Cloud-4285F4?logo=googlecloud)](https://cloud.google.com/)
[![Database](https://img.shields.io/badge/Database-SQL_Server-CC2927.svg)](https://www.microsoft.com/en-us/sql-server)

---

## 🚀 Özellikler / Features

| 🇹🇷 Türkçe | 🇬🇧 English |
|------------|------------|
| CQRS ile okuma/yazma sorumluluklarının ayrıştırılması | Read/write responsibility separation via CQRS |
| MediatR ile Handler tabanlı iş mantığı | Handler-based business logic via MediatR |
| Unit of Work ile transaction yönetimi | Transaction management with Unit of Work |
| Observer Pattern ile event bazlı tetikleme | Event-based triggering via Observer Pattern |
| Chain of Responsibility ile doğrulama zinciri | Validation chain via Chain of Responsibility |
| DTO & Repository Pattern ile güvenli veri akışı | Secure data flow with DTO & Repository Pattern |
| Google Cloud Storage'da ürün görseli saklama | Product image storage on Google Cloud Storage |
| Admin paneli Area bazlı modüler yapı | Area-based modular Admin panel structure |
| Kullanıcı, kategori, ürün ve kampanya yönetimi | User, category, product & campaign management |

---

## 🏗️ Mimari / Architecture

```
CQRSECommerce/
├── ECommerce.BusinessLayer/
│   ├── Abstract/
│   └── Concrete/
│
├── ECommerce.CQRS/
│   ├── Commands/
│   │   ├── ProductCommands/
│   │   ├── CategoryCommands/
│   │   └── OrderCommands/
│   ├── Queries/
│   │   ├── ProductQueries/
│   │   ├── CategoryQueries/
│   │   └── OrderQueries/
│   └── Handlers/
│       ├── ProductHandlers/
│       ├── CategoryHandlers/
│       └── OrderHandlers/
│
├── ECommerce.DataAccessLayer/
│   ├── Abstract/
│   ├── Concrete/
│   └── UnitOfWork/
│
├── ECommerce.DtoLayer/
│   └── Dtos/
│
├── ECommerce.EntityLayer/
│   └── Entities/
│
└── ECommerce.WebUI/
    ├── Areas/
    │   └── Admin/
    ├── Controllers/
    ├── Views/
    └── wwwroot/
```

---

## 🧩 Tasarım Desenleri / Design Patterns

**CQRS (Command Query Responsibility Segregation)**
Okuma (Query) ve yazma (Command) sorumlulukları net biçimde ayrıştırılmıştır. Her işlem kendi Handler'ında izole olarak yaşar.
Read (Query) and write (Command) responsibilities are cleanly separated. Each operation lives in isolation within its own Handler.

**MediatR (Mediator Pattern)**
Controller katmanı yalnızca isteği iletir; tüm iş mantığı Handler katmanında işlenir. Katmanlar arası bağımlılık minimuma indirilmiştir.
The Controller layer only forwards requests; all business logic is processed in the Handler layer. Inter-layer dependencies are minimized.

**Unit of Work & Repository Pattern**
Veritabanı işlemleri tek bir transaction altında yönetilerek veri tutarlılığı garanti altına alınır.
Database operations are managed under a single transaction to guarantee data consistency.

**Observer & Chain of Responsibility**
Event bazlı tetiklenen süreçler Observer Pattern ile, doğrulama ve operasyon adımları ise Chain of Responsibility yapısıyla yönetilmektedir.
Event-driven processes are handled via Observer Pattern; validation and operation steps are managed with Chain of Responsibility.

---

## ☁️ Google Cloud Storage Entegrasyonu / Integration

Ürün görselleri Google Cloud Storage üzerinde saklanmaktadır. Kurulum için bir Bucket oluşturun, Service Account JSON anahtarını projeye tanımlayın ve bu dosyayı `.gitignore` içine eklemeyi unutmayın.

Product images are stored on Google Cloud Storage. To set up: create a Bucket, define the Service Account JSON key in the project, and make sure to add this file to `.gitignore`.

---

## 🛠️ Kullanılan Teknolojiler / Tech Stack

| Katman / Layer | Teknoloji / Technology |
|----------------|------------------------|
| Platform | .NET 8, ASP.NET Core MVC |
| Mimari Desen / Pattern | CQRS, MediatR, Repository, Unit of Work |
| ORM | Entity Framework Core |
| Veritabanı / Database | SQL Server |
| Depolama / Storage | Google Cloud Storage |
| Dil / Language | C# |

---

## ⚙️ Kurulum / Setup

### Gereksinimler / Requirements
- .NET 8 SDK
- SQL Server
- Google Cloud hesabı & Bucket

### Adımlar / Steps

```bash
# Repoyu klonla / Clone the repo
git clone https://github.com/abdullahhaktan/CQRSECommerce.git
cd CQRSECommerce
```

**`appsettings.json` — Bağlantı dizesi ve Cloud ayarlarını güncelle / Update connection string & Cloud config:**

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=ECommerceDb;Trusted_Connection=True;"
  },
  "GoogleCloud": {
    "BucketName": "YOUR_BUCKET_NAME",
    "CredentialsPath": "path/to/serviceaccount.json"
  }
}
```

```bash
# Package Manager Console üzerinden / Via Package Manager Console
Update-Database

# Uygulamayı başlat / Run the application
dotnet run
```

> `serviceaccount.json` dosyasını `.gitignore` içine eklemeyi unutmayın.
> Don't forget to add `serviceaccount.json` to your `.gitignore`.

---

## 📸 Ekran Görüntüleri / Screenshots

<img src="https://github.com/user-attachments/assets/7cbd1636-551a-4847-9111-e8393a352d41" alt="Register" />
<img src="https://github.com/user-attachments/assets/cae71304-e572-4e5e-8107-25dc91efbf76" alt="Dashboard" />
<img src="https://github.com/user-attachments/assets/99a5ed84-4033-47bd-aaab-11642ae1813f" alt="Home" />
<img src="https://github.com/user-attachments/assets/67a6e16a-e597-4ca5-b143-d75bf1d89697" alt="Shop" />
<img src="https://github.com/user-attachments/assets/f9ad53e3-6c98-4138-9012-f0d674dfd94c" alt="Contact" />
<img src="https://github.com/user-attachments/assets/dd009baf-a880-4c4e-9bcd-7ad8cff1dd44" alt="Admin 1" />
<img src="https://github.com/user-attachments/assets/516c0cc0-a11f-4c62-b02d-59790a9d6d28" alt="Admin 2" />
<img src="https://github.com/user-attachments/assets/959ae19e-fd6b-4cf7-b271-3b4f0499868d" alt="Admin 3" />
<img src="https://github.com/user-attachments/assets/4474528c-f801-4919-b27b-33166f543714" alt="Admin 4" />
<img src="https://github.com/user-attachments/assets/a21f26a2-5a96-4222-8df9-82a87ca2a10f" alt="Admin 5" />
<img src="https://github.com/user-attachments/assets/b940d26c-e739-4a8c-90b7-badb46b18324" alt="Admin 6" />

---

## 👨‍💻 Geliştirici / Developer

**Abdullah Haktan**
GitHub → [abdullahhaktan](https://github.com/abdullahhaktan)
