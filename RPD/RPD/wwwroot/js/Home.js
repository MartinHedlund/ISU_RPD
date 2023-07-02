var EventRow;
var ChoisDev = document.getElementsByClassName('ChoisDev');
var DelRpd = document.getElementsByClassName("DelRpd");
var CreateRPD = document.getElementsByClassName("CreateRPD");
var OpenRPD = document.getElementsByClassName("OpenRPD");

function DelRPD() {
    var IdRpd = EventRow.querySelector(".Idrpd").innerText;
    var conf = confirm("Вы хотите удалить РПД?");
    if (conf) {
        $.ajax({
            data: { IdRpd: IdRpd },
            type: "POST",
            url: '/Home/DelRPD/',
            success: function () {
                EventRow.querySelector(".ChekedRPD").innerText = "False";
                EventRow.querySelector(".StatusRpd").innerText = "Не создано";
                DelRpd[0].setAttribute('disabled', 'disabled');
                CreateRPD[0].removeAttribute('disabled');
                OpenRPD[0].setAttribute('disabled', 'disabled');
                alert("Удалено");
            },
            error: function () {
                // Обработка ошибки
                alert("Произошла ошибка при удалении");
            }
        });
    }

}

function filterSelect() {

    var selectElement = document.getElementsByClassName("FilterSelect")[0];
    var selectedValue = selectElement.value;
    $(".Main").filter(function () {
        var text = $(this).children().eq(6).text();
        var shouldShow = (selectedValue === "all" || text === selectedValue);
        $(this).toggle(shouldShow);
    });
}

function commentAdd(event) {
    var IdStroka = event.data.IdStroka;
    var commentText = $("#commentText").val();
    $.ajax({
        data: {CommentText: commentText, IdStroka: IdStroka},
        type: "POST",
        url: '/FunctionPanel/AddComment/',
        success: function (result) {
            var cell = EventRow.querySelector('.commentcell');
            var dateStr = result["createdAt"];
            var date = new Date(dateStr);
            var day = date.getDate().toString().padStart(2, '0');
            var month = (date.getMonth() + 1).toString().padStart(2, '0');
            var year = date.getFullYear().toString();
            var formattedDate = `${day}.${month}.${year}`;
            code = `<p>
                ${result["fio"]} (${formattedDate}): ${result["commentText"]}
            </p>`
            cell.innerHTML += code;
            // Обработка успешного ответа от сервера
            $("#commentModal").modal("hide");
            $("#commentText").val() = '';
            //alert("Комментарий успешно добавлен!");
        },
        error: function (xhr, status, error) {
            // Обработка ошибки
            alert("Произошла ошибка при добавлении комментария: " + error.Message);
        }
    });
};

function ClickMain(event, IdStroka) {

    EventRow = event.currentTarget;

    if (ChoisDev.length != 0) {
        ChoisDev[0].id = IdStroka;
        ChoisDev[0].removeAttribute('disabled');
    }

    CreateRPD[0].setAttribute('formaction', `/Home/CreateRPD/${IdStroka}`);

    $("#submitCommentBtn").off("click").on("click", { IdStroka: `${IdStroka}` }, commentAdd);

    OpenRPD[0].setAttribute('formaction', `/Home/OpenRPD/${IdStroka}`);

    var ChekRPD = event.currentTarget.querySelector(".ChekedRPD").textContent;
    if (ChekRPD == 'True') {
        DelRpd[0].removeAttribute('disabled');
        OpenRPD[0].removeAttribute('disabled');
        CreateRPD[0].setAttribute('disabled', 'disabled');
    }
    else {
        DelRpd[0].setAttribute('disabled', 'disabled');
        CreateRPD[0].removeAttribute('disabled');
        OpenRPD[0].setAttribute('disabled', 'disabled');
    }

    document.querySelector("#commentBtn").removeAttribute('disabled');
}

function ChoisDevelop(event) {
  
    var img = document.createElement("img");
    img.src = "/img/Down.gif";
    img.height = 150;
    img.style.display = "block";
    img.style.margin = "auto";
    img.width = 150;
    document.getElementsByClassName("modalUchPlan")[0].innerHTML = "";
    document.getElementsByClassName("modalUchPlan")[0].appendChild(img);
    let IdStroka = event.target.id;

    $.ajax({
        mode: "after",
        data: { IdStroka: IdStroka },
        type: "POST",
        url: "/Home/AccessUchPlan/",
        success: function (Html) {
            document.getElementsByClassName("modalUchPlan")[0].innerHTML = Html;

            $(document).ready(function () {
                $(".UsersAll").selectize({
                    sortField: "text",
                    multiple: true,
                });
            });
           
        }
    });
}

function SaveUsersAccess() {
    var selectize = document.querySelector(".UsersAll").selectize; // Получение экземпляра Selectize

    var TimeLimits = document.querySelector(".CreationTimeLimits").value;
    var idStoka = selectize.$input[0].id;

    var selectedItems = selectize.getValue(); // Получение массива выбранных элементов


    var selectedTexts = []; // Создаем пустой массив для хранения текстов выбранных элементов

    selectedItems.forEach(function (item) { // Перебираем массив выбранных элементов
        var text = selectize.options[item].text; // Получаем текст элемента по его ID
        selectedTexts.push(text); // Добавляем текст элемента в массив
    });
    // Формируем строку с выбранными пользователями
    var usersHtml = "";
    selectedTexts.forEach(function (text) {
        usersHtml += "<div>" + text + "</div>";
    });


    $.ajax({
        mode: "after",
        data: { IdStroka: idStoka, UsersId: selectedItems, TimeLimits: TimeLimits },
        type: "POST",
        url: "/Home/SaveChoisAccessUchPlan/",
        success: function (Html) {

            GetDiscip(document.getElementsByClassName("IdDiscip")[0].innerText);
        }
    });
    const date = new Date(TimeLimits);

    // Получаем день, месяц и год
    const day = date.getDate();
    const month = date.getMonth() + 1; // Месяцы начинаются с 0, поэтому добавляем 1
    const year = date.getFullYear();

    // Форматируем дату в "dd.mm.yyyy"
    const formattedDate = `${day < 10 ? "0" + day : day}.${month < 10 ? "0" + month : month}.${year}`;
    EventRow.querySelector(".TimeCreator").innerHTML = formattedDate;
    EventRow.querySelector(".UsersDev").innerHTML = usersHtml;


}

