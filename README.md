# 🛒 CQRS & Mediator E-Commerce Project

Full-Stack .NET eğitim sürecimde geliştirdiğim **10. proje** olan bu çalışmada; modern yazılım mimarileri kullanılarak uçtan uca, ölçeklenebilir bir e-ticaret sistemi geliştirilmiştir.

---

## ✨ Proje Amacı ve Kapsam

Bu projenin amacı; kurumsal mimari desenleri doğru senaryolarda uygulayarak, sürdürülebilir, genişletilebilir ve temiz kod prensiplerine uygun bir .NET e-ticaret altyapısı sunmaktır.

---

## ⚙️ Teknik Yapı ve Mimari Standartlar

| Alan | Açıklama |
| --- | --- |
| Platform | .NET 8, ASP.NET Core MVC |
| Veritabanı | Entity Framework Core (SQL Server) |
| Mimari | CQRS & Mediator Pattern |
| Veri Yönetimi | DTO & Repository Pattern |
| Transaction | Unit of Work |
| Depolama | Google Cloud Storage |

---

## 🏗️ Kullanılan Mimari Yaklaşımlar

- **CQRS (Command Query Responsibility Segregation)**  
  Okuma (Query) ve yazma (Command) sorumlulukları net şekilde ayrıştırılmıştır.

- **MediatR (Mediator Pattern)**  
  Controller katmanı yalnızca isteği iletir, tüm iş mantığı Handler katmanında işlenir.

- **Unit of Work & Transaction Yönetimi**  
  Veritabanı işlemleri tek bir transaction altında yönetilerek veri tutarlılığı sağlanır.

- **Observer Pattern**  
  Event bazlı tetiklenen süreçler için kullanılmıştır.

- **Chain of Responsibility**  
  Doğrulama ve operasyon adımları zincir yapıda ele alınmıştır.

---

## 🧩 Modüler Yapı

- Admin paneli Area bazlı olarak tasarlanmıştır.
- Kullanıcı, kategori, ürün ve kampanya yönetimi modülerdir.
- Clean Code prensipleri benimsenmiştir.

---

## ☁️ Ürün & Medya Yönetimi

Ürün görselleri Google Cloud Storage üzerinde saklanmaktadır.

---

## 🛠️ Kurulum ve Çalıştırma

### 1. Repoyu Klonlayın
git clone https://github.com/kullanici-adiniz/repo-adi.git

### 2. Veritabanı Migration
appsettings.json dosyasında bağlantı bilgisini güncelleyin ve:

Update-Database

### 3. Google Cloud Storage
- Bucket oluşturun
- Service Account JSON anahtarını tanımlayın
- JSON dosyasını .gitignore içine ekleyin

### 4. Çalıştırma
dotnet run

---

## 🔗 Repo

https://lnkd.in/d_XiHNbD

### Proje Görselleri

<img width="1764" height="1453" alt="localhost_7057_Register_Index" src="https://github.com/user-attachments/assets/7cbd1636-551a-4847-9111-e8393a352d41" />

---

<img width="1918" height="965" alt="Ekran görüntüsü 2026-02-09 182856" src="https://github.com/user-attachments/assets/cae71304-e572-4e5e-8107-25dc91efbf76" />

---

<img width="1654" height="12259" alt="localhost_7057_Default_Index" src="https://github.com/user-attachments/assets/99a5ed84-4033-47bd-aaab-11642ae1813f" />

---

<img width="1654" height="3005" alt="localhost_7057_Shop_Index" src="https://github.com/user-attachments/assets/67a6e16a-e597-4ca5-b143-d75bf1d89697" />

---

<img width="1654" height="1744" alt="localhost_7057_Contact_Index" src="https://github.com/user-attachments/assets/f9ad53e3-6c98-4138-9012-f0d674dfd94c" />

---

<img width="1896" height="962" alt="Ekran görüntüsü 2026-02-09 182110" src="https://github.com/user-attachments/assets/dd009baf-a880-4c4e-9bcd-7ad8cff1dd44" />

---

<img width="1918" height="963" alt="Ekran görüntüsü 2026-02-09 182213" src="https://github.com/user-attachments/assets/516c0cc0-a11f-4c62-b02d-59790a9d6d28" />

---

<img width="1901" height="902" alt="Ekran görüntüsü 2026-02-09 181920" src="https://github.com/user-attachments/assets/959ae19e-fd6b-4cf7-b271-3b4f0499868d" />

---

<img width="1901" height="902" alt="Ekran görüntüsü 2026-02-09 181920" src="https://github.com/user-attachments/assets/e51c33fd-a707-4567-909f-cfc57acf71ff" />

---

<img width="1917" height="902" alt="Ekran görüntüsü 2026-02-09 181944" src="https://github.com/user-attachments/assets/4474528c-f801-4919-b27b-33166f543714" />

<img width="1898" height="906" alt="Ekran görüntüsü 2026-02-09 182006" src="https://github.com/user-attachments/assets/a21f26a2-5a96-4222-8df9-82a87ca2a10f" />

---

<img width="1902" height="903" alt="Ekran görüntüsü 2026-02-09 182024" src="https://github.com/user-attachments/assets/b940d26c-e739-4a8c-90b7-badb46b18324" />
