const header = document.createElement('header');

header.innerHTML = `
  <div class="header-container">
    <img class="profile-button" src="/assets/images/profile.svg" alt="Go to profile" />
    <div class="search-bar">
      <input id="search-input" type="text" placeholder="Поиск" />
      <img id="search-icon" src="/assets/images/search_icon.svg" alt="Search" />
    </div>
    <img class="main-page-button" src="/assets/images/logo.svg" alt="Back to main page" />
  </div>
`;
document.body.appendChild(header);


const searchInput = document.querySelector('#search-input');
const searchIcon = document.querySelector('#search-icon');
const ENTER = 13

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