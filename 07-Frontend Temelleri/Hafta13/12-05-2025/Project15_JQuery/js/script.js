$(document).ready(function () {
  console.log("JQuery is ready!");

  // Seçiciler
  //const title = document.getElementById('title'); //jQuery hali aşağıda
  const title = $("#title");
  const contents = $(".content");
  const courseName = $("#course-name");
  const button = $("#buton");
  const box = $("#box");

  //Dom Manipülasyonları
  title.text("JQuery ile Değişien Başlık");

  console.log("Kurs Adı: ", contents.first().text());
  courseName.val("metin ayarlandı");
  // button.click(function () {
  //     courseName.val('');
  // })

  // title.css('color','green');
  // title.css('font-size','24px');

  title.css({
    color: "green",
    "font-size": "24px",
    padding: "5px",
    border: "1px solid blue",
  });

  // button.click(() =>{
  //     // title.addClass('emphasis');
  //     //.first().removeClass('content');
  //     title.toggleClass('emphasis'); // toggle yoksa ekler varsa siler
  // });

  //hide, show, toggle, fadeIn, FadeOut...

  button.click(() => {
    // box.toggle('slow');
    // box.toggle('fast');
    box.fadeToggle(2000, function () {  // burada fadetoggle ile 2 saniye effectli geçiş verdikten sonra function ile görünür yada gizli olmasını söylüyoruz.
        const isShow = box.is(':visible');
        console.log($(this));
        $(this).text(isShow ? "Box is visible" : "Box is hidden"); 
        $(courseName).val(isShow ? "Box is visible" : "Box is hidden");
    }); 
  });


  courseName.on('input', function (){ // kutu içerisine yazı yazıldıkça yazıyı yakalamasını sağlıyor.
    console.log(courseName.val());
    title.text($(this).val() || "jQuery Dersleri"); // biz şuan coursename içerisinde olduğumuz için tekrar coursename demek yerine this kelimesini kullanrak on manipüle edeceğimizi söylüyoruz.
  });
});



