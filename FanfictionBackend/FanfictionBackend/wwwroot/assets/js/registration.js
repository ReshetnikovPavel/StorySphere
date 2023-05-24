const form = document.querySelector('form');
form.addEventListener('submit', handleSubmit);

const email = document.getElementById('email');
const password = document.getElementById('password');
const confirmPassword = document.getElementById('confirm-password');
const name = document.getElementById('name');

function handleSubmit(event) {
    event.preventDefault();
    
    const data = {
        email: email.value,
        password: password.value,
        name: name.value
    };
    registerUser(data)
        .catch(() => alert("Не удалось зарегистрироваться"));
}

function validatePassword() {
    if (password.value !== confirmPassword.value) {
        confirmPassword.setCustomValidity("Пароли не совпадают");
    } else {
        confirmPassword.setCustomValidity('');
    }
}

async function registerUser(data) {
    const response = await fetch('/authors', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    });
    return await response.json();
}
