const form = document.querySelector("form");

const inputFullName = document.getElementById("full-name");
const inputEmail = document.getElementById("email");
const inputSubject = document.getElementById("subject");
const inputMessage = document.getElementById("message");

const errorFullName = document.getElementById("error-full-name");
const errorEmail = document.getElementById("error-email");
const errorSubject = document.getElementById("error-subject");
const errorMessage = document.getElementById("error-message");

let isValidForm = true;
// Hata gösterme fonksiyonu
function showError(inputElement, errorElement, message) {
  inputElement.classList.add("error");
  errorElement.textContent = message;
}

// Hata temizleme fonksiyonu
function clearError(inputElement, errorElement) {
  errorElement.innerText = "";
  inputElement.classList.remove("error");
}

// Email geçerli mi?
function isValidEmail(email) {
  const regexCode = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
  let result = regexCode.test(String(email).toLowerCase());
  return result;
}

// Ad Soyad validasyonu
function validateFullName() {
  // Önceki hataları temizle
  clearError(inputFullName, errorFullName);
  let fullName = inputFullName.value.trim();
  if (fullName == "") {
    showError(inputFullName, errorFullName, "Ad Soyad zorunludur!");
    inputFullName.value = fullName;
    isValidForm = false;
    return;
  }

  if (fullName.length < 5) {
    showError(
      inputFullName,
      errorFullName,
      "Ad soyad en az 5 karakter olmalıdır!"
    );
    inputFullName.value = fullName;
    isValidForm = false;
    return;
  }
  isValidForm = true;
}

// Email validasyonu
function validateEmail() {
  clearError(inputEmail, errorEmail);
  let email = inputEmail.value.trim();
  if (email == "") {
    showError(inputEmail, errorEmail, "Email zorunludur!");
    inputEmail.value = email;
    isValidForm = false;
    return;
  }
  if (!isValidEmail(email)) {
    showError(inputEmail, errorEmail, "Email adresi geçersizdir!");
    inputEmail.value = email;
    isValidForm = false;
    return;
  }
  isValidForm = true;
}

// Başlık validasyonu
function validateSubject() {
  // Önceki hataları temizle
  clearError(inputSubject, errorSubject);
  let subject = inputSubject.value.trim();
  if (subject == "") {
    showError(inputSubject, errorSubject, "Başlık zorunludur!");
    inputSubject.value = subject;
    isValidForm = false;
    return;
  }

  if (subject.length < 10) {
    showError(
      inputSubject,
      errorSubject,
      "Başlık en az 10 karakter olmalıdır!"
    );
    inputSubject.value = subject;
    isValidForm = false;
    return;
  }
  isValidForm = true;
}

// Mesaj validasyonu
function validateMessage() {
  // Önceki hataları temizle
  clearError(inputMessage, errorMessage);
  let message = inputMessage.value.trim();
  if (message == "") {
    showError(inputMessage, errorMessage, "Mesaj zorunludur!");
    inputMessage.value = message;
    isValidForm = false;
    return;
  }

  if (message.length < 10) {
    showError(inputMessage, errorMessage, "Mesaj en az 10 karakter olmalıdır!");
    inputMessage.value = message;
    isValidForm = false;
    return;
  }
  isValidForm = true;
}

// Form submit
form.onsubmit = function (e) {
  e.preventDefault();
  validateFullName();
  validateEmail();
  validateSubject();
  validateMessage();
  if (isValidForm) {
    form.submit();
  }
};
