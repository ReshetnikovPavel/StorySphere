processAuthor()

async function processAuthor() {
  const authorInput = document.getElementById('author-name');
  const authorName = getAuthorName();
  let author;

  try {
    author = await fetchAuthorByName(authorName);
    console.log(author);
  } catch (error) {
    console.error(`Error fetching author: ${error}`);
  }

  loadingData(author.username, authorInput);
  //TODO: Совершить все остальные операции с автором тут.
  // Однако, у автора пока хранится только имя и почта. Это надо исправить.

  const profileAvatar = document.getElementById('profileAvatar');
  profileAvatar.setAttribute('style', 'cursor: pointer;');
  profileAvatar.setAttribute('src', getAvatar(author));
  const modal = document.getElementById('modal');
  const closeButton = modal.querySelector('.close');

  profileAvatar.addEventListener('click', () => {
    modal.style.display = 'block';
  });

  closeButton.addEventListener('click', () => {
    modal.style.display = 'none';
  });

  const imageContainer = document.getElementById('image-container');
  const images = getImages();

  for(let i = 0; i < images.length; i++) {
      const image = document.createElement('img');
      image.setAttribute('style', 'cursor: pointer;');
      image.setAttribute('id', `avatar${i + 1}`);
      image.addEventListener('click', () => {
        setAvatar(`avatar${i + 1}`);
        profileAvatar.setAttribute('src', getAvatar(author));
        closeButton.click();
      });

      image.src = images[i];
      image.alt = `avatar${i + 1}`;

      image.style.maxWidth = '20rem';
      image.style.maxHeight = '20rem';

      imageContainer.appendChild(image);
  }


}

function getImages() {
  const avatars = [];
  for (let i = 1; i < 27; i++) {
      avatars.push(`/assets/images/avatars/avatar${i}.png`);
  }

  return avatars;
}
// const timeInput = document.getElementById('online-time');
// const authorTime = getOnlineTime();
// loadingData(authorTime, timeInput);

const fanficsInfo = getFanfics();

addFanficsRow();

const allWorksBtn = document.querySelector('#allWorks');
const hrefAllWorks = getHrefAllWorks();
allWorksBtn.setAttribute('href', hrefAllWorks);
allWorksBtn.addEventListener('click', () => {
  window.location.href = hrefAllWorks;
});

const exitBtn = document.querySelector('#exit');
exitBtn.addEventListener("click", exit);

const addWorkBtn = document.querySelector('#addWork');
addWorkBtn.addEventListener('click', () => {
  window.location.href = 'add-fanfic.html';
})

function addFanficsRow() {
  const profileFanficRow = document.getElementById('profile-fanfics-row');

  for (let j = 0; j < 3; j++) {
      const info = fanficsInfo[j];
      if (info[0] == null) continue;
      const workContainer = createWorkContainer(info, j);
      profileFanficRow.appendChild(workContainer);
  }
}

function createWorkContainer(info, number) {
  const workContainer = document.createElement('section');
  workContainer.classList.add('work-container');
  workContainer.setAttribute('data-id', number)

  //Добавление лайков
  const likesRow = document.createElement('div');
  likesRow.classList.add('likes-row');

  const likesContainer = document.createElement('div');
  likesContainer.classList.add('likes-container');

  const labelLikes = document.createElement('label');
  labelLikes.textContent = info[1] || 0;

  const starLikesIcon = document.createElement('img');
  starLikesIcon.classList.add('star_likes_icon');
  starLikesIcon.setAttribute('src', 'assets/images/star_likes.svg');
  starLikesIcon.setAttribute('alt', 'star_likes');

  likesContainer.appendChild(labelLikes);
  likesContainer.appendChild(starLikesIcon);

  likesRow.appendChild(likesContainer);

  workContainer.appendChild(likesRow);

  //Добавление имени фанфика
  const workNameContainer = document.createElement('div');
  workNameContainer.classList.add('work-name-container');

  const nameFanfic = document.createElement('h3');
  nameFanfic.textContent = info[0];
  nameFanfic.setAttribute('style', 'cursor: pointer;');

  nameFanfic.setAttribute('data-link', info[3]);
  nameFanfic.addEventListener('click', () => {
      const link = nameFanfic.getAttribute('data-link');
      window.location.href = link;
  });

  workNameContainer.appendChild(nameFanfic);
  workContainer.appendChild(workNameContainer);

  //Добавление описания фанфика
  const workDescriptionContainer = document.createElement('div');
  workDescriptionContainer.classList.add('work-description-container');

  const descriptionFanfic = document.createElement('p');
  descriptionFanfic.textContent = info[2];

  workDescriptionContainer.appendChild(descriptionFanfic);
  workContainer.appendChild(workDescriptionContainer);

  return workContainer;
}

function getAvatar(author) {
    return author.picture !== null ? `assets/images/avatars/${picture}`: "/assets/images/profile-author.svg";
}

function setAvatar(avatarName) {
  alert('Аватар загружен в базу данных: ' + avatarName);
}

function getFanfics() {
    return [['Автомобилисты плачут и платят', '9', 'Это история о том, как бедный студент Василий решил преобрести себе машину, чтобы ездить на пары. Но он не знал, оо! Он не знал, что есть бензин и налоги. А еще кривые дороги!', 'fanfic-page.html'], 
['Юра и пельмехи', '999', 'Юра решил сварить пельмехи. Кто знал, что в этот момент в его стене откроется портал в другое измерение и оттуда выпадет жуткое существо? Что ж, теперь ужин не будет таким одиноким', 'fanfic-page.html'],
[null, null, null, null]];
}

function exit() {
    Cookies.remove("username");
    Cookies.remove("sessionToken");
    window.location.href = `/`;
}

function getHrefAllWorks() {
    return 'all-author\'s-work.html'
}

function getAuthorName() {
  var url = new URL(window.location.href);
  return url.searchParams.get("username");
}

// function getOnlineTime() {
//     return '17 минут назад';
// }

function loadingData(base, id) {
    const textNode = document.createTextNode(base);
    id.appendChild(textNode);
}

async function fetchAuthorByName(username) {
  const url = `/author/${username}`;

  const response = await fetch(url);

  if (!response.ok) {
    throw new Error(`HTTP error! Status: ${response.status}`);
  }

  const data = await response.json();
  return data;
}