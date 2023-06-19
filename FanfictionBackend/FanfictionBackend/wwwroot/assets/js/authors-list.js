let dataIndex = 0; // текущий автор в массиве
let dataLength = 0; //всего авторов 
let authorList;
let rowCount = 0;
let maxPageCount;
let pageNumber;

const searchResultRowContainer = document.getElementById('search-result-row-container');
const leftColumn = document.getElementById('left-column');
const rightColumn = document.getElementById('right-column');



// console.log(authorList.metadata); // Данные о списке. 
// // Сколько всего страниц, есть ли куда листать вперед и назад, и т.д.

// console.log(authorList.items); // Сами авторы.
// У каждого автора есть такие поля как username и email.
// Будут еще другие, но их надо добавить.

main()

async function main() {
    const pageSize = 2; // Число авторов на странице
    pageNumber = 1; // Номер запрашиваемой страницы



    try {
        authorList = await fetchAuthorsPage(pageSize, 1);
    } catch (error) {
        // Вывожу временно в консольку, чтобы можно было посмотреть, что есть.
        console.error(`Error fetching authors list: ${error}`);
    }

    maxPageCount = Math.min(15, authorList.metadata.totalPages);

    await uploadPagesWithinWindow(pageSize);
    // // await uploadPagesWithinWindow(pageSize);
    // while(maxPageCount !== 0) {
    //     window.addEventListener('scroll', await uploadPagesWithinWindow(pageSize));
    // }

   
    


    //window.addEventListener('scroll', async function() {

        
        // if(!authorList.metadata.hasNext && authorList.metadata.totalItems % 2 === 1) {
        //     dataIndex = 0; // текущий автор в массиве
        //     dataLength = authorList.items.length; //всего авторов
        //     console.log(authorList);
        //     addAuthorInList(leftColumn);
        //     console.log(authorList);
        // } else {
        //     dataIndex = 0; // текущий автор в массиве
        //     dataLength = authorList.items.length; //всего авторов
        //     console.log(authorList);
        //     addAuthorInList(leftColumn);
        //     addAuthorInList(rightColumn);
        // }
    //});

}

async function uploadPagesWithinWindow(pageSize) {
    for (let i = 0; i < maxPageCount; i++) {
        try {
            authorList = await fetchAuthorsPage(pageSize, pageNumber + i);
        } catch (error) {
            console.error(`Error fetching authors list: ${error}`);
        }
        // pageNumber++;
        console.log(pageNumber + i);

        let column = leftColumn;
        dataIndex = 0; // текущий автор в массиве
        dataLength = await authorList.items.length; //всего авторов на странице

        // console.log(authorList);

        for (let i = 0; i < dataLength; i++) {
            await addAuthorInList(column);
            column = column === leftColumn ? rightColumn : leftColumn;
            // console.log(i);
        }
    }
    pageNumber += await maxPageCount;
    maxPageCount = Math.min(10, await authorList.metadata.totalPages - pageNumber);
    // console.log(pageNumber);
    // console.log(maxPageCount);
}

async function addAuthorInList(column) {
    if (dataIndex + 1 > dataLength) {
        return;
    }

    info = await authorList.items[dataIndex];
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

    await column.appendChild(authorRow);

    dataIndex++;
}

function getAuthorsInfo() {
    return [['Андрей Куклинов', '/assets/images/avatars/avatar25.png', '4', '17', 'profile.html'],
    ['SoftOwl256', '/assets/images/avatars/avatar26.png', '42', '172', 'profile.html'],
    ['Rustовщик', '/assets/images/avatars/avatar24.png', '75', '865', 'profile.html'],
    ['Bibibooooooooooooooooooooooooooooo0000000', '/assets/images/avatars/avatar12.png', '0', '2', 'profile.html'],
    ['JojoFun', '/assets/images/profile.svg', '0', '0', 'profile.html']]
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

// goToAuthorProfile("capitulation")

async function goToAuthorProfile(username) {
    window.location.href = `/profile.html?username=${username}`;
}