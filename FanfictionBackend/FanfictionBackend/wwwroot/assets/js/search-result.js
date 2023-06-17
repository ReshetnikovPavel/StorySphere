const fanficsInfo = getFanfics();

let dataIndex = 0; // текущий фанфик в массиве
const dataLength = fanficsInfo.length; //всего фф
const searchResultRowContainer = document.getElementById('search-result-row-container');
let rowIndex = 0; //строчка фф
let cycle = 0;

if (dataLength === 0) {
    const sorry = document.createElement('h1');
    sorry.textContent = 'Извините, ничего не найдено :( Даже печенек с чаем нет!'
    searchResultRowContainer.appendChild(sorry);
} else {
    addSearchResultRow();
    addSearchResultRow();
    addSearchResultRow();

    window.addEventListener('scroll', function() {
        addSearchResultRow();
    });
}

function addSearchResultRow() {
    const searchResultRowContainer = document.getElementById('search-result-row-container');
    rowIndex++;
    // Создание search-result-row и добавление его в searchResultRowContainer с разными data-id
    const searchResultRow = document.createElement('section');
    searchResultRow.classList.add('search-result-row');
    searchResultRow.setAttribute('data-id', rowIndex); // Установка разных data-id

    // Создание и добавление трех work-container в каждый search-result-row
    for (let j = 0; j < 3; j++) {

        const info = fanficsInfo[dataIndex];

        const workContainer = document.createElement('section');
        workContainer.classList.add('work-container');
        workContainer.setAttribute('data-id', cycle * dataLength + dataIndex)

        // Добавление других div в каждый work-container

        //Добавление лайков
        const likesRow = document.createElement('div');
        likesRow.classList.add('likes-row');

        const likesContainer = document.createElement('div');
        likesContainer.classList.add('likes-container');

        const labelLikes = document.createElement('label');
        labelLikes.setAttribute('id', 'likes');
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
        nameFanfic.setAttribute('id', 'nameFanfic');
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
        descriptionFanfic.setAttribute('id', 'descriptionFanfic');
        descriptionFanfic.textContent = info[2];

        workDescriptionContainer.appendChild(descriptionFanfic);
        workContainer.appendChild(workDescriptionContainer);

        dataIndex++;
        if (dataIndex === dataLength) {
            dataIndex = 0;
            cycle++;
        }
        // Добавление work-container в search-result-row
        searchResultRow.appendChild(workContainer);
    }

    // Добавление search-result-row в searchResultRowContainer
    searchResultRowContainer.appendChild(searchResultRow);   
}

function getFanfics() {
    return [['Автомобилисты плачут и платят', '9', 'Это история о том, как бедный студент Василий решил преобрести себе машину, чтобы ездить на пары. Но он не знал, оо! Он не знал, что есть бензин и налоги. А еще кривые дороги!', 'fanfic-page.html'], 
['Юра и пельмехи', '999', 'Юра решил сварить пельмехи. Кто знал, что в этот момент в его стене откроется портал в другое измерение и оттуда выпадет жуткое существо? Что ж, теперь ужин не будет таким одиноким', 'fanfic-page.html'],
['111', '111', '111', 'fanfic-page.html'], ['222', '333', '444', 'fanfic-page.html'], ['555', '555', '555', 'fanfic-page.html']];
}