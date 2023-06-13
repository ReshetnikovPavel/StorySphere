
const draftBtn = document.querySelector('#draft');
const publishBtn = document.querySelector('#publish');

publishBtn.addEventListener("click", publishSubmit);
draftBtn.addEventListener("click", saveDraftSubmit);

const _name = document.getElementById('name');
const content = document.getElementById('content');

function saveDraftSubmit(event) {
    event.preventDefault();
    if (_name.value.trim() === '') {
        alert('Введите название главы');
        return;
    }
    
    const data = {
        name: _name.value,
        content: content.value,
    };
    saveDraft(data)
        .catch(() => alert("Не удалось сохранить черновик"));
}

function publishSubmit(event) {
    event.preventDefault();
    if (_name.value.trim() === '') {
        alert('Введите название главы');
        return;
    }
    
    const data = {
        name: _name.value,
        content: content.value,
    };
    publish(data)
        .catch(() => alert("Не удалось опубликовать главу"));
}

async function saveDraft(data) {
    const response = await fetch('/drafts', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    });
    return await response.json();
}

async function publish(data) {
    const response = await fetch('/chapters', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    });
    return await response.json();
}