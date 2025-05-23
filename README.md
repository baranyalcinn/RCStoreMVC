# RCStoreMVC - E-Ticaret Uygulaması

RCStoreMVC, ASP.NET MVC framework'ü kullanılarak geliştirilmiş kapsamlı bir e-ticaret uygulamasıdır. Kullanıcı yönetimi, ürün katalogu, sepet işlemleri ve sipariş yönetimi gibi temel e-ticaret özelliklerini içerir.

## 📋 İçindekiler

- [Özellikler](#özellikler)
- [Teknolojiler](#teknolojiler)
- [Kurulum](#kurulum)
- [Kullanım](#kullanım)
- [Proje Yapısı](#proje-yapısı)
- [Katkıda Bulunma](#katkıda-bulunma)
- [Lisans](#lisans)

## ✨ Özellikler

### 🔐 Kullanıcı Yönetimi
- Kullanıcı kayıt ve giriş sistemi
- ASP.NET Identity ile güvenli kimlik doğrulama
- Rol tabanlı yetkilendirme (Admin/User)
- Kullanıcı profil yönetimi

### 🛍️ Ürün Katalogu
- Kategori bazlı ürün organizasyonu
- Ürün listeleme ve detay görüntüleme
- Ana sayfa öne çıkan ürünler
- Admin panel ile ürün yönetimi (CRUD işlemleri)

### 🛒 Sepet İşlemleri
- Session tabanlı sepet yönetimi
- Ürün ekleme/çıkarma/temizleme
- Sepet özeti görüntüleme
- Toplam fiyat hesaplama

### 📦 Sipariş Yönetimi
- Sipariş oluşturma ve takip
- Kargo bilgileri yönetimi
- Sipariş durumu güncelleme
- Admin panel ile sipariş yönetimi

### 👨‍💼 Admin Paneli
- Ürün yönetimi (Ekleme, düzenleme, silme)
- Kategori yönetimi
- Sipariş yönetimi ve durum güncelleme
- Kullanıcı rol yönetimi

## 🛠️ Teknolojiler

- **Framework:** ASP.NET MVC 5
- **Veritabanı:** Entity Framework (Code First)
- **Kimlik Doğrulama:** ASP.NET Identity
- **Frontend:** HTML5, CSS3, JavaScript, Bootstrap
- **Session Yönetimi:** ASP.NET Session State
- **Güvenlik:** OWIN Authentication

## 🚀 Kurulum

### Gereksinimler
- Visual Studio 2019 veya üstü
- .NET Framework 4.7.2 veya üstü
- SQL Server LocalDB veya SQL Server
- IIS Express

### Adımlar

1. **Projeyi klonlayın:**
   ```bash
   git clone [repository-url]
   cd RCStoreMVC
   ```

2. **Veritabanı bağlantısını yapılandırın:**
   - `web.config` dosyasında connection string'i düzenleyin
   ```xml
   <connectionStrings>
     <add name="DefaultConnection" 
          connectionString="Data Source=(LocalDb)\MSSQLLocalDB;..." 
          providerName="System.Data.SqlClient" />
   </connectionStrings>
   ```

3. **Package Manager Console'da veritabanını oluşturun:**
   ```
   Enable-Migrations
   Add-Migration InitialCreate
   Update-Database
   ```

4. **Projeyi derleyin ve çalıştırın:**
   - Visual Studio'da F5 tuşuna basın veya
   - `Build` > `Build Solution` menüsünden projeyi derleyin

## 🎯 Kullanım

### Kullanıcı İşlemleri

1. **Kayıt Olma:**
   - Ana sayfadan "Kayıt Ol" linkine tıklayın
   - Gerekli bilgileri doldurun
   - Otomatik olarak "user" rolü atanır

2. **Giriş Yapma:**
   - "Giriş Yap" linkine tıklayın
   - Kullanıcı adı ve şifre ile giriş yapın

3. **Alışveriş:**
   - Ürünleri kategorilere göre görüntüleyin
   - Sepete ürün ekleyin
   - Sepet özeti kontrolü yapın
   - Checkout işlemi ile sipariş verin

### Admin İşlemleri

1. **Admin Girişi:**
   - Admin rolüne sahip kullanıcı ile giriş yapın
   - Admin paneli menüleri görünür hale gelir

2. **Ürün Yönetimi:**
   - `/Product` sayfasından ürün ekleyin, düzenleyin, silin
   - Ürün kategorilerini belirleyin
   - Ana sayfa görünürlüğünü ayarlayın

3. **Sipariş Yönetimi:**
   - `/Order` sayfasından siparişleri görüntüleyin
   - Sipariş durumlarını güncelleyin (Onaylama/İptal)

## 📁 Proje Yapısı

```
RCStoreMVC/
├── Controllers/
│   ├── AccountController.cs      # Kullanıcı kimlik doğrulama
│   ├── CartController.cs         # Sepet işlemleri
│   ├── CategoryController.cs     # Kategori yönetimi (Admin)
│   ├── HomeController.cs         # Ana sayfa ve ürün listeleme
│   ├── OrderController.cs        # Sipariş yönetimi (Admin)
│   └── ProductController.cs      # Ürün yönetimi (Admin)
├── Models/
│   ├── AdminOrderModel.cs        # Admin sipariş görünüm modeli
│   ├── Cart.cs                   # Sepet ve sepet satırı modelleri
│   ├── LinksModel.cs            # Link modeli
│   ├── Login.cs                 # Giriş form modeli
│   ├── ProductModel.cs          # Ürün görünüm modeli
│   ├── Register.cs              # Kayıt form modeli
│   ├── ShippingDetails.cs       # Kargo bilgileri modeli
│   └── UserOrderModel.cs        # Kullanıcı sipariş modeli
├── Entity/                      # Entity Framework modelleri
├── Identity/                    # ASP.NET Identity yapılandırması
└── Views/                       # MVC görünüm dosyaları
```

## 🔧 Önemli Sınıflar ve Metodlar

### CartController
- `GetCart()`: Session'dan sepet bilgisini alır
- `AddToCart()`: Sepete ürün ekler
- `RemoveFromCart()`: Sepetten ürün çıkarır
- `Checkout()`: Sipariş oluşturma işlemi

### AccountController
- `Register()`: Yeni kullanıcı kayıt işlemi
- `Login()`: Kullanıcı giriş işlemi
- `Index()`: Kullanıcının sipariş geçmişi

### HomeController
- `GetHomePageProducts()`: Ana sayfa ürünlerini getirir
- `List()`: Kategori bazlı ürün listeleme
- `GetProductQuery()`: Ürün sorgulama metodu

## 🔒 Güvenlik Özellikleri

- **Anti-Forgery Token**: Form güvenliği için CSRF koruması
- **Role-based Authorization**: Controller ve action seviyesinde yetkilendirme
- **Input Validation**: Model bazlı girdi doğrulama
- **Secure Authentication**: ASP.NET Identity ile güvenli kimlik doğrulama

## 📝 Notlar

- Sepet bilgileri session'da saklanır, veritabanında tutulmaz
- Sipariş numaraları rastgele 6 haneli "P" prefiksi ile oluşturulur
- Admin işlemleri için "admin" rolü gereklidir
- Ürün fiyatları `double` tipinde saklanır

## 🤝 Katkıda Bulunma

1. Bu repository'yi fork edin
2. Yeni bir feature branch oluşturun (`git checkout -b feature/AmazingFeature`)
3. Değişikliklerinizi commit edin (`git commit -m 'Add some AmazingFeature'`)
4. Branch'inizi push edin (`git push origin feature/AmazingFeature`)
5. Bir Pull Request oluşturun

## 📄 Lisans

Bu proje MIT lisansı altında lisanslanmıştır. Detaylar için `LICENSE` dosyasına bakınız.

## 📞 İletişim

Proje hakkında sorularınız için issue açabilir veya iletişime geçebilirsiniz.

---

**Not:** Bu proje eğitim amaçlı geliştirilmiştir. Production ortamında kullanım öncesi güvenlik ve performans testleri yapılması önerilir.
