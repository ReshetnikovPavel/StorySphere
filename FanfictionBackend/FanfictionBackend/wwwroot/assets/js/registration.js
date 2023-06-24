const form = document.querySelector('form');
form.addEventListener('submit', handleSubmit);

const email = document.getElementById('emailRegistration');
const password = document.getElementById('passwordRegistration');
const confirmPassword = document.getElementById('confirm-password');
const username = document.getElementById('name');

function handleSubmit(event) {
    event.preventDefault();

    const data = {
        email: email.value,
        username: username.value
    };
    registerUser(data, password.value)
        .catch(() => alert("Не удалось зарегистрироваться"));
}

function validatePassword() {
    if (password.value !== confirmPassword.value) {
        confirmPassword.setCustomValidity("Пароли не совпадают");
    } else {
        confirmPassword.setCustomValidity('');
    }
}

async function registerUser(data, password) {
    const response = await fetch(`/authors?password=${password}`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    });
    return await response.json();
}
