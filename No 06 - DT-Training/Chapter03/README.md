# Şu Web Dedikleri Şey de Neymiş

.Net Core ile Web uygulamalarını birkaç şekilde geliştirebiliriz. Asp.Net Core Razor Pages ve MVC _(Model View Controller)_ temelli web siteleri en çok kullanılanlar arasındadır. İzleyen örneklerde çok temel seviyede Razor ve MVC uygulamaları oluşturulmaktadır.

## Gerekli Northwind EF Uygulamasının İnşası

Her iki Web uygulaması da örnek bir EF _(Entity Framework)_ projesini referans ederek kullanmaktadır. Bu projeyi aşağıdaki şekilde oluşturup gerekli paket ve dosyaları ekleyebiliriz.

```bash
dotnet new classlib -o NorthwindLib
cd NorthwindLib
dotnet add package Microsoft.EntityFrameworkCore.SQLite
rm Class1.cs
touch Category.cs Product.cs Northwind.cs
```

Bu kütüphane Northwind için Product ve Category veri setlerini işaret edecek şekilde tasarlanmıştır. Sonraki Web projelerinde EF destekli istenen veritabanları ile kullanılabilir.

## Razor Pages Uygulamasının İnşası

Uygulamayı başlangıçta aşağıdaki gibi oluşturabiliriz.

```bash
# Razor projesini boş bir Web sitesi şeklinde oluşturuyoruz
dotnet new web -o GameWorldWeb

# Projeye HTTPS desteği eklendikten sonra gerekli sertifika tanımı
dotnet dev-certs https --trust

# Statik sayfa kullanımı örneği için eklendiler
mkdir wwwroot
touch wwwroot/index.html

# Razor sayfa örnekleri için eklendi
mkdir Pages
mv wwwroot/index.html Pages/index.cshtml

# Ortak Şablon için eklenir
touch Pages/_ViewStart.cshtml
mkdir Pages/Shared
touch Pages/Shared/_Layout.cshtml

# _Layout.cshtml yazıldıktan sonra tasarlanan sayfalar
touch Pages/companies.cshtml Pages/companies.cshtml.cs

# Entity Framework projesini kullanabilmek için diğer projeyi referans ediyoruz.
dotnet add reference ../NorthwindLib/NorthwindLib.csproj

# Migration işlemleri
# startup.cs içerisinde migration assembly seçimi yaptığımıza dikkat edin
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef migrations add initial
dotnet ef database update
```

## MVC Uygulamasının İnşası

Uygulamayı oluşturmak için aşağıdaki terminal komutu ile işe başlayailiriz.

```bash
dotnet new mvc --auth Individual -o GamerMVC
```

Yukarıdaki gibi uygulamanın oluşturulması tamamlandıktan sonra _dotnet run_ komutu ile çalıştırıp kişisel e-posta adresimiz ile sisteme kayıt olabiliriz. Bu Membership tipi --auth Individual parametresi ile eklenmiştir. Porjenin ilk çalıştırılmasından sonra bir güzel sağı solu detaylıca anlatılır. Örneğin temel klasör yapısı ile başlanı Dependency Injection'dan çıkılabilir.

- Areas klasöründe AspNet Core Identity için gerekli dosyalar durur.
- Bin klasöründe uygulamanın derlenmiş kütüphaneleri yer alır.
- Controllers klasöründeki sınıflar View içerisindeki sayfalar tarafından kullanılırlar ve genel olarak Model ile View arasındaki ilişkili ele alırlar.
- Data klasöründe Entity Framework Context sınıfı ve Migration planları yer alır. Varsayılan olarak proje ilk açıldığında SQLite kullanacak şekilde ayağa kalkar.
- Uygulamanın Kestrel, IIS gibi çalışma zamanı web ortamı yayıncıları ile ilgili bilgileri Properties klasöründeki launchSettings.json dosyasında tutulur.
- Views klasöründe C# ve HTML'in birlikte harmanlandığı Razor Pages dosyaları yer alır. Önyüzün inşaası burada gerçekleşir. Sayfaların çalışacağı modeller, Models dizininde yer alır.
- Bir web uygulamasının olmassa olmaz parçalarından birisi css, javascript gibi unsurlardır. Bunlar wwwroot altındaki ilgili klasörlerde yer alır.
- appsettings içerisinde SQLite veritabanının adı ve adresi yer alır. Bunun dışında Loglama ile ilgili ayarlar da bulunur.
- Uygulama varsayılan haliyle Microsoft Identity Server üzerinden Membership _(Üyelik Sistemi)_ yönetimini destekler. Register adımlarından sonra app.db içerisindeki AspNetUsers tablosuna kullanıcı atıldığı görülür.
- Startup.cs dosyasındaki ConfigureServices ve Configure metotları incelemeye değerdir. _(Eğitime katılanlarla buradaki kodlar üzerinde durulması gerekir)_
- Controller sınıflarının ihtiyacı olan servisler Constructor üzerinden enjekte edilirler. DotNetCore dahili Dependency Injection mekanizmasına sahiptir. Bu servislerin register edilmesi için ConfigureServices metodu kullanılır.
- URL yönlendirme mekanizması MapControllerRoute üzerinden sağlanır ve neredeyse her request ele alınabilir. Aşağıdaki tablo işi kavramak için yeterlidir.

| URL                         | Controller |  Action  |      ID     |
|-----------------------------|------------|:--------:|:-----------:|
| /                           | Home       |   Index  |             |
| /Player                     | Player     |   Index  |             |
| /Player/Zero                | Player     |   Zero   |             |
| /Games                      | Games      |   Index  |             |
| /Games/Detail               | Games      |  Detail  |             |
| /Games/Detail/791           | Games      |  Detail  |     791     |
| /Games/Blizzard/Hearthstone | Games      | Blizzard | Hearthstone |

>NotCompletedException();

### Çalışma Zamanı _(Her İki Uygulama İçin)_

```bash
dotnet run
```

Ardından <http://localhost:5000> adresine gidilir.

## Bölüm Soruları

- Razor ve MVC projelerindeki Startup sınıfının görevi nedir?
- Projeleri SQLite yerine SQLServer ile çalışacak şekilde ayarlamak için nerelerde nasıl ayarlamalar yaparsınız?
- Companies Razor sayfası backend tarafına nasıl bağlanabildi?
- HSTS'in kullanım amacı nedir?

>NotCompletedException();

## MiniLab Çalışması

- Razor projesinde yeni oyun ekleyebileceğimiz _(eklerken yapımcıyı da seçebileceğimiz)_ bir cshtml sayfası geliştiriniz.
- Razor projesinin anasayfasında rastgele günün oyun firması ve oyunlarını gösterecek geliştirmeleri yapınız.

>NotCompletedException();