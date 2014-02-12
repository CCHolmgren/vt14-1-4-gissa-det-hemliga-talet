window.onload = function () {
    var button = document.getElementById("GuessButton");
    button.addEventListener("click", function () {
        var textbox = document.getElementById("Guess");
        textbox.focus();
        textbox.select();
    });
}