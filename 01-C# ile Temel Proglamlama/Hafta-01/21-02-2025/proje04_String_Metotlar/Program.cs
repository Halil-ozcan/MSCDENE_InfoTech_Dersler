// Bu çlaışmada C#'taki string tiplerle ilgili yapılabilecek bir takım işlemleri öğreneceğiz.

// string firstName = "İsmail Burak";
// string lastName = "Günaydın";
// string fullName = $"{firstName} {lastName}";

// Console.WriteLine($"AD - SOYAD : {fullName}");
// Console.WriteLine($"FullName' in Uzunluğu : {fullName.Length}");
// Console.WriteLine($"FullName' in küçük harfli hali : {fullName.ToLower()}");
// Console.WriteLine($"FullName' in büyük harfli hali : {fullName.ToUpper()}");


// string address1 = "Yeni Umut Sitesi F Blok";
// string address2 = "No:45 D:16";
// string district = "Kadıköy";
// string city = "İstanbul";

// string resultAddress = $"{address1}\n{address2}\n{district} / {city}"; // \n bir sonraki satira geçirir.
// Console.WriteLine(resultAddress);


// string text = "Bügün hava çok soğuk. Kar yağışı çok etkili. Dışarı çıktığımda çok üşüyorum.  sevenler de var bu havaları ama ben sevmiyorum";
// // Text kelimesinin içinde "çok" kelimesi geçiyor mu?
// bool result = text.ToLower().Contains("Çok", StringComparison.CurrentCultureIgnoreCase); // Contains metoduda dahil olmak üzere c# içerisindeki pek çok operasyon Büyük/Küçük harfe duyarlıdır!!! Özel olarak belirtilmediği müddetçe bu durum böyle kabul edilmelidir.
// //StringComparison.CurrentCultureIgnoreCase büyük küçük harfe duyarlılığı kaldırıp ona göre arama yapar.
// Console.WriteLine(result);

// int id = 566317;
// string titleNews = "Fenerbahçe bir üst tura çıktı!"; // fenerbahce-bir-ust-tura-cikti
// string titleNewsUrl = titleNews.Replace(" ", "-"); //Fenerbahçe-bir-üst-tura-çıktı.
// titleNewsUrl = titleNewsUrl.ToLower();
// titleNewsUrl = titleNewsUrl.Replace("ç","c"); // fenerbahce-bir-üst-tura-cıktı!
// titleNewsUrl = titleNewsUrl.Replace("ü","u"); // fenerbahce-bir-ust-tura-cıktı!
// titleNewsUrl = titleNewsUrl.Replace("ı","i"); // fenerbahce-bir-ust-tura-cikti!
// titleNewsUrl = titleNewsUrl.Replace("!",""); // fenerbahce-bir-ust-tura-cikti
// titleNewsUrl = $"{titleNewsUrl}-{id}"; // fenerbahce-bir-ust-tura-cikti

// Console.WriteLine(titleNewsUrl);

// string text = "InfoTech Academy";
// Console.WriteLine(text.Substring(9));
// Console.WriteLine(text.Substring(4,4));
// int position = text.IndexOf("I");
// Console.WriteLine(position);

// string address1 = "Yeni Umut Sitesi Blok: F Blok";
// string address2 = "No:45 D:16";
// string district = "Kadıköy";
// string city = "İstanbul";

// string result =$"{address1.Substring(0, address1.IndexOf("Blok") - 1)}\n {address1.Substring(address1.IndexOf("Blok"))}\n{address2}\n{district} / {city}";

// Console.WriteLine(result);


string text = "Ali babanın çitliği!";
int position = text.IndexOf("Ş");
Console.WriteLine(position); // bulamazsa -1 değeri döndürür



