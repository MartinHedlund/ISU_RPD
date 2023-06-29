$(document).ready(function () {
    $('.disablecheck').on('click', function (event) {
        event.preventDefault();
    });
});

function ProductTechesClick(id) {
    var ProductT = id;

    var url;
    var message;
    var row = event.target.parentElement;
    var checkbox = $(row).find("input[type='checkbox']")[0];
    var ischek = checkbox.checked;
    //true отправляешь
    //flase удаляешь

    if (!ischek) {
        url = '/Mtod/AddProductTech';
        message = 'Добавлено';
        checkbox.checked = !checkbox.checked;
    }
    else {
        url = '/Mtod/DeleteProductTech';
        message = 'Удалено';
        checkbox.checked = !checkbox.checked;
    }

    $.ajax({
        url: url,
        type: "POST",
        data: { idProd: ProductT },
        success: function (data) {
        },
        error: function () {
            alert('Произошла ошибка');
        }
    });
}


    function ProductChois() {
        $.ajax({
            url: '/Mtod/GetProduct',
            type: "GET",
            success: function (data) {
                $("#staticBackdrop").modal("show");
                document.getElementsByClassName('ProductChois')[0].innerHTML = data;
                $(".SelectTypeLiter").selectize({
                    sortField: "text",
                    //onChange: function (value) {
                    //    var select = $(this); // Получаем ссылку на текущий select
                    //    var svgId = select[0].$input.attr("id"); // Получаем значение id у svg

                    //    ChangeTypeLiter(value, svgId);
                    //}
                });
            },
            error: function () {
                alert('ПО не выбрано');
                $("#staticBackdrop").modal("hide");
            }
        });
    }

function DelProdTech(event) {
    var idProd = event.currentTarget.id;
    $.ajax({
        url: '/Mtod/DeleteProductTech',
        type: "POST",
        data: { idProd: idProd },
        success: function (data) {
            alert('Удалено');
            var tr = $(event.target).closest('tr');
            tr.remove();
            $(".table tbody tr").each(function () {
                var checkbox = $(this).find("input[type='checkbox']");
                var targetId = "Check_" + idProd;
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
