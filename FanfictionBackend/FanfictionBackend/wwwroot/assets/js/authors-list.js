const authorsInfo = getAuthorsInfo();

let dataIndex = 0; // текущий автор в массиве
const dataLength = authorsInfo.length; //всего авторов
let rowIndex = 0; //строчка авторов
let cycle = 0;

const searchResultRowContainer = document.getElementById('search-result-row-container');
const leftColumn = document.getElementById('left-column');
const rightColumn = document.getElementById('right-column');

for (let i = 0; i < 15; i++) {
    addAuthorInList(leftColumn);
    addAuthorInList(rightColumn);
}

window.addEventListener('scroll', function() {
    addAuthorInList(leftColumn);
    addAuthorInList(rightColumn);
});

function addAuthorInList(column) {
    if (dataIndex + 1 > dataLength) {
        return;
    }

    info = authorsInfo[dataIndex];
    const authorRow = document.createElement('section');
    authorRow.classList.add('authors-list-author-row');
    authorRow.setAttribute('data-id', cycle * dataLength + dataIndex);

    const avatar = document.createElement('img');
    avatar.classList.add('author-profile-button');
    avatar.setAttribute('src', info[1]);
    avatar.setAttribute('data-link', info[4]);
    avatar.setAttribute('style', 'border-radius: 100%;');
    avatar.addEventListener('click', () => {
        const link = avatar.getAttribute('data-link');
        window.location.href = link;
    });
    avatar.setAttribute('alt', 'author-avatar');
    authorRow.appendChild(avatar);

    const authorName = document.createElement('div');
    authorName.classList.add('author-list-author-name');

    const name = document.createElement('label');
    name.textContent = info[0];
    name.setAttribute('style', 'cursor: pointer;');
    name.setAttribute('data-link', info[4]);
    name.addEventListener('click', () => {
        const link = name.getAttribute('data-link');
        window.location.href = link;
    });

    authorName.appendChild(name);
    authorRow.appendChild(authorName);

    const valueContainer = document.createElement('div');
    valueContainer.classList.add('author-list-value-container');

    const followersCountContainer = document.createElement('div');
    followersCountContainer.classList.add('authors-list-followers-count-container');

    const followersCount = document.createElement('label');
    followersCount.textContent = info[3];
    followersCountContainer.appendChild(followersCount);

    const likeIcon = document.createElement('img');
    likeIcon.classList.add('star_likes_icon');
    likeIcon.setAttribute('src', '/assets/images/star_likes.svg');
    likeIcon.setAttribute('alt', 'star_likes');
    followersCountContainer.appendChild(likeIcon);

    valueContainer.appendChild(followersCountContainer);

    const worksCountContainer = document.createElement('div');
    worksCountContainer.classList.add('author-list-works-count');

    const worksCount = document.createElement('label');
    worksCount.textContent = info[2];
    worksCountContainer.appendChild(worksCount);

    valueContainer.appendChild(worksCountContainer);
    authorRow.appendChild(valueContainer);

    column.appendChild(authorRow);

    dataIndex++;
}

function getAuthorsInfo() {
    return [['Андрей Куклинов', '/assets/images/avatars/avatar25.png', '4', '17', 'profile.html'],
    ['SoftOwl256', '/assets/images/avatars/avatar26.png', '42', '172', 'profile.html'],
    ['Rustовщик', '/assets/images/avatars/avatar24.png', '75', '865', 'profile.html'],
    ['Bibibooooooooooooooooooooooooooooo0000000', '/assets/images/avatars/avatar12.png', '0', '2', 'profile.html'],
    ['JojoFun', '/assets/images/profile.svg', '0', '0', 'profile.html']]
}

// Пример применения fetchAuthorsPage. Выводит полученный список авторов в консоль
// Предлагаю раскомментировать и запустить, чтобы посмотреть на объект, который он выведет.
// pageSize - размер одной страницы, pageNumber - номер текущей страницы.
// fetchAuthorsPage(2, 1) 
//     .then((pagedList) => {
//         console.log(pagedList); 
//     });

async function fetchAuthorsPage(pageSize, pageNumber) {
    const params = new URLSearchParams({ pageSize, pageNumber });
    const query = params.toString();
    const url = `/authors?${query}`;
  
    const response = await fetch(url);
  
    if (!response.ok) {
      throw new Error(`HTTP error! Status: ${response.status}`);
    }
  
    const data = await response.json();
    return data;
}