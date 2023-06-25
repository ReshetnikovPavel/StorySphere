
const publishBtn = document.querySelector('#publish');
const form = document.querySelector('#add-chapter-form');

form.addEventListener("submit", publishSubmit);

const _name = document.getElementById('name');
const content = document.getElementById('content');

async function publishSubmit(event) {
    event.preventDefault();
    if (_name.value.trim() === '') {
        alert('Введите название главы');
        return;
    }
    
    const chapter = {
        title: _name.value,
        content: content.value,
    };
    const fanficId = getFanficId();
    await publish(chapter, fanficId)
        .catch(() => alert("Не удалось опубликовать главу"));
    goToFanficPage(fanficId);
}

function goToFanficPage(fanficId) {
    window.location.href = `/fanfic-page.html?fanficId=${fanficId}`
}

function getFanficId() {
    const url = new URL(window.location.href);
    return url.searchParams.get("fanficId")
}

async function publish(chapter, fanficId) {
    const token = Cookies.get('sessionToken');

    if(token === undefined) {
        window.location.href = 'registration.html';
        return;
    }

    return await fetch(`/chapters?fanficId=${fanficId}`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${token}`
        },
        body: JSON.stringify(chapter)
    });
}