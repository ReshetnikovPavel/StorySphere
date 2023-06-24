const form = document.querySelector('form');
form.addEventListener('submit', handleSubmit);

const email = document.getElementById('emailRegistration');
const password = document.getElementById('passwordRegistration');
const confirmPassword = document.getElementById('confirm-password');
const username = document.getElementById('name');

async function handleSubmit(event) {
    event.preventDefault();

    const data = {
        email: email.value,
        username: username.value
    };
    const ok = await registerUser(data, password.value);

    if(ok) {
        login(email.value, password.value);
    }
}

async function login(email, password) {
    console.log(email);
    console.log(password);
    userData = await fetchSession(email, password);
    Cookies.set('sessionToken', userData.token, {sameSite: 'strict'});
    Cookies.set('username', userData.user.username, {sameSite: 'strict'});
    window.location.href = `/profile.html?username=${userData.user.username}`;
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
    
    if (!response.ok) {
        throw new Error(`HTTP error! Status: ${response.status}`);
      }

    return response.ok;
}

async function fetchSession(email, password) {
    const url = `/session?email=${email}&password=${password}`;
    const response = await fetch(url);
  
    if (!response.ok) {
      throw new Error(`HTTP error! Status: ${response.status}`);
    }
  
    const data = await response.json();
    return data;
}