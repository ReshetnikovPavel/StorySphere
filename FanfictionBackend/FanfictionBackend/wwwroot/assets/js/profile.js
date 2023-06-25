processAuthor();

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

  const exitBtn = document.querySelector('#exit');
  const addWorkBtn = document.querySelector('#addWork');
  const profileAvatar = document.getElementById('profileAvatar');
  profileAvatar.setAttribute('src', getAvatar(author));
  const modal = document.getElementById('modal');
  const closeButton = modal.querySelector('.close');

  let user = Cookies.get('username');
  let token = Cookies.get('sessionToken');
  if (user === author.username) {
    exitBtn.addEventListener('click', exit);

    addWorkBtn.addEventListener('click', () => {
      window.location.href = 'add-fanfic.html';
    });

    profileAvatar.setAttribute('style', 'cursor: pointer;');
    profileAvatar.addEventListener('click', () => {
      modal.style.display = 'block';
    });
  } else {
    exitBtn.setAttribute('style', 'display: none;');
    addWorkBtn.setAttribute('style', 'display: none;');
  }

  closeButton.addEventListener('click', () => {
    modal.style.display = 'none';
  });

  const imageContainer = document.getElementById('image-container');
  const images = getImages();

  for(let i = 0; i < images.length; i++) {
    const image = document.createElement('img');
    image.setAttribute('style', 'cursor: pointer;');
    image.setAttribute('id', `avatar${i + 1}`);
    image.addEventListener('click', async () => {
      await postProfilePicture(`avatar${i + 1}`, token);
      profileAvatar.setAttribute('src', getAvatar(author));
      closeButton.click();
    });

    image.src = images[i];
    image.alt = `avatar${i + 1}`;

    image.style.maxWidth = '20rem';
    image.style.maxHeight = '20rem';

    imageContainer.appendChild(image);
  }

  console.log(author);

  const pageSize = 3;
  let fanficsList;

  try {
      fanficsList = await fetchFanficsByAuthor(author.username, pageSize, 1);
  } catch (error) {
    const sorry = document.getElementById('search-result-row-container');
    sorry.textContent = 'У этого автора пока нет работ';
    return;
  }

  console.log(fanficsList);

  const total = fanficsList.metadata.totalPages;
  const size = Math.min(10, total);

  for (let pageNumber = 1; pageNumber <= size; pageNumber++) {
    await uploadPage(author.username, pageSize, pageNumber);
  }

  let loadedPages = 1;
  function onScroll() {
    const position = window.pageYOffset + window.innerHeight;
    const bottom = document.documentElement.scrollHeight;

    if (position >= bottom && loadedPages < total) {
      loadNextBlock();
    }
  }

  async function loadNextBlock() {
    const startPage = loadedPages * size + 1;
    const endPage = Math.min((loadedPages + 1) * size, total);

    for (let pageNumber = startPage; pageNumber <= endPage; pageNumber++) {
      await uploadPage(author.username, pageSize, pageNumber);
    }

    loadedPages++;
  }

  window.addEventListener('scroll', onScroll);
}

async function uploadPage(username, pageSize, pageNumber) {
  let list;
  try {
      list = await fetchFanficsByAuthor(username, pageSize, pageNumber);
  } catch (error) {
      console.error(`Error fetching authors list: ${error}`);
      console.error(`Ошибка случилась при размере ${pageSize}, и страницах ${pageNumber}`);
  }

  const dataLength = list.items.length;

  for (let i = 0; i < dataLength; i += 3) {
      addFanficsRow(i, dataLength, list);
  }
}

function getImages() {
  const avatars = [];
  for (let i = 1; i < 27; i++) {
      avatars.push(`/assets/images/avatars/avatar${i}.png`);
  }

  return avatars;
}

function addFanficsRow(dataIndex, dataLength, list) {
  if (dataIndex > dataLength) return;

  if (dataLength - dataIndex < 3) {

      const searchResultRowContainer = document.getElementById('search-result-row-container');
      const searchResultRow = createRow(dataLength % 3, dataIndex, list);

      let mod = 3 - dataLength % 3;

      for (let i = 0; i < mod; i++) {
          let info = [null, null, null, null];
          const workContainerNull = createWorkContainer(info, dataLength + i);
          workContainerNull.style.visibility = "hidden";
          searchResultRow.appendChild(workContainerNull);
      }

      searchResultRowContainer.appendChild(searchResultRow);
  } else {
    const searchResultRowContainer = document.getElementById('search-result-row-container');
    const searchResultRow = createRow(3, dataIndex, list);
    searchResultRowContainer.appendChild(searchResultRow);
  }
}

function createRow(countContainers, dataIndex, list) {
  const searchResultRow = document.createElement('section');
  searchResultRow.classList.add('search-result-row');

  for (let j = 0; j < countContainers; j++) {
      let info = list.items[dataIndex + j];
      const workContainer = createWorkContainer(info, dataIndex + j);

      searchResultRow.appendChild(workContainer);
  }

  return searchResultRow;
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
  labelLikes.textContent = info.numLikes || 0;

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
  nameFanfic.textContent = info.title;
  nameFanfic.setAttribute('style', 'cursor: pointer;');

  nameFanfic.setAttribute('data-link', `fanfic-page.html?fanficId=${info.id}`);
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
  descriptionFanfic.textContent = info.description;

  workDescriptionContainer.appendChild(descriptionFanfic);
  workContainer.appendChild(workDescriptionContainer);

  return workContainer;
}

function getAvatar(author) {
    return author.picture !== null ? `assets/images/avatars/${author.picture}.png`: "/assets/images/profile-author.svg";
}

function exit() {
  var userAnswer = confirm("Вы действительно хотите выйти?");
  if (userAnswer) {
    logout();
    window.location.href = `/`;
  }
}

function logout() {
  Cookies.remove("username");
  Cookies.remove("sessionToken");
}

function getHrefAllWorks(username) {
    return `all-author\'s-work.html?username=${username}`;
}

function getAuthorName() {
  var url = new URL(window.location.href);
  return url.searchParams.get('username');
}

function loadingData(base, id) {
    const textNode = document.createTextNode(base);
    id.appendChild(textNode);
}

async function fetchAuthorByName(username) {
  const url = `/author/${username}`;

  const response = await fetch(url);

  checkResponse(response);

  const data = await response.json();
  return data;
}

async function fetchFanficsByAuthor(authorName, pageSize, pageNumber) {
  const params = new URLSearchParams({ authorName, pageSize, pageNumber }).toString();
  const response = await fetch(`/fanfics/author?${params}`, {
    method: 'GET',
    headers: {
      'Content-Type': 'application/json'
    },
  });

  checkResponse(response);

  return await response.json()
}

function checkResponse(response) {
  if (response.status === 404) {
    alert("Пользователь не найден");
    if (Cookies.get('username') === getAuthorName()) {
      logout();
    }
    window.location.href = '/';
    return;
  }

  if (!response.ok) {
    throw new Error(`HTTP error! Status: ${response.status}`);
  }
}

async function postProfilePicture(picture, sessionToken) {
  const response = await fetch(`/profilePicture?picture=${picture}`, {
      method: 'POST',
      headers: {
          'Content-Type': 'application/json',
          'Authorization': `Bearer ${sessionToken}`,
      },
  });

  checkResponse(response);

  // return await response.json();
}
