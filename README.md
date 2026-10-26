# Çok Fonksiyonlu Yardımcı Araçlar ve Hesaplama Uygulaması (.NET MAUI)

## Proje Hakkında

Bu proje, **Görsel Programlama** dersi kapsamında .NET MAUI (Multi-platform App UI) ve C# kullanılarak geliştirilmiş, çok sayfalı ve modern bir masaüstü/mobil yardımcı araçlar uygulamasıdır.

Uygulama; finansal hesaplamalar, sağlık ölçümleri, harici API'den anlık hava durumu verisi çekme ve kullanıcı deneyimini zenginleştiren dinamik tema yönetimi olmak üzere **4 ana modülden** oluşmaktadır:

1. **Kredi Hesaplama Modülü:**
   * Kullanıcıdan alınan ana para, vade süresi (ay) ve faiz oranı girdilerine göre aylık taksit tutarı, toplam geri ödeme ve toplam faiz yükünü hesaplayan finansal analiz aracı.
2. **Hava Durumu Modülü:**
   * Harici REST API servislerine `HttpClient` ile asenkron istek atarak seçilen şehir veya konuma ait güncel hava durumu, sıcaklık ve atmosferik verileri anlık olarak listeleyen modül.
3. **Vücut Kitle İndeksi (VKİ / BMI) Hesaplama Modülü:**
   * Kullanıcının boy ve kilo verilerini alarak vücut kitle indeksini hesaplayan; Dünya Sağlık Örgütü (WHO) standartlarına göre zayıf, normal, fazla kilolu veya obezite risk kategorisini dinamik olarak görselleştiren sağlık aracı.
4. **Dinamik Tema Belirleme (Açık / Koyu / Sistem Teması):**
   * Kullanıcının isteğine göre uygulamanın renk temasını (Light/Dark Theme) anlık olarak değiştirebilen ve tercihleri yerel olarak koruyan tema yönetim sistemi.

---

## Temel Özellikler

* **Çok Platformlu Desteği:** Tek bir C# ve XAML kod tabanı ile Windows, Android ve iOS ortamlarında tutarlı çalışan duyarlı (responsive) arayüz tasarımı.
* **REST API Entegrasyonu & JSON Ayrıştırma:**
  * Asenkron programlama (`async/await`) mimarisi.
  * Hava durumu servisinden dönen JSON yanıtlarının C# modellerine serileştirilmesi (deserialization).
* **Matematiksel ve Finansal Hesaplama Motoru:**
  * Kredi faiz formülleri ve VKİ algoritmalarının veri doğrulama (validation) kurallarıyla hatasız işletilmesi.
* **Kullanıcı Arayüzü & Tema Yönetimi:**
  * XAML kaynak sözlükleri (ResourceDictionary) ve dinamik kaynak bağlama (DynamicResource) ile anlık tema geçişi.

---
## Kullanılan Teknolojiler

* .NET MAUI & C#
* XAML
* REST API (HttpClient & JSON)
* Visual Studio 2022

