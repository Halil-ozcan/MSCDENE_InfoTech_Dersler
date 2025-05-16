// DOM: Document Object Model

// const mainHeader = document.getElementById('main-header');
// const sendButton = document.getElementById('send-button');
// const userName = document.getElementById('user-name');
// const paragraphs = document.getElementsByName('paragraph'); // bütün paragrafları alır.


// sendButton.addEventListener('click',makeRed);

// function makeRed() {
//     if(userName.value == "")
//         mainHeader.style.color = "red";
// }

// console.log(mainHeader);


// const  mainHeader = document.querySelector("#main-header");
// const  paragraphs = document.querySelectorAll(".paragraph"); // Tüm paragraf sınıflarını alır.

// paragraphs.forEach((p , i)=> {
//     if(i %2 == 0)
//     {
//         p.style.backgroundColor = "orange";
//     }else
//     {
//         p.style.backgroundColor = "blue";
//     }
// });

// console.log(mainHeader);
// console.log(paragraphs);

// const btnSend = document.getElementById('send-button');
// // btnSend.innerText = '<strong>Kaydet</strong>';
// btnSend.innerHTML += ' ve Çık';
// console.log(btnSend);


function generateGUID() {
  return "xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx".replace(/[xy]/g, function (c) {
    const r = (Math.random() * 16) | 0;
    const v = c === "x" ? r : (r & 0x3) | 0x8;
    return v.toString(16);
  });
}


const taskTitle = document.querySelector('#task-title'); // getElementById de kullanılabilirdi.
const btnSave = document.querySelector('#btn-save');
const taskList = document.querySelector('#task-list');

btnSave.onclick = function () {
  console.log("Selam");
  if (taskTitle.value == "") {
    alert("Görev açıklaması boş olamaz!");
    return;
  }
  let idValue = generateGUID();
  taskList.innerHTML += `
        <div class="task-item">
            <input onchange="changeStatus('${idValue}')" id="task-${idValue}" type="checkbox">
            <li id="task-title-${idValue}">${taskTitle.value}</li>
        </div>
    `;
};


function changeStatus(id) {
  console.log(`task-title-${id}`);
  const li = document.getElementById(`task-title-${id}`);
  console.log(li);
  li.classList.toggle("completed");
}