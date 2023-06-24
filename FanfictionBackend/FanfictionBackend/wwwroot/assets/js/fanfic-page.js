let fanficId = 2; //getFanficId();
main();

async function main() {
    let fanfic;
    try {
        fanfic = await fetchFanfic(fanficId);
    } catch (error) {
        console.error(`Error fetching: ${error}`);
    }

    const fanficNameInfo = fanfic.title;
    const authorInfo = fanfic.authorName;
    const ratingInfo = fanfic.ageLimit;
    let focusInfo;

    switch (fanfic.category) {
    case 'Слэш':
        focusInfo = '⚣';
        break;
    case 'Фемслэш':
        focusInfo = '⚢';
        break;
    case 'Гет':
        focusInfo = '⚤';
        break;
    case 'Джен':
        focusInfo = '⚔︎';
        break;
    case 'Смешанная':
        focusInfo = '〰';
        break;
    case 'Статья':
        focusInfo = '✒';
        break;
    case 'Другое':
        focusInfo = '◯';
        break;
    default:
        focusInfo = '◯';
    }

    const likesInfo = fanfic.numLikes;
    const sizeChaptersInfo = fanfic.numChapter;
    const charactersInfo = fanfic.characters;
    const pairingsInfo = fanfic.pairings;
    const genresInfo = fanfic.genre;
    const warningsInfo = fanfic.warnings;
    const descriptionInfo = fanfic.description;
    const notesInfo = fanfic.authorNotes;
    const fandomInfo = fanfic.fandom;

    const fanficName = document.getElementById('fanficName');
    const rating = document.getElementById('rating');
    // const _status = document.getElementById('status');
    const _focus = document.getElementById('focus');
    const likes = document.getElementById('likes');
    const author = document.getElementById('author');

    author.setAttribute('data-link',`/profile.html?username=${authorInfo}`);
    author.setAttribute('style', 'cursor: pointer;')
    author.addEventListener('click', () => {
        const link = author.getAttribute('data-link');
        window.location.href = link;
    });

    const fandom = document.getElementById('fandom');
    const notes = document.getElementById('notes');
    const sizeChapters = document.getElementById('sizeChapters');
    const characters = document.getElementById('characters');
    const pairings = document.getElementById('pairings');
    const genres = document.getElementById('genres');
    const warnings = document.getElementById('warnings');
    const description = document.getElementById('description');
    const chapterLabel = document.getElementById('chapterLabel');

    loadingData(fanficNameInfo, fanficName);
    loadingData(ratingInfo, rating);
    // loadingData(statusInfo, _status);
    loadingData(focusInfo, _focus);
    loadingData(likesInfo, likes);
    loadingData(authorInfo, author);
    loadingData(sizeChaptersInfo, sizeChapters);
    loadingData(charactersInfo, characters);
    loadingData(pairingsInfo, pairings);
    loadingData(genresInfo, genres);
    loadingData(warningsInfo, warnings);
    loadingData(descriptionInfo, description);
    loadingData(fandomInfo, fandom);
    loadingData(notesInfo, notes);

    if (sizeChaptersInfo % 10 === 1 && sizeChaptersInfo % 100 !== 11) {
        chapterLabel.textContent = 'глав';
    } else if (sizeChaptersInfo % 10 >= 2 && sizeChaptersInfo % 10 <= 4 
        && (sizeChaptersInfo % 100 < 10 || sizeChaptersInfo % 100 >= 20)) {
        chapterLabel.textContent = 'главы';
    } else {
        chapterLabel.textContent = 'глав';
    }

    let chapter;

    const nameChapter = document.getElementById('nameChapter');
    const contentChapter = document.getElementById('contentChapter');
    let currentChapter = parseInt(localStorage.getItem('currentChapter')) || 1;

    try {
        chapter = await fetchChapter(fanficId, currentChapter);
    } catch (error) {
        console.error(`Error fetching: ${error}`);
        console.error(fanficId, currentChapter);
    }

    let nameChapterInfo = chapter.title;
    let contentChapterInfo = chapter.content;

    let textNodeName = document.createTextNode(nameChapterInfo);
    nameChapter.appendChild(textNodeName);

    let textNodeChapter = document.createTextNode(contentChapterInfo);
    contentChapter.appendChild(textNodeChapter);

    const nextButton = document.querySelector('#nextChapter');
    const prevButton = document.querySelector('#prevChapter');

    if(currentChapter === parseInt(sizeChaptersInfo)) {
        nextButton.style.visibility = 'hidden';
    }

    if(currentChapter === 1) {
        prevButton.style.visibility = 'hidden';
    }

    nextButton.addEventListener('click', async () => {
        currentChapter = Math.min(currentChapter + 1, parseInt(sizeChaptersInfo));
        localStorage.setItem('currentChapter', currentChapter.toString());
        try {
            chapter = await fetchChapter(fanficId, currentChapter);
        } catch (error) {
            console.error(`Error fetching: ${error}`);
            console.error(fanficId, currentChapter);
        }
        nameChapter.removeChild(textNodeName);
        textNodeName = document.createTextNode(chapter.title);
        nameChapter.appendChild(textNodeName);
    
        contentChapter.removeChild(textNodeChapter);
        textNodeChapter = document.createTextNode(chapter.content);
        contentChapter.appendChild(textNodeChapter);

        prevButton.style.visibility = 'visible';
        if(currentChapter === parseInt(sizeChaptersInfo)) {
            nextButton.style.visibility = 'hidden';
        }
    });

    prevButton.addEventListener('click', async () => {
        currentChapter = Math.max(currentChapter - 1, 1);
        localStorage.setItem('currentChapter', currentChapter.toString());
        try {
            chapter = await fetchChapter(fanficId, currentChapter);
        } catch (error) {
            console.error(`Error fetching: ${error}`);
            console.error(fanficId, currentChapter);
        }

        nameChapter.removeChild(textNodeName);
        textNodeName = document.createTextNode(chapter.title);
        nameChapter.appendChild(textNodeName);
    
        contentChapter.removeChild(textNodeChapter);
        textNodeChapter = document.createTextNode(chapter.content);
        contentChapter.appendChild(textNodeChapter);

        nextButton.style.visibility = 'visible';
        if(currentChapter === 1) {
            prevButton.style.visibility = 'hidden';
        }
    });

    const user = 'softowl256';
    const likeButton = document.querySelector('#likeBtn');
    let IsLike = getIsLike() || false;

    const addChapterBtn = document.getElementById('addChapter');
    // const statusBtn = document.getElementById('changeStatus');

    if (authorInfo !== user) {
        // statusBtn.setAttribute('style', 'display: none;');
        addChapterBtn.setAttribute('style', 'display: none;');

        const imgLike = document.createElement('img');
        imgLike.classList.add('button-star-icon');
        imgLike.setAttribute('src', 'assets/images/star2.svg');
        imgLike.setAttribute('alt', 'like');
        likeButton.appendChild(imgLike);


        if (IsLike) likeButton.style.backgroundColor = 'rgb(112, 36, 20, 0.3)';

        likeButton.addEventListener('click', () => {
            IsLike = !IsLike;
            likeButton.style.backgroundColor = IsLike ? 'rgb(112, 36, 20, 0.3)' : 'white';
            setLikeValue(IsLike);
        });
    } else {
        likeButton.setAttribute('style', 'display: none;');

        addChapterBtn.setAttribute('style', 'display: block;');
        addChapterBtn.addEventListener('click', () => {
            window.location.href = `/add-chapter.html?fanficId=${fanficId}`;
        });

        // statusBtn.setAttribute('style', 'display: block;');
        // const popup = document.getElementById('popup');

        // statusBtn.addEventListener('click', () => {
        // console.log('click!');
        // popup.style.display = 'flex';
        // });

        // popup.addEventListener('click', function(event) {
        // if (event.target.tagName === 'BUTTON') {
        //     const selectedOption = event.target.textContent;
        //     console.log('Выбран вариант:', selectedOption); // Засетить статус
        //     popup.style.display = 'none';
        // }
        // });

        // document.addEventListener('click', function(event) {
        // if (!popup.contains(event.target) && event.target !== statusBtn) {
        // popup.style.display = 'none';
        // }
        // });
    }

    const openModalButton = document.getElementById('gallery');
    openModalButton.setAttribute('style', 'cursor: pointer;');
    const modal = document.getElementById('modal');
    const closeButton = modal.querySelector('.close');

    openModalButton.addEventListener('click', () => {
    modal.style.display = 'block';
    });

    closeButton.addEventListener('click', () => {
    modal.style.display = 'none';
    });

    const imageContainer = document.getElementById('image-container');
    const images = getImages();

    for(let i = 0; i < images.length; i++) {
        const image = document.createElement('img');

        image.src = images[i];
        image.alt = 'illustration';

        image.style.maxWidth = '30rem';
        image.style.maxHeight = '30rem';

        imageContainer.appendChild(image);
    }
}

function getIsLike() {
    return localStorage.getItem('like') || false;
}

function setLikeValue(IsLike) {
    if (IsLike) {
        alert('Вы лайкнули работу!')
        localStorage.setItem('like', true);
    } else {
        alert('Вы убрали лайк с работы!')
        localStorage.setItem('like', false);
    }
}

function changeChapter(NCI, CCI, textNodeName, textNodeChapter) {
    nameChapter.removeChild(textNodeName);
    textNodeName = document.createTextNode(NCI);
    nameChapter.appendChild(textNodeName);

    contentChapter.removeChild(textNodeChapter);
    textNodeChapter = document.createTextNode(CCI);
    contentChapter.appendChild(textNodeChapter);
}

function loadingData(base, id) {
    const textNode = document.createTextNode(base);
    id.appendChild(textNode);
}

function getImages() {
    return ["/assets/images/img5.png", "/assets/images/img6.png", "/assets/images/img7.jpg", "/assets/images/img8.png"];
}

function getFanficId() {
    var url = new URL(window.location.href);
    return url.searchParams.get("fanficId");
}

async function fetchFanfic(fanficId) {
    const response = await fetch(`/fanfics?fanficId=${fanficId}`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        },
    });

    return await response.json();
}

async function fetchChapter(fanficId, chapterNo) {
    const response = await fetch(`/chapters?fanficId=${fanficId}&chapterNo=${chapterNo}`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        },
    });

    return await response.json();
}

async function fetchLike(fanficId) {
    const response = await fetch(`/likes?fanficId=${fanficId}`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${sessionToken}`,
        },
    });

    return await response.json();
}

async function postLike(fanficId) {
    const response = await fetch(`/likes?fanficId=${fanficId}`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${sessionToken}`,
        },
    });

    return await response.json();
}

async function deleteLike(fanficId) {
    const response = await fetch(`/likes?fanficId=${fanficId}`, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${sessionToken}`,
        },
    });

    return await response.json();
}