
const btns = document.querySelectorAll(".tab__btn");
const tabItems = document.querySelectorAll(".tab__item")

btns.forEach(btnClick);

function btnClick(item) {
    item.addEventListener("click", () => {
        let currentBtn = item;
        let tabId = currentBtn.getAttribute("data-tab");
        let currentTab = document.querySelector(tabId);

        if ( !currentBtn.classList.contains('active__btn')){
            btns.forEach((item) =>
                item.classList.remove('active__btn')
            )

            tabItems.forEach((item) =>
                item.classList.remove('active__tab')
            )

            currentBtn.classList.add('active__btn')
            currentTab.classList.add('active__tab')
        }


    })
}

document.querySelector('.tab__btn').click();






