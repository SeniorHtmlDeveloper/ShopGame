const inputList = document.querySelectorAll(".form__field");
const labelList = document.querySelectorAll(".form__lab");
const innerlList = document.querySelectorAll(".sign-up__inner");


console.log(inputList);
console.log("test");



document.addEventListener('click', function (e) {
    const box = e.composedPath().includes(document.querySelector("#sign-up__inner__1"));
    if (!box) {
        labelList[0].classList.remove("form__lab__active");
        console.log("remove");
    }
})

document.addEventListener('click', function (e) {
    const box = e.composedPath().includes(document.querySelector("#sign-up__inner__2"));
    if (!box) {
        labelList[1].classList.remove("form__lab__active");
        console.log("remove");
    }
})


// function onClickInput() {
//     labelList.classList.Add(".form__lab__active");
// };



for (let i = 0; i < inputList.length; i++) {
    inputList[i].addEventListener('click', function () {
        labelList[i].classList.add("form__lab__active");

        console.log("add");
    });
};