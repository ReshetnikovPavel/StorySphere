function createLoginModal() {
    const loginModal = document.createElement('modal');
    loginModal.innerHTML = `
        <div class="modal">
            <div class="modal-content">
                <img src="/assets/images/cross-icon.svg" class="close-button"/>
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
                    <button>Войти</button>
                    <button>Зарегистрироваться</button>
                </form>
            </div>
        </div>
    `;
    document.body.appendChild(loginModal);
    return loginModal;
};

function createHeader() {
    const header = document.createElement('header');
    header.innerHTML = `
    <div class="header-container">
        <img class="main-page-button" src="/assets/images/logo.svg" alt="Back to main page" />
        <div class="search-bar">
            <input id="search-input" type="text" placeholder="Поиск" />
            <img id="search-icon" src="/assets/images/search_icon.svg" alt="Search" />
        </div>
        <img class="profile-button" src="/assets/images/profile.svg" alt="Go to profile" /> 
    </div>
    `;
    document.body.appendChild(header);
    return header;
}

const ENTER = 13;

const header = createHeader();
// const loginModal = createLoginModal();

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