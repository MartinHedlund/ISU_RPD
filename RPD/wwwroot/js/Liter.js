$(document).ready(function () {
    $('.disablecheck').on('click', function (event) {
        event.preventDefault();
    });
});

function ChangeTypeLiter(value, IdLiter) {
    $.ajax({
        url: '/Mtod/ChangeTypeLiter',
        type: "POST",
        data: { IdType: value, IdLiter: IdLiter },
        success: function (data) {
            //alert(message);
        },
        error: function () {
            alert('Произошла ошибка ');
        }
    });
}

function DelLiter(event) {
    var IdLiter = event.currentTarget.id;
    $.ajax({
        url: '/Mtod/DeleteLiter',
        type: "POST",
        data: { IdLiter: IdLiter },
        success: function (data) {
            alert('Удалено');
            var tr = $(event.target).closest('tr');
            tr.remove();
            $(".table tbody tr").each(function () {
                var checkbox = $(this).find("input[type='checkbox']");
                var targetId = "Check_"+IdLiter;
                if (checkbox.length > 0 && checkbox.attr("id") === targetId) {
                    checkbox.prop("checked", false);
                }
            });
        },
        error: function () {
            alert('Произошла ошибка удаления');
        }
    });

}

function LiterClick(id) {
    var IdLiter = id;

    var url;
    var message;
    var row = event.target.parentElement;
    var checkbox = $(row).find("input[type='checkbox']")[0];
    var ischek = checkbox.checked;
    //true отправляешь
    //flase удаляешь

    if (!ischek) {
        url = '/Mtod/AddLiter';
        message = 'Добавлено';
        checkbox.checked = !checkbox.checked;
    }
    else {
        url = '/Mtod/DeleteLiter';
        message = 'Удалено';
        checkbox.checked = !checkbox.checked;
    }

    $.ajax({
        url: url,
        type: "POST",
        data: { IdLiter: IdLiter },
        success: function (data) {
            
        },
        error: function () {
            alert('Произошла ошибка');
        }
    });

}

function LiterChois() {
    $.ajax({
        url: '/Mtod/GetLiter',
        type: "GET",
        success: function (data) {
            $("#staticBackdrop").modal("show");
            document.getElementsByClassName('LiterChois')[0].innerHTML = data;
            $(document).ready(function () {
                $(".SelectTypeLiter").selectize({
                    sortField: "text",
                    onChange: function (value) {
                        var select = $(this); // Получаем ссылку на текущий select
                        var svgId = select[0].$input.attr("id"); // Получаем значение id у svg

                        ChangeTypeLiter(value, svgId);
                    }
                });
            });
        },
        error: function () {
            alert('Нет выбранной литературы');
            $("#staticBackdrop").modal("hide");
        }
    });
}