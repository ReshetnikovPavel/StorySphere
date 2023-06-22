const fanficName = document.getElementById('fanficName');
const rating = document.getElementById('rating');
const _status = document.getElementById('status');
const _focus = document.getElementById('focus');
const likes = document.getElementById('likes');
const author = document.getElementById('author');

author.setAttribute('data-link', 'profile.html');
author.setAttribute('style', 'cursor: pointer;')
author.addEventListener('click', () => {
    const link = author.getAttribute('data-link');
    window.location.href = link;
});

const sizeChapters = document.getElementById('sizeChapters');
const sizePages = document.getElementById('sizePages');
const characters = document.getElementById('characters');
const pairings = document.getElementById('pairings');
const genres = document.getElementById('genres');
const warnings = document.getElementById('warnings');
const description = document.getElementById('description');

const [fanficNameInfo, ratingInfo, statusInfo, focusInfo,
        likesInfo, authorInfo, sizeChaptersInfo, 
        sizePagesInfo, charactersInfo, pairingsInfo,
        genresInfo, warningsInfo, descriptionInfo] = getFanficInfo();

loadingData(fanficNameInfo, fanficName);
loadingData(ratingInfo, rating);
loadingData(statusInfo, _status);
loadingData(focusInfo, _focus);
loadingData(likesInfo, likes);
loadingData(authorInfo, author);
loadingData(sizeChaptersInfo, sizeChapters);
loadingData(sizePagesInfo, sizePages);
loadingData(charactersInfo, characters);
loadingData(pairingsInfo, pairings);
loadingData(genresInfo, genres);
loadingData(warningsInfo, warnings);
loadingData(descriptionInfo, description);

const nameChapter = document.getElementById('nameChapter');
const contentChapter = document.getElementById('contentChapter');
let currentChapter = parseInt(localStorage.getItem('currentChapter')) || 0;

let [nameChapterInfo, contentChapterInfo] = getChapterInfo(currentChapter);

let textNodeName = document.createTextNode(nameChapterInfo);
nameChapter.appendChild(textNodeName);

let textNodeChapter = document.createTextNode(contentChapterInfo);
contentChapter.appendChild(textNodeChapter);

const nextButton = document.querySelector('#nextChapter');
const prevButton = document.querySelector('#prevChapter');

nextButton.addEventListener('click', () => {
    currentChapter = Math.min(currentChapter + 1, parseInt(sizeChaptersInfo) - 1);
    localStorage.setItem('currentChapter', currentChapter.toString());
    let [NCI, CCI] = getChapterInfo(currentChapter);
    changeChapter(NCI, CCI);

    prevButton.style.visibility = 'visible';
    if(currentChapter === parseInt(sizeChaptersInfo) - 1) {
        nextButton.style.visibility = 'hidden';
    }

  });
  
prevButton.addEventListener('click', () => {
    currentChapter = Math.max(currentChapter - 1, 0);
    localStorage.setItem('currentChapter', currentChapter.toString());
    let [NCI, CCI] = getChapterInfo(currentChapter);
    changeChapter(NCI,CCI);

    nextButton.style.visibility = 'visible';
    if(currentChapter === 0) {
        prevButton.style.visibility = 'hidden';
    }
  });

const authorh = 'aa';
const user = 'aa';
const likeButton = document.querySelector('#likeBtn');
let IsLike = getIsLike() || false;
if (authorh === user) {
    likeButton.textContent = 'Добавить главу';
    likeButton.addEventListener('click', () => {
        window.location.href = 'add-chapter.html';
    })
} else {
    const imgLike = document.createElement('img');
    imgLike.classList.add('button-star-icon');
    imgLike.setAttribute('src', 'assets/images/star2.svg');
    imgLike.setAttribute('alt', 'like');
    likeButton.appendChild(imgLike);

    if (IsLike) likeButton.style.backgroundColor = 'rgb(112, 36, 20, 0.3)';

    likeButton.addEventListener('click', () => {
        IsLike = !IsLike;
        likeButton.style.backgroundColor = IsLike ? 'rgb(112, 36, 20, 0.3)' : 'white';
        setLikeValue();
    });
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

function getIsLike() {
    return localStorage.getItem('like') || false;
}

function setLikeValue() {
    if (IsLike) {
        alert('Вы лайкнули работу!')
        localStorage.setItem('like', true);
    } else {
        alert('Вы убрали лайк с работы!')
        localStorage.setItem('like', false);
    }
}

function changeChapter(NCI, CCI) {
    nameChapter.removeChild(textNodeName);
    textNodeName = document.createTextNode(NCI);
    nameChapter.appendChild(textNodeName);

    contentChapter.removeChild(textNodeChapter);
    textNodeChapter = document.createTextNode(CCI);
    contentChapter.appendChild(textNodeChapter);
}

function getFanficInfo() {
    return ['Как Андрей в ДнД играл', 'NC-17', '✓', '〰', '3012', 'SoftOwl256', '3', '590', 'Андрей Куклинов, Ангелина Шманцарь, Павел Решетников, Анна Соколова', 'Соня Мелькова/Глеб Иванов, Гаврилов Никита/Анна Васильева, Павел Решетников/Rust', 'Жанры', 'Предупреждения', 'Описание']
}

function getChapterInfo(curr) {
    const chapterInfo = [['Глава 1: Ах, как хорош этот ваш ДнД', 'Я плакаль'], ['Как я устал от ДнД, глава 2', 'я все еще плакаль'], ['11', '111']];
    if (curr > parseInt(sizeChaptersInfo) - 1) return chapterInfo[parseInt(sizeChaptersInfo) - 1];
    return chapterInfo[curr];

}

function loadingData(base, id) {
    const textNode = document.createTextNode(base);
    id.appendChild(textNode);
}

function getImages() {
    return ["/assets/images/img5.png", "/assets/images/img6.png", "/assets/images/img7.jpg", "/assets/images/img8.png"];
}

async function fetchFanfic(fanficId) {
    const response= await fetch(`/fanfics?fanficId=${fanficId}`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        },
    });

    return await response.json();
}

async function fetchChapter(fanficId, chapterNo) {
    const response= await fetch(`/chapters?fanficId=${fanficId}&chapterNo=${chapterNo}`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        },
    });

    return await response.json();
}
