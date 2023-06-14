async function fetchFanficTitle(url) {
    const response = await fetch(url);
    if (!response.ok) {
        throw new Error(`HTTP error! Status: ${response.status}`);
    }
    const fanfic = await response.json();
    return fanfic.title;
  }
  
fetchFanficTitle('/hello')
    .then(title => alert(title))
    .catch(error => console.error('Error fetching fanfic title:', error));