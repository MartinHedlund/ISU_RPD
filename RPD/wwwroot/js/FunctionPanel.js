$(document).ready(function () {
   
    // обработка формы отправки фала списка литературы
    $('#UploadFileForm').submit(function (event) {
        event.preventDefault(); // предотвращаем стандартное поведение формы
        var formData = new FormData(this); // создаем объект FormData

        $.ajax({
            url: '/FunctionPanel/UploadFile', // адрес метода контроллера ASP.NET Core
            type: 'POST',
            data: formData, // данные из формы
            processData: false, // отключаем обработку данных перед отправкой
            contentType: false, // отключаем установку заголовка Content-Type
            beforeSend: function () {
                $(`#btnUpload`).hide();
                $('#loading').show(); // показываем анимацию загрузки
            },
            complete: function () {
                $(`#btnUpload`).show();
                $('#loading').hide(); // скрываем анимацию загрузки
            },
            success: function (result) {
                // обработка успешного ответа от сервера
                alert("Файл загружен. Таблица обновленна")
            },
            error: function (xhr, status, error) {
                alert(xhr.responseText)
                // обработка ошибки
            }
        });
    });

    $("#AdminBtn").on("click", GetPatrUserRole);
    

    // Обработчик события для кнопки "Оставить комментарий"
    $("#commentBtn").on("click", function () {
        $("#commentModal").modal("show");
    });
    $("#UploadLiterBtn").on("click", function () {
        $("#myModalLiter").modal("show");
    });
    $("#CloseUploadLiterBtn").on("click", function () {
        $("#myModalLiter").modal("hide");
    });

    $(".closeCommentBtn").on("click", function () {
        $("#commentText").val("");
        $("#commentModal").modal("hide");
    });

    // Обработчик события для кнопки "Закрыть"
    $("#commentModal").on("hidden.bs.modal", function () {
        $("#commentText").val("");

        // Обработчик события для кнопки "Отправить"
        //$("#submitCommentBtn").on("click", commentAdd);
    });
});

function ChangeRole(idRole) {
    var userId = $("#selectUser").selectize()[0].selectize.items[0];
    $.ajax({
        type: "POST",
        data: { UserId: userId, roleId: idRole},
        url: "/FunctionPanel/ChangeRole/",
        success: function (Html) {
            
        }
    });
}

function changeUserAjax(select) {
    var iduser = select.value;
    $.ajax({
        mode: "replase",
        type: "POST",
        data: { UserId: iduser },
        url: "/FunctionPanel/GetUserRole/",
        success: function (Html) {
            $('#partRoles').html(Html);
        }
    });
}

function GetPatrUserRole() {
    $.ajax({
        mode: "replase",
        type: "GET",
        url: "/FunctionPanel/GetUserAdmin/",
        success: function (Html) {
            $('.modalUserRoles').html(Html);

            $(document).ready(function () {
                $(".UsersAll").selectize({
                    sortField: "text",
                    multiple: true,
                });
            });
        }
    });
}