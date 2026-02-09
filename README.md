# 🛒 CQRS & Mediator E-Commerce Project

![.NET](https://img.shields.io/badge/.NET%208.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)
![GCP](https://img.shields.io/badge/Google%20Cloud-4285F4?style=for-the-badge&logo=google-cloud&logoColor=white)

Full-Stack .NET kapsamı sürecinde geliştirdiğim **10. proje** olan bu çalışmada; modern yazılım mimarileri kullanılarak uçtan uca, ölçeklenebilir bir e-ticaret sistemi geliştirilmiştir.

---

## ⚙️ Mimari Yaklaşım & Sistem Tasarımı

Sistem genelinde karmaşıklığı yönetmek ve sürdürülebilirliği sağlamak adına aşağıdaki desenler benimsenmiştir:

* **CQRS (Command Query Responsibility Segregation):** Yazma (Command) ve okuma (Query) sorumlulukları net bir şekilde ayrıştırıldı. Bu sayede kod okunabilirliği artırıldı ve performans optimizasyonu sağlandı.
* **🔄 MediatR (Mediator Pattern):** Tüm iş akışları MediatR kullanılarak yönetildi. Controller katmanı yalnızca istekleri iletirken, iş mantığı Handler katmanında işlendi (Gevşek bağlı mimari).
* **🧱 Unit of Work & Transaction:** Veritabanı işlemleri tek bir transaction altında yönetilerek veri tutarlılığı sağlandı.
* **🔔 Observer Pattern:** Belirli aksiyonlara bağlı tetiklenen süreçler (event-based) bağımsız bir yapı ile kurgulandı.
* **🔗 Chain of Responsibility:** İstek işleme süreçleri, her adımın kendi sorumluluğunu üstlendiği esnek bir zincir yapıda ele alındı.

---

## 🛠️ Öne Çıkan Özellikler

### 🧩 Modüler Admin Panel (Area Yapısı)
Admin paneli **Area** bazlı ve modüler olarak tasarlandı. Kullanıcı, kategori, ürün ve kampanya yönetimi gibi tüm operasyonel işlemler ayrı sorumluluklar altında yapılandırıldı.

### 🛍️ Ürün & Medya Yönetimi
Ürün görselleri için **Google Cloud Storage** entegrasyonu sağlandı. Bulut depolama altyapısı sayesinde performanslı ve ölçeklenebilir bir dosya yönetim sistemi oluşturuldu.

### 💎 Clean Code & DTO
Data Transfer Object (DTO) ve Repository yapıları kullanılarak, katmanlar arası veri taşıma süreçleri optimize edildi ve temiz bir kod mimarisi hedeflendi.

---

## 🚀 Teknolojik Stack

| Alan | Teknoloji / Pattern |
| :--- | :--- |
| **Framework** | ASP.NET Core MVC |
| **Database** | SQL Server & Entity Framework Core |
| **Storage** | Google Cloud Storage (GCP) |
| **Patterns** | CQRS, Mediator, Unit of Work, Observer, Chain of Responsibility |
| **Tools** | AutoMapper, FluentValidation |

---

## 📊 Sonuç
Bu proje, kurumsal mimari desenlerin doğru senaryolarda uygulandığı, bakımı kolay ve profesyonel standartlarda bir .NET çözümü sunmaktadır.

**Teşekkürler:** Rehberlikleri için Murat Yücedağ ve Erhan Gündüz hocalarıma teşekkür ederim.

---

`#dotnetcore` `#csharp` `#aspnetmvc` `#cqrs` `#mediatr` `#unitofwork` `#observerpattern` `#googlecloud` `#ecommerce`
