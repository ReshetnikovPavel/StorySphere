const authorInput = document.getElementById('author-name');
const authorName = getAuthorName();
loadingData(authorName, authorInput);

const timeInput = document.getElementById('online-time');
const authorTime = getOnlineTime();
loadingData(authorTime, timeInput);

const likesInput1 = document.getElementById('likes1');
const likesInput2 = document.getElementById('likes2');
const likesInput3 = document.getElementById('likes3');
const likes1 = getFanficLikes1();
const likes2 = getFanficLikes2();
const likes3 = getFanficLikes3();
loadingData(likes1, likesInput1);
loadingData(likes2, likesInput2);
loadingData(likes3, likesInput3);

const nameFanficInput1 = document.getElementById('nameFanfic1');
const nameFanficInput2 = document.getElementById('nameFanfic2');
const nameFanficInput3 = document.getElementById('nameFanfic3');
const nameFanfic1 = getFanficName1();
const nameFanfic2 = getFanficName2();
const nameFanfic3 = getFanficName3();
loadingData(nameFanfic1, nameFanficInput1);
loadingData(nameFanfic2, nameFanficInput2);
loadingData(nameFanfic3, nameFanficInput3);

const descriptionInput1 = document.getElementById('descriptionFanfic1');
const descriptionInput2 = document.getElementById('descriptionFanfic2');
const descriptionInput3 = document.getElementById('descriptionFanfic3');
const descriptionFanfic1 = getFanficDescription1();
const descriptionFanfic2 = getFanficDescription2();
const descriptionFanfic3 = getFanficDescription3();
loadingData(descriptionFanfic1, descriptionInput1);
loadingData(descriptionFanfic2, descriptionInput2);
loadingData(descriptionFanfic3, descriptionInput3);

const allWorksBtn = document.querySelector('#allWorks');
const hrefAllWorks = getHrefAllWorks();
allWorksBtn.setAttribute('href', hrefAllWorks);
allWorksBtn.addEventListener('click', () => {
  window.location.href = hrefAllWorks;
});

const exitBtn = document.querySelector('#exit');
exitBtn.addEventListener("click", exit);

const imageContainer = document.getElementById('profileAvatar');
const image = document.createElement('img');
image.src = getAvatar();
imageContainer.appendChild(image);

function getAvatar() {
    if (true) {
        return "/assets/images/profile-author.svg";
    }
    else {
        return "/assets/images/profile-author.svg";
    }
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

function getFanficName1() {
    return 'Автомобилисты плачут и платят';
}

function getFanficName2() {
    return 'Юра и пельмехи';
}

function getFanficName3() {
    return 'Польза ядерного рефакторинга';
}

function getFanficDescription1() {
    return 'Это история о том, как бедный студент Василий решил преобрести себе машину, чтобы ездить на пары. Но он не знал, оо! Он не знал, что есть бензин и налоги. А еще кривые дороги!'
}

function getFanficDescription2() {
    return 'Юра решил сварить пельмехи. Кто знал, что в этот момент в его стене откроется портал в другое измерение и оттуда выпадет жуткое существо? Что ж, теперь ужин не будет таким одиноким';
}

function getFanficDescription3() {
    return 'Ну сами понимаете. Важно! полезно! никто не пользуется, пока все не станет плохо!';
}

function getFanficLikes1() {
    return '9';
}

function getFanficLikes2() {
    return '900';
}

function getFanficLikes3() {
    return '666';
}