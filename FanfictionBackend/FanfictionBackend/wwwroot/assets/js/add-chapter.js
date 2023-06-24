
const publishBtn = document.querySelector('#publish');

publishBtn.addEventListener("click", publishSubmit);

const _name = document.getElementById('name');
const content = document.getElementById('content');

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

async function publish(chapter, fanficId) {
    const token = Cookies.get('session');

    if(token === undefined) {
        window.location.href = 'registration.html';
        return;
    }

    return await fetch(`/chapters?fanficId=${fanficId}`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${sessionToken}`
        },
        body: JSON.stringify(chapter)
    });
}