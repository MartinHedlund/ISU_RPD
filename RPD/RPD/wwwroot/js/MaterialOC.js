
function funChek(event) {
    var panel = $(this).closest('.sum-form-wraper');
    var form = $(this).closest('.sum-form');
    var maxSum = parseInt(panel[0].previousElementSibling.children[0].querySelector('.SummBall').value);
    var maxSumDob = 15;
    var sum = 0;

    if ($(this).hasClass('sum-input')) {
        $('.sum-input', panel).each(function () {
            var inputValue = parseFloat($(this).val()) || 0;
            sum += inputValue;
        });
        if (sum != maxSum) {
            $(this).addClass('is-invalid');
            $(this).removeClass('is-valid');
            //form.removeClass('was-validated');
            //$(this).addClass('input-validation-error');
            //$(this).attr('data-bs-toggle', 'tooltip');
            //$(this).attr('data-bs-placement', 'top');
            //$(this).attr('title', 'Сумма значений больше допустимого');
            //$(this).tooltip('show');
        } else {
            $(this).removeClass('is-invalid');
            $(this).addClass('is-valid');
            //$(this).removeClass('input-validation-error');
            //$(this).tooltip('dispose');
            //$(this).removeAttr('data-bs-toggle');
            //$(this).removeAttr('data-bs-placement');
            //$(this).removeAttr('title');
            //$(this).tooltip('hide');
        }
        var isValid = true;
        if (sum == maxSum) {
            $('.sum-input', panel).each(function () {
                $(this).removeClass('is-invalid');
                $(this).addClass('is-valid');
                $(this).tooltip('dispose');
                $(this).removeAttr('data-bs-toggle');
                $(this).removeAttr('data-bs-placement');
                $(this).removeAttr('title');
            });
        }
    }
    else if ($(this).hasClass('sum-input-dob')) {
        $('.sum-input-dob', panel).each(function () {
            var inputValue = parseFloat($(this).val()) || 0;
            sum += inputValue;
        });
        if (sum > maxSumDob) {
            $(this).addClass('is-invalid');
            $(this).removeClass('is-valid');
            form.removeClass('was-validated');
            $(this).addClass('input-validation-error');
            $(this).attr('data-bs-toggle', 'tooltip');
            $(this).attr('data-bs-placement', 'top');
            $(this).attr('title', 'Сумма > 15');
            $(this).tooltip('show');
        } else {
            $(this).removeClass('is-invalid');
            $(this).addClass('is-valid');
            $(this).removeClass('input-validation-error');
            $(this).tooltip('dispose');
            $(this).removeAttr('data-bs-toggle');
            $(this).removeAttr('data-bs-placement');
            $(this).removeAttr('title');
            //$(this).tooltip('hide');
        }
        var isValid = true;
        if (sum <= maxSumDob) {
            $('.sum-input-dob', panel).each(function () {
                $(this).removeClass('is-invalid');
                $(this).addClass('is-valid');
                $(this).tooltip('dispose');
                $(this).removeAttr('data-bs-toggle');
                $(this).removeAttr('data-bs-placement');
                $(this).removeAttr('title');
            });
        }
    }

}
function chekform (event) {
    var isValid = true;
    var form = $(this).closest('.sum-form');
    $('.sum-form .sum-input-dob').trigger('input');
    $('.sum-form .sum-input').trigger('input');
    $('.sum-form .SummBall').trigger('input');
    // Проверка значений на форме
    $('.sum-input', form).each(function () {
        if ($(this).hasClass('is-invalid')) {
            isValid = false;
        }
    });
    $('.SummBall', form).each(function () {
        if ($(this).hasClass('is-invalid')) {
            isValid = false;
        }
    });
    $('.sum-input-dob', form).each(function () {
        if ($(this).hasClass('is-invalid')) {
            isValid = false;
        }
    });
    // Отмена отправки формы
    if (!isValid) {
        event.preventDefault()
        event.stopPropagation()
    }
    else 
        form.addClass('was-validated')
}
function SumChek(event) {
    var sum = 0;
    var maxSumTK = 55;
    var isValid = true;
    var form = $(this).closest('.sum-form');
    var listsuminput = $(this).closest('.sum-form')[0].querySelectorAll('.SummBall');
    //listsuminput.forEach(function (e) {
    //    var inputValue = parseFloat(e.value) || 0;
    //    sum += inputValue
    //});
    $('.SummBall', form).each(function () {
        var inputValue = parseFloat($(this).val()) || 0;
        sum += inputValue;
    });

    if (sum != maxSumTK) {
        var isValid = false;
        
    }
    else {
        var isValid = true;
    }
    $('.SummBall', form).each(function () {
        if (isValid) {
            $(this).removeClass('is-invalid');
            $(this).addClass('is-valid');
        } else {
            $(this).addClass('is-invalid');
            $(this).removeClass('is-valid');
        }
    });
}
function downloadTemlate() {
    window.location.href = '/MaterialOC/DownLoadTemplate/';
}
function uploadFile(event) {
    event.preventDefault(); // предотвращаем стандартное поведение формы
    var formData = new FormData(this); // создаем объект FormData

    $.ajax({
        url: '/MaterialOC/UploadFilePKZ/', // адрес метода контроллера ASP.NET Core
        type: 'POST',
        data: formData, // данные из формы
        processData: false, // отключаем обработку данных перед отправкой
        contentType: false, // отключаем установку заголовка Content-Type
        beforeSend: function () {
            //$(`#btnUpload`).hide();
            //$('#loading').show(); // показываем анимацию загрузки
        },
        complete: function () {
            //$(`#btnUpload`).show();
            //$('#loading').hide(); // скрываем анимацию загрузки
        },
        success: function (result) {
            // обработка успешного ответа от сервера
            alert("Файл загружен")
        },
        error: function (xhr, status, error) {
            alert(xhr.responseText)
            // обработка ошибки
        }
    });
}
function download() {
    $.ajax({
        url: "/MaterialOC/DownloadFile/",
        type: 'GET',
        xhrFields: {
            responseType: 'blob' // Устанавливаем тип ответа как blob (двоичные данные)
        },
        success: function (response) {
            // Создаем ссылку на загруженный файл
            var url = window.URL.createObjectURL(response);

            // Создаем ссылку для скачивания файла
            var link = document.createElement('a');
            link.href = url;
            
            link.download = "PKZ.docx"; // Получаем имя файла из заголовков ответа

            // Добавляем ссылку на страницу и эмулируем клик для начала загрузки файла
            document.body.appendChild(link);
            link.click();

            // Освобождаем ресурсы URL
            window.URL.revokeObjectURL(url);

            // Удаляем ссылку из DOM
            document.body.removeChild(link);
        },
        error: function (result) {
            alert("Нет файла в системе. Проверьте что вы загрузили файл.");
        }
    });
    //window.location.href = '/MaterialOC/DownloadFile/';
}
function downdelete() {
    $.ajax({
        type: "POST",
        url: "/MaterialOC/DeletePKZFile/",
        success: function (result) {
            alert("Файл удалён!")
        },
        error: function () {
            alert("Ошибка при удаление!");
        }
    });
}
$(document).ready(function (event) {
    $('#BtnDownloadTemplate').on('click', downloadTemlate);
    $('#BtnDownload').on('click', download);
    $('#BtnDelete').on('click', downdelete);
    $('#UploadFileFormPKZ').submit(uploadFile);
    // Инициализация tooltip
    $('[data-bs-toggle="tooltip"]').tooltip();

    $('.sum-form .sum-input').on('input', funChek);
    $('.sum-form .sum-input').on('blur', funChek);

    $('.sum-form .sum-input-dob').on('input', funChek);
    $('.sum-form .sum-input-dob').on('blur', funChek);

    $('.sum-form .SummBall').on('input', SumChek);
    $('.sum-form .check-btn').on('click', chekform);
    // Ниже можно пихать обработчики
    $('.sum-form .sum-input-dob').trigger('input');
    $('.sum-form .sum-input').trigger('input');
    $('.sum-form .SummBall').trigger('input');

   
    });
function deleteRow(button) {
    var row = button.parentNode.parentNode;
    row.parentNode.removeChild(row);
}
function _textAjax(i, j, idChapter, selectet) {
    var id = selectet.value;
    $.ajax({
        update: `#panel${i}_${j}`,
        mode: "after",
        data: { sem: i, razdel: j, id: id },
        type: "POST",
        url: "/MaterialOC/ParticalOCList/",
        success: function (html) {
            $(`#panel${i}_${j}`).append(html);
            var target = $(`#panel${i}_${j}`);
            _hidenNameParcheList(j, idChapter, target);
        },
        error: function () {
            console.log("Errrrrroororororo");
        }
    });
}

function _hidenNameParcheList(razdel, idCh, target) {
    /* var target = $($(this)[0].$wrapper).parent()[0];*/
    var childrens = target.children();

    for (var i = 0; i < childrens.length; i++) {
        console.log(childrens[i]);
        var idEvT = childrens[i].querySelectorAll('#blockId')[0];
        var idChapter = childrens[i].querySelectorAll('#idChapter')[0];
        var ballEvT = childrens[i].querySelectorAll('#ballEvT')[0];
        var dopballEvT = childrens[i].querySelectorAll('#dopballEvT')[0];
        if (idEvT != null && idChapter != null && ballEvT != null && dopballEvT != null) {
            idEvT.attributes['name'].nodeValue = `razdels[${razdel}].EvaluationToolsOthers[${i}].ListAllEvaluationToolsIDId`;
            idChapter.attributes['name'].nodeValue = `razdels[${razdel}].EvaluationToolsOthers[${i}].ChapterId`;
            idChapter.attributes['value'].nodeValue = `${idCh}`;
            ballEvT.attributes['name'].nodeValue = `razdels[${razdel}].EvaluationToolsOthers[${i}].Ball`;
            dopballEvT.attributes['name'].nodeValue = `razdels[${razdel}].EvaluationToolsOthers[${i}].DopBall`;
            console.log(idEvT);
            console.log(ballEvT);
            console.log(dopballEvT);
            console.log(idChapter);
        }

    }

    $('[data-bs-toggle="tooltip"]').tooltip();
    $('.sum-form .sum-input').on('input', funChek);
    $('.sum-form .sum-input').on('blur', funChek);

    $('.sum-form .sum-input-dob').on('input', funChek);
    $('.sum-form .sum-input-dob').on('blur', funChek);
}
