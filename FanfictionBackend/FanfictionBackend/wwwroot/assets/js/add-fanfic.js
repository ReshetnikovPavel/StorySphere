// const form = document.querySelector('form');
// form.addEventListener('submit', handleSubmit);

const publishBtn = document.querySelector('#publish');
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
const uploadedFiles = new Set();

// publish.addEventListener("click", () => {
//     const isFull = true;
//     const requiredFields = document.querySelectorAll('.required'); // выбираем все поля с классом "required"

//     for (let i = 0; i < requiredFields.length; i++) {
//       if (requiredFields[i].value === '') {
//         isFull = false; // если хотя бы одно поле пустое, возвращаем false
//       }
//     }

//     if (isFull) {
//         handleSubmit;
//         return;
//     }

// });

publishBtn.addEventListener("click", handleSubmit);
addImage.addEventListener("click", addArt);

async function handleSubmit(event) {
    event.preventDefault();
    const requiredFields = document.querySelectorAll('[required]'); // выбираем все поля с классом "required"
    console.log(requiredFields.length);

    for (let i = 0; i < requiredFields.length; i++) {
        if (requiredFields[i].value === '') {
            return;
        }
    }

    const data = {
        title: _name.value,
        fandom: fandom.value,
        characters: persons.value,
        pairings: pairings.value,
        ageLimit: rating.value,
        category: _focus.value,
        genre: genre.value,
        warnings: warning.value,
        isTranslation: translation.checked,
        description: shortDescription.value,
        authorNotes: note.value
    };
    try {
        const fanfic = await publishFanfic(data);
        await Promise.all([publishImages(fanfic.id)]);
        goToAddChapterPage(fanfic.id);
    } catch (e) {
        alert("Не удалось опубликовать фанфик или загрузить изображения: " + e);
    }
}

async function publishImages(fanficId) {
    const token = Cookies.get('sessionToken');

    if (token === undefined) {
        window.location.href = 'registration.html';
        return;
    }

    const formData = new FormData();
    for (const file of uploadedFiles) {
        formData.append('images[]', file, file.name);
    }

    const response = await fetch(`/images?fanficId=${fanficId}`, {
        method: 'POST',
        headers: {
            'Authorization': `Bearer ${token}`,
        },
        body: formData
    });

    return await response.json()
}


async function publishFanfic(data) {
    const token = Cookies.get('sessionToken');

    if(token === undefined) {
        window.location.href = 'registration.html';
        return;
    }

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


    uploadBtn.addEventListener('click', () => {
        const input = document.createElement('input');
        input.type = 'file';
        input.multiple = true;
        input.accept = '.png, .jpeg, .jpg';
        input.addEventListener('change', () => {
            const files = input.files;
            for (let i = 0; i < files.length; i++) {
                const file = files[i];
                if (!uploadedFiles.has(file)) {
                    uploadedFiles.add(file);
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
