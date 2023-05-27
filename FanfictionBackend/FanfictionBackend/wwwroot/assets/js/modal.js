const modal = document.createElement('modal');
const profileBtn = document.querySelector(".profile-button");
const closeBtn = document.querySelector(".close-button");

modal.innerHTML = `
    <div class="modal">
        <div class="modal-content">
            <img src="/assets/images/cross-icon.svg" class="close-button"/>
            <h1>Вход</h1>
            <form>
                <div class="field">
                    <label for="email">Электронная почта:</label>
                    <input type="email" id="email" required/>
                </div>
                <div class="field">
                    <label for="password">Пароль:</label>
                    <input type="password" id="password" required/>
                </div>
                
                <button>Войти</button>
                <button>Зарегистрироваться</button>
            </form>
        </div>
    </div>
`;
document.body.appendChild(modal);

// profileBtn.onclick = function() {
//   modal.style.display = "flex";
// };

// closeBtn.onclick = function() {
//   modal.style.display = "none";
// };

// window.onclick = function(e) {
//   if (e.target == modal) {
//     modal.style.display = "none";
//   }
// };


