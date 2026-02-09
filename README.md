CQRS & Mediator E-Commerce Project

Full-Stack .NET kapsamı sürecinde geliştirdiğim 10. proje olan bu çalışmada; modern yazılım mimarileri kullanılarak uçtan uca, ölçeklenebilir bir e-ticaret sistemi geliştirilmiştir.

MİMARİ YAKLAŞIM & SİSTEM TASARIMI

- CQRS (Command Query Responsibility Segregation):
Yazma (Command) ve okuma (Query) sorumlulukları net bir şekilde ayrıştırılmıştır.

- MediatR (Mediator Pattern):
Tüm iş akışları MediatR kullanılarak yönetilmiştir. Controller katmanı yalnızca istekleri iletirken, iş mantığı Handler katmanında işlenmiştir.

- Unit of Work & Transaction Yönetimi:
Veritabanı işlemleri tek bir transaction altında yönetilerek veri tutarlılığı sağlanmıştır.

- Observer Pattern:
Belirli aksiyonlara bağlı tetiklenen süreçler event bazlı ve genişletilebilir bir yapı ile kurgulanmıştır.

- Chain of Responsibility:
Doğrulama ve operasyon adımları zincir yapıda ele alınmıştır.

MODÜLER ADMIN PANEL
Admin paneli Area bazlı ve modüler olarak tasarlanmıştır.

ÜRÜN & MEDYA YÖNETİMİ
Ürün görselleri Google Cloud Storage üzerinde saklanmaktadır.

CLEAN CODE
DTO ve Repository yapıları kullanılmıştır.

KURULUM

1) Projeyi klonlayın
git clone https://github.com/kullanici-adiniz/repo-isminiz.git

2) Veritabanı
ConnectionStrings ayarlarını yapın ve:
Update-Database

3) Google Cloud Storage
Bucket oluşturun, Service Account ve JSON key alın.
JSON dosyasını GitHub'a eklemeyin.

TEKNOLOJİLER
ASP.NET Core MVC
Entity Framework Core
SQL Server
Google Cloud Storage

TEŞEKKÜR
Murat Yücedağ ve Erhan Gündüz

GitHub Repo:
https://lnkd.in/d_XiHNbD
