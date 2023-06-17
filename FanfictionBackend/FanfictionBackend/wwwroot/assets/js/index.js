const fanficsInfo = getFanfics();
addFanficsRow();

const authorsBtn = document.getElementById('authorsBtn');
authorsBtn.addEventListener('click', () => {
  window.location.href = 'authors-list.html';
});

function getFanfics() {
    return [['Автомобилисты плачут и платят', '9', 'Это история о том, как бедный студент Василий решил преобрести себе машину, чтобы ездить на пары. Но он не знал, оо! Он не знал, что есть бензин и налоги. А еще кривые дороги!', 'fanfic-page.html'], 
['Юра и пельмехи', '999', 'Юра решил сварить пельмехи. Кто знал, что в этот момент в его стене откроется портал в другое измерение и оттуда выпадет жуткое существо? Что ж, теперь ужин не будет таким одиноким', 'fanfic-page.html'],
['Автовокзал', '268', 'Люди отправлялись на автовокзал, вывозящий их из города, как к точке спасения, к месту, где они обретут новую жизнь. Но никто из них не знал, что автобусы везут совсем не в райские места', 'fanfic-page.html']];
}


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
