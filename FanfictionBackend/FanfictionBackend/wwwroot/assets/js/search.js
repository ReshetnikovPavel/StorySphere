const ENTER = 13

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


