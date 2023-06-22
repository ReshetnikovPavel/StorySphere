// const searchResultRowContainer = document.getElementById('search-result-row-container');
const leftColumn = document.getElementById('left-column');
const rightColumn = document.getElementById('right-column');

main()

async function main() {
    const pageSize = 2; // Число авторов на странице. Если меняете, ставьте четное
    let authorList;

    try {
        authorList = await fetchAuthorsPage(pageSize, 1);
    } catch (error) {
        // Вывожу временно в консольку, чтобы можно было посмотреть, что есть.
        console.error(`Error fetching authors list: ${error}`);
    }

    console.log(authorList);
    const size = 10;
    const total = authorList.metadata.totalPages;

    for (let pageNumber = 1; pageNumber <= size; pageNumber++) {
        await uploadPage(pageSize, pageNumber);
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
          await uploadPage(pageSize, pageNumber);
        }
        
        loadedPages++;
      }

      window.addEventListener('scroll', onScroll);
}

async function uploadPage(pageSize, pageNumber) {
    let list;
    try {
        list = await fetchAuthorsPage(pageSize, pageNumber);
    } catch (error) {
        console.error(`Error fetching authors list: ${error}`);
        console.error(`Ошибка случилась при размере ${pageSize}, и страницах ${pageNumber}`);
    }

    let column = leftColumn;
    const dataLength = list.items.length;

    for (let i = 0; i < dataLength; i++) {
        addAuthorInList(column, i, dataLength, list);
        column = column === leftColumn ? rightColumn : leftColumn;
    }
}

function addAuthorInList(column, dataIndex, dataLength, authorList) {
    if (dataIndex + 1 > dataLength) {
        return;
    }

    info = authorList.items[dataIndex];
    const authorRow = document.createElement('section');
    authorRow.classList.add('authors-list-author-row');
    authorRow.setAttribute('data-id', dataIndex);

    const avatar = document.createElement('img');
    avatar.classList.add('author-profile-button');
    avatar.setAttribute('src', info.picture !== null ? `/assets/images/avatars/${info.picture}` : '/assets/images/profile.svg'); 
    avatar.setAttribute('data-link', `/profile.html?username=${info.username}`);
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
    name.textContent = info.username;
    name.setAttribute('style', 'cursor: pointer;');
    name.setAttribute('data-link', `/profile.html?username=${info.username}`);
    name.addEventListener('click', () => {
        const link = avatar.getAttribute('data-link');
        window.location.href = link;
    });

    authorName.appendChild(name);
    authorRow.appendChild(authorName);

    const valueContainer = document.createElement('div');
    valueContainer.classList.add('author-list-value-container');

    const followersCountContainer = document.createElement('div');
    followersCountContainer.classList.add('authors-list-followers-count-container');

    const followersCount = document.createElement('label');
    followersCount.textContent = info.receivedLikes;
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
    worksCount.textContent = info.numFanfics;
    worksCountContainer.appendChild(worksCount);

    valueContainer.appendChild(worksCountContainer);
    authorRow.appendChild(valueContainer);

    column.appendChild(authorRow);
}

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

async function goToAuthorProfile(username) {
    window.location.href = `/profile.html?username=${username}`;
}