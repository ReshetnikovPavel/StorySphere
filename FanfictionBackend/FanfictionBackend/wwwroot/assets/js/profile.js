const authorInput = document.getElementById('author-name');
const authorName = getAuthorName();
loadingData(authorName, authorInput);

const timeInput = document.getElementById('online-time');
const authorTime = getOnlineTime();
loadingData(authorTime, timeInput);

const fanficsInfo = getFanfics();
const containers = document.querySelectorAll('.work-container[data-id]');

containers.forEach(container => {
  const id = container.dataset.id;
  const likes = container.querySelector(`#likes`);
  const name = container.querySelector(`#nameFanfic`);
  const description = container.querySelector(`#descriptionFanfic`);

  name.setAttribute('style', 'cursor: pointer;');

  const [nameInfo, likesInfo, descriptionInfo, link] = fanficsInfo[id];
  //console.log([nameInfo, likesInfo, descriptionInfo]);

  if (nameInfo === null || descriptionInfo === null) {
    container.remove();
  } else {
    name.textContent = nameInfo;
    description.textContent = descriptionInfo;
  }

  likes.textContent = likesInfo || 0;

  name.setAttribute('data-link', link);
  name.addEventListener('click', () => {
    const link = name.getAttribute('data-link');
    window.location.href = link;
  });
});

const allWorksBtn = document.querySelector('#allWorks');
const hrefAllWorks = getHrefAllWorks();
allWorksBtn.setAttribute('href', hrefAllWorks);
allWorksBtn.addEventListener('click', () => {
  window.location.href = hrefAllWorks;
});

const exitBtn = document.querySelector('#exit');
exitBtn.addEventListener("click", exit);

const image = document.getElementById('profileAvatar');
image.setAttribute('src', getAvatar());

function getAvatar() {
    if (true) {
        return "/assets/images/img5.png";
    }
    else {
        return "/assets/images/profile-author.svg";
    }
}

function getFanfics() {
    return [['Автомобилисты плачут и платят', '9', 'Это история о том, как бедный студент Василий решил преобрести себе машину, чтобы ездить на пары. Но он не знал, оо! Он не знал, что есть бензин и налоги. А еще кривые дороги!', 'fanfic-page.html'], 
['Юра и пельмехи', '999', 'Юра решил сварить пельмехи. Кто знал, что в этот момент в его стене откроется портал в другое измерение и оттуда выпадет жуткое существо? Что ж, теперь ужин не будет таким одиноким', 'fanfic-page.html'],
[null, null, null, null]];
}

function exit() {
    alert('Вы вышли из профиля');
}

function getHrefAllWorks() {
    return 'all-author\'s-work.html'
}

function getAuthorName() {
    return 'SoftOwl256';
}

function getOnlineTime() {
    return '17 минут назад';
}

function loadingData(base, id) {
    const textNode = document.createTextNode(base);
    id.appendChild(textNode);
}