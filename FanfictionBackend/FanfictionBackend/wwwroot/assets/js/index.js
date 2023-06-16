const fanficsInfo = getFanfics();
const containers = document.querySelectorAll('.work-container[data-id]');

containers.forEach(container => {
  const id = container.dataset.id;
  const likes = container.querySelector(`#likes`);
  const name = container.querySelector(`#nameFanfic`);
  const description = container.querySelector(`#descriptionFanfic`);

  const [nameInfo, likesInfo, descriptionInfo, link] = fanficsInfo[id];
  //console.log([nameInfo, likesInfo, descriptionInfo]);

  name.setAttribute('style', 'cursor: pointer;');

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

const authorsBtn = document.querySelector('#authorsBtn');
authorsBtn.setAttribute('href', 'authors-list.html');
authorsBtn.addEventListener('click', () => {
  window.location.href = 'authors-list.html';
});

function getFanfics() {
    return [['Автомобилисты плачут и платят', '9', 'Это история о том, как бедный студент Василий решил преобрести себе машину, чтобы ездить на пары. Но он не знал, оо! Он не знал, что есть бензин и налоги. А еще кривые дороги!', 'fanfic-page.html'], 
['Юра и пельмехи', '999', 'Юра решил сварить пельмехи. Кто знал, что в этот момент в его стене откроется портал в другое измерение и оттуда выпадет жуткое существо? Что ж, теперь ужин не будет таким одиноким', 'fanfic-page.html'],
['Автовокзал', '268', 'Люди отправлялись на автовокзал, вывозящий их из города, как к точке спасения, к месту, где они обретут новую жизнь. Но никто из них не знал, что автобусы везут совсем не в райские места', 'fanfic-page.html']];
}