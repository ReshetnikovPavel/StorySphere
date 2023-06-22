
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
    return await fetch(`/chapters?fanficId=${fanficId}`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(chapter)
    });
}