// for(let i = 0; i<5; i++){
//     console.log(`Merhaba Dünya ${i + 1 }`);
// }

// let studentNames = ["Ali","Ayşe", "Kenan"];
// for (let i = 0; i < studentNames.length; i++) {
//     const element = studentNames[i];
//     console.log(element);
// }


// let studentNames = ["Ali","Ayşe", "Kenan"];

// let count = 0;

// while (count<studentNames.length) {
//     console.log(`Hoşgeldin ${studentNames[count++]}`);
// }

// let studentNames = ["Ali","Ayşe", "Kenan"];
// for(const name of studentNames)
// {
//     console.log(name);
// }

// let studentNames = ["Ali","Ayşe", "Kenan"];
// studentNames.forEach((element , i) => {
//     console.log(`${i+1}.kişi: ${element}`);
// });

 let studentNames = ["Ali","Ayşe", "Kenan"];  // yukardaki foreach alternatif kullanım şeklidir.
  studentNames.forEach(function (element, i) {     
     console.log(`${i+1}.kişi: ${element}`);
 });


