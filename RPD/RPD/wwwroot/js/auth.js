var Gif = document.getElementsByClassName("gif");
var Buttom = document.getElementsByClassName("ButAuth");

function SigIn_Valid() {

 

    var login = $('#floatingLogin').val();
    var pass = $('#floatingPassword').val();

    Gif[0].removeAttribute('hidden');
    Buttom[0].setAttribute('hidden', 'hidden');


    event.preventDefault();
    $.ajax({
        url: "/Autoriz/SignIn",
        type: "POST",
        data: { Login: login, Password: pass },
        success: function (data) {
            if (data.success) {
                // Обработка успешного ответа
                window.location.href = '/Home/Index';
            } else {
                // Обработка ошибки
                alert('Произошла ошибка: ' + data.message);
            }
        },
        error: function () {
            $("input").addClass('is-invalid');
            Buttom[0].removeAttribute('hidden');
            Gif[0].setAttribute('hidden', 'hidden');
        }
    });
}

$(document).ready(function (event) {
    $("form").submit(SigIn_Valid);
});

