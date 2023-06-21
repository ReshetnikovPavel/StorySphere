
const draftBtn = document.querySelector('#draft');
const publishBtn = document.querySelector('#publish');
const statusBtn = document.querySelector('#status');

publishBtn.addEventListener("click", publishSubmit);
draftBtn.addEventListener("click", saveDraftSubmit);

const _name = document.getElementById('name');
const content = document.getElementById('content');

const popup = document.getElementById('popup');

statusBtn.addEventListener('click', function() {
  popup.style.display = 'flex';
});

popup.addEventListener('click', function(event) {
    if (event.target.tagName === 'BUTTON') {
        const selectedOption = event.target.textContent;
        console.log('Выбран вариант:', selectedOption); // Засетить статус
        popup.style.display = 'none';
    }
});

document.addEventListener('click', function(event) {
    if (!popup.contains(event.target) && event.target !== statusBtn) {
      popup.style.display = 'none';
    }
  });

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
    
    const chapter = {
        title: _name.value,
        content: content.value,
    };
    
    publish(chapter, getFanficId())
        .catch(() => alert("Не удалось опубликовать главу"));
}

function getFanficId() {
    const url = new URL(window.location.href);
    return url.searchParams.get("fanficId")
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

async function publish(chapter, fanficId) {
    return await fetch(`/chapters?fanficId=${fanficId}`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(chapter)
    });
}