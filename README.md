# Skor Yakalama Oyunu (Console Based)

Bu proje, C# programlama dili ve .NET Core kullanılarak geliştirilmiş, terminal tabanlı interaktif bir skor toplama oyunudur.

## Oyunun Amacı
Oyun başladığında kullanıcıdan kaç adet yıldız (`*`) düşmesini istediği alınır. Oyuncu, terminalin alt kısmındaki `@` karakterini yön tuşlarıyla hareket ettirerek yukarıdan düşen yıldızları yakalamaya çalışır.

## Özellikler
- **Dinamik Zorluk:** Kullanıcı düşecek toplam yıldız sayısını kendisi belirler.
- **Başarı Oranı Hesaplama:** Oyun sonunda yakalanan yıldız miktarına göre başarı yüzdesi (%) hesaplanır.
- **Log Sistemi:** Oyunun her anı (tuş vuruşları, nesne hareketleri, çarpışmalar) `game_log.txt` dosyasına saniyelik olarak kaydedilir.
- **Hata Yönetimi:** Geçersiz girişlere veya terminal boyutu değişimlerine karşı dayanıklı bir altyapı.



