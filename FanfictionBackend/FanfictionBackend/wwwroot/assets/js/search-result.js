processSearch();
async function processSearch() {

  const title = getTitle();

  const pageSize = 3; //число фанфиков на странице. если меняете - %3
  let fanficsList;

  try {
      fanficsList = await fetchFanficsByTitle(title, pageSize, 1);
  } catch (error) {
    const sorry = document.getElementById('search-result-row-container');
    sorry.textContent = 'Извините, по вашему запросу ничего не нашлось :(';
    return;
  }

  console.log(fanficsList);

  const total = fanficsList.metadata.totalPages;
  const size = Math.min(10, total);

  for (let pageNumber = 1; pageNumber <= size; pageNumber++) {
    await uploadPage(title, pageSize, pageNumber);
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
        await uploadPage(title, pageSize, pageNumber);
      }
      
      loadedPages++;
    }

    window.addEventListener('scroll', onScroll);
}

async function uploadPage(title, pageSize, pageNumber) {
  let list;
  try {
    list = await fetchFanficsByTitle(title, pageSize, pageNumber);
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

function getFanfics() {
    return [['Автомобилисты плачут и платят', '9', 'Это история о том, как бедный студент Василий решил преобрести себе машину, чтобы ездить на пары. Но он не знал, оо! Он не знал, что есть бензин и налоги. А еще кривые дороги!', 'fanfic-page.html'], 
['Юра и пельмехи', '999', 'Юра решил сварить пельмехи. Кто знал, что в этот момент в его стене откроется портал в другое измерение и оттуда выпадет жуткое существо? Что ж, теперь ужин не будет таким одиноким', 'fanfic-page.html'],
['111', '111', '111', 'fanfic-page.html'], ['222', '333', '444', 'fanfic-page.html'], ['555', '555', '555', 'fanfic-page.html']];
}

function getTitle() {
    var url = new URL(window.location.href);
    return url.searchParams.get('title');
}

async function fetchFanficsByTitle(title, pageSize, pageNumber) {
    const params = new URLSearchParams({ title, pageSize, pageNumber }).toString();
    const response = await fetch(`/fanfics/title?${params}`, {
        method: 'GET',
        headers: {
        'Content-Type': 'application/json'
        },
    });

    checkResponse(response);

    return await response.json()
}

function checkResponse(response) {
    if (!response.ok) {
        throw new Error(`HTTP error! Status: ${response.status}`);
    }
}