const fanficsInfo = getFanfics();

let dataIndex = 0; // текущий фанфик в массиве
const dataLength = fanficsInfo.length; //всего фф
const searchResultRowContainer = document.getElementById('search-result-row-container');
let rowIndex = 0; //строчка фф
const countFilledLines = (dataLength - dataLength % 3) / 3;
let cycle = 0;

if (dataLength === 0) {
    const sorry = document.createElement('h1');
    sorry.textContent = 'Извините, ничего не найдено :( Даже печенек с чаем нет!'
    searchResultRowContainer.appendChild(sorry);
} else {
    for(let i = 0; i < 6; i++){
        addFanficsRow();
    }

    window.addEventListener('scroll', function() {
        addFanficsRow();
    });
}

function addFanficsRow() {
    if (dataIndex > dataLength) return;

    if (rowIndex < countFilledLines) {
        const searchResultRowContainer = document.getElementById('search-result-row-container');
        const searchResultRow = createRow(3);

        searchResultRowContainer.appendChild(searchResultRow);
    } else if (dataLength % 3 !== 0) {
        rowIndex++;
        const searchResultRowContainer = document.getElementById('search-result-row-container');
        const searchResultRow = createRow(dataLength % 3);

        let mod = 3 - dataLength % 3;

        for (let i = 0; i < mod; i++) {
            let info = [null, null, null, null];
            const workContainerNull = createWorkContainer(info, dataLength + i);
            workContainerNull.style.visibility = "hidden";
            searchResultRow.appendChild(workContainerNull);
        }

        dataIndex = dataLength + 1;
        searchResultRowContainer.appendChild(searchResultRow);
    }
}

function createRow(countContainers) {
    const searchResultRow = document.createElement('section');
    searchResultRow.classList.add('search-result-row');
    searchResultRow.setAttribute('data-id', rowIndex);
    rowIndex++;

    for (let j = 0; j < countContainers; j++) {
        let info = fanficsInfo[dataIndex];
        const workContainer = createWorkContainer(info, dataIndex);

        searchResultRow.appendChild(workContainer);

        dataIndex++;
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

function getFanfics() {
    return [['Автомобилисты плачут и платят', '9', 'Это история о том, как бедный студент Василий решил преобрести себе машину, чтобы ездить на пары. Но он не знал, оо! Он не знал, что есть бензин и налоги. А еще кривые дороги!', 'fanfic-page.html'], 
['Юра и пельмехи', '999', 'Юра решил сварить пельмехи. Кто знал, что в этот момент в его стене откроется портал в другое измерение и оттуда выпадет жуткое существо? Что ж, теперь ужин не будет таким одиноким', 'fanfic-page.html'],
['111', '111', '111', 'fanfic-page.html'], ['222', '333', '444', 'fanfic-page.html'], ['555', '555', '555', 'fanfic-page.html'], ['555', '555', '555', 'fanfic-page.html'], ['565', '565', '565', 'fanfic-page.html']];
}