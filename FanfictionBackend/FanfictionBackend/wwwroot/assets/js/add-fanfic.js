// const form = document.querySelector('form');
// form.addEventListener('submit', handleSubmit);

const publish = document.querySelector('#publish');
const addImage = document.querySelector('#addArt');

const _name = document.getElementById('name');
const fandom = document.getElementById('fandom');
const persons = document.getElementById('persons');
const pairings = document.getElementById('pairings');
const rating = document.getElementById('rating');
const _focus = document.getElementById('focus');
const genre = document.getElementById('genre');
const warning = document.getElementById('warning');
const parameters = document.getElementById('parameters');
const translation = document.getElementById('translation');
const shortDescription = document.getElementById('shortDescription');
const note = document.getElementById('note');

publish.addEventListener("click", handleSubmit);
addImage.addEventListener("click", addArt);
function handleSubmit(event) {
    event.preventDefault();
    const data = {
        name: _name.value,
        fandom: fandom.value,
        persons: persons.value,
        pairings: pairings.value,
        rating: rating.value,
        focus: _focus.value,
        genre: genre.value,
        warnings: warning.value,
        isTranslation: Boolean(translation.value),
        description: shortDescription.value,
        authorNotes: note.value
    };
    publishFanfic(data)
        .then(fanfic => goToAddChapterPage(fanfic.id))
        .catch(() => alert("Не удалось опубликовать фанфик"));
}

async function publishFanfic(data) {
    const token = Cookies.get('session');

    // TODO: Сделать что-то, если токен undefined, потому что юзер еще не залогинился

    const response= await fetch('/fanfics', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${token}`,
          },
        body: JSON.stringify(data)
    });

    return await response.json()
}

function goToAddChapterPage(fanficId) {
    window.location.href = `/add-chapter.html?fanficId=${fanficId}`
}

function addArt(event) {
    event.preventDefault();
    const uploadBtn = document.getElementById('addArt');
    const fileList = document.getElementById('fileList');
    const uploadedFiles = new Set();

    uploadBtn.addEventListener('click', () => {
        const input = document.createElement('input');
        input.type = 'file';
        input.multiple = true;
        input.accept = '.png, .jpeg, .jpg';
        input.addEventListener('change', () => {
            const files = input.files;
            for (let i = 0; i < files.length; i++) {
                const file = files[i];
                if (!uploadedFiles.has(file.name)) {
                    uploadedFiles.add(file.name);
                    const li = document.createElement('li');
                    li.textContent = file.name;
                    fileList.appendChild(li);
                }
            }
        });
        input.click();
    });

    fileList.addEventListener('click', (event) => {
        if (event.target.tagName === 'LI') {
            const fileName = event.target.textContent;
            uploadedFiles.delete(fileName);
            event.target.remove();
        }
    });
}
