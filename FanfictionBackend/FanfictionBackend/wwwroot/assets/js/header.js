const ENTER = 13;

initHeader();

window.addEventListener("load", () => {
    initLoginModal();
});

function initHeader() {
    const header = createHeader();
    
    const searchInput = document.querySelector('#search-input');
    const searchIcon = document.querySelector('#search-icon');

    searchIcon.addEventListener('click', event => {
        search(searchInput.value);
    });
    
    searchInput.addEventListener('keydown', event => {
        if (event.keyCode === ENTER) {
            event.preventDefault();
            search(searchInput.value);
        }
    });
}

function initLoginModal() {
    const loginModal = createLoginModal();

    const closeButton = document.querySelector('#login-close-button');
    const registerButton = document.querySelector('#register-button');
    const profileButton = document.querySelector('#profile-button');
    const modal = document.querySelector('.modal');

    profileButton.addEventListener("click", function() {
        const username = Cookies.get("username");
        if (username === undefined) {
            openModal(loginModal);
        }
        else {
            window.location.href = `/profile.html?username=${username}`;
        }        
    });
    
    closeButton.addEventListener("click", function() {
        closeModal(loginModal);
    });
    
    registerButton.addEventListener("click", function(e) {
        e.preventDefault();
        location.href='/registration.html';
        closeModal(loginModal);
    });

    window.addEventListener("click", function handleClick(e) {
        if (e.target == modal) {
            closeModal(loginModal);
        }
    });

    const email = document.getElementById('email');
    const password = document.getElementById('password');

    const loginButton = document.querySelector('#login-button');

    loginButton.addEventListener("click", function(e) {
        e.preventDefault();
        login(email.value, password.value);
        closeModal(loginModal);
    });
}

async function login(email, password) {
    try {
        userData = await fetchSession(email, password);
        Cookies.set('sessionToken', userData.token, {sameSite: 'strict'});
        Cookies.set('username', userData.user.username, {sameSite: 'strict'});
        window.location.href = `/profile.html?username=${userData.user.username}`;
    }
    catch (err) {
        alert('Неверная почта или пароль. Попробуйте еще раз!');
        // TODO: Поменять с алерта на что-то адекватное
    }
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

function createHeader() {
    const header = document.createElement('header');
    header.innerHTML = `
    <div class="header-container">
        <img onclick="location.href='/';" class="main-page-button" src="/assets/images/logo.svg" alt="Back to main page" />
        <div class="search-bar">
            <input id="search-input" type="text" placeholder="Поиск" />
            <img id="search-icon" src="/assets/images/search_icon.svg" alt="Search" />
        </div>
        <img id="profile-button" class="profile-button" src="/assets/images/profile.svg" alt="Go to profile" /> 
    </div>
    `;
    document.body.appendChild(header);
    return header;
}

function createLoginModal() {
    const loginModal = document.createElement('modal');
    loginModal.innerHTML = `
        <div id="login-modal" class="modal">
            <div class="modal-content">
                <img src="/assets/images/cross-icon.svg" class="close-button" id="login-close-button"/>
                <h1>Вход</h1>
                <form>
                    <div class="field">
                        <label for="email">Электронная почта:</label>
                        <input type="email" id="email" required/>
                    </div>
                    <div class="field">
                        <label for="password">Пароль:</label>
                        <input type="password" id="password" required/>
                    </div>
                    <button id="login-button">Войти</button>
                    <button id="register-button">Зарегистрироваться</button>
                </form>
            </div>
        </div>
    `;
    loginModal.style.display = "none";
    document.body.appendChild(loginModal);
    return loginModal;
};

function search(fanficName) {
    fetch(`/fanfic?title=${fanficName}`)
        .then(response => {
            if (response.ok) {
                alert("Такой фанфик существует!")
            } else if (response.status === 404) {
                alert("Фанфик не существует")
            } else {
                alert(response.statusText)
            }
        })
        .catch(error => {
            console.log('Error:', error);
        });
}

function closeModal(modal) {
    modal.style.display = "none";
}

function openModal(modal) {
    modal.style.display = "block";
}