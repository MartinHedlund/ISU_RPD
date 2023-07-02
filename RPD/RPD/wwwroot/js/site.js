

$(document).ready(function () {

    //$(".DiscipPred").selectize({
    //    sortField: "text",
    //});
    $(".js-select2").selectize({
        sortField: "text",
    });
    //$('#submit').click(function () {
    //    var data = {
    //        content: CKEDITOR.instances.editor.getData()
    //    };
    $(".SelectChapterComp").selectize({
        sortField: "text",
        onInitialize: function () {
            var selectize = this;
            var selectWidth = selectize.$control.width();
            selectize.$control.width('250px'); // Устанавливаем ширину
            selectize.settings.placeholder = 'Выберите тип'; // Устанавливаем атрибут placeholder
            selectize.updatePlaceholder(); // Обновляем плейсхолдер
        }
        /*onItemAdd: _textAjax(i, j, value)*/
    });


    
    $(".TypeRoom").selectize({
        onInitialize: function () {
            var selectize = this;
            var selectWidth = selectize.$control.width();
            selectize.$control.width('150px'); // Устанавливаем ширину
            selectize.settings.placeholder = 'Выберите тип'; // Устанавливаем атрибут placeholder
            selectize.updatePlaceholder(); // Обновляем плейсхолдер
        }

    });


});

function GetYear(event) {
    var Year = event.currentTarget.value;
    var but = document.getElementsByClassName("GetNewYear")[0];
    but.attributes[2].nodeValue = `/Home/Index?Year=${Year}`
    but.click();
}



function GetDiscip(IdDiscip) {

    let Year = document.getElementsByClassName("ChoisYear")[0].value;
    let IdKaf = document.getElementsByClassName("Kafed")[0].id;
    let k = document.getElementsByClassName("AccessUchPlan");
    document.getElementsByClassName("AccessUchPlan")[0].disabled = true; // enable кнопки откртие доступа 
    $.ajax({
        
        mode: "after",
        data: { IdKaf: IdKaf, IdDiscip: IdDiscip, Yaer: Year},
        type: "POST",
        url: "/Home/ViewUchPlan/",
        beforeSend: function () {
            $("#loaderUchPlan").show();
            document.getElementsByClassName("UchPlanView")[0].innerHTML = "";
        },
        success: function (Html) {
            document.getElementsByClassName("UchPlanView")[0].innerHTML = Html;
            var divs = document.getElementsByClassName('UchPlanHome');
            // Обработчик события "click" для блоков div
            function divClickHandler() {
                // Удаляем класс "active" у всех блоков div
                for (var i = 0; i < divs.length; i++) {
                    divs[i].classList.remove('active');
                }

                // Добавляем класс "active" на блок div, по которому был произведен клик
                this.classList.add('active');
            }
            // Добавляем обработчик события "click" ко всем блокам div
            for (var i = 0; i < divs.length; i++) {
                divs[i].addEventListener('click', divClickHandler);
            }
        },
        complete: function () {
            $("#loaderUchPlan").hide();
        }
    });


}

function ViewUchPlanForDev() {
   
    document.getElementsByClassName("AccessUchPlan")[0].disabled = true; // enable кнопки откртие доступа 
    $.ajax({

        mode: "after",
        type: "POST",
        url: "/Home/ViewUchPlanForDev/",
        beforeSend: function () {
            $("#loaderCreatedRPD").show();

        },
        success: function (Html) {
            document.getElementsByClassName("UchPlanView")[0].innerHTML = Html;
            var divs = document.getElementsByClassName('UchPlanHome');
            // Обработчик события "click" для блоков div
            function divClickHandler() {
                // Удаляем класс "active" у всех блоков div
                for (var i = 0; i < divs.length; i++) {
                    divs[i].classList.remove('active');
                }

                // Добавляем класс "active" на блок div, по которому был произведен клик
                this.classList.add('active');
            }
            // Добавляем обработчик события "click" ко всем блокам div
            for (var i = 0; i < divs.length; i++) {
                divs[i].addEventListener('click', divClickHandler);
            }
        },
        complete: function () {
            $("#loaderCreatedRPD").hide();
        }
    });
}



function GetUchPlan(IdStroka) {
    document.getElementsByClassName("AccessUchPlan")[0].disabled = false; // enable кнопки откртие доступа 

    $.ajax({
        mode: "after",
        data: { IdStroka: IdStroka },
        type: "POST",
        url: "/Home/ViewRpd/",
        beforeSend: function () {
            $("#loaderCreatedRPD").show();
            document.getElementsByClassName("ToDoRPD")[0].innerHTML = "";
        },
        success: function (Html) {
            document.getElementsByClassName("ToDoRPD")[0].innerHTML = Html;
            var divs = document.getElementsByClassName('CompleteRPD');
            // Обработчик события "click" для блоков div
            function divClickHandler() {
                // Удаляем класс "active" у всех блоков div
                for (var i = 0; i < divs.length; i++) {
                    divs[i].classList.remove('active');
                }

                // Добавляем класс "active" на блок div, по которому был произведен клик
                this.classList.add('active');
            }
            // Добавляем обработчик события "click" ко всем блокам div
            for (var i = 0; i < divs.length; i++) {
                divs[i].addEventListener('click', divClickHandler);
            }
        },
        complete: function () {
            $("#loaderCreatedRPD").hide();
        }
    });
    const but = document.getElementsByClassName("CreateRPD")[0];
    but.innerText = "Создать"
    but.attributes[2].nodeValue = `/Home/CreateRPD?IdStroka=${IdStroka}`

    document.getElementsByClassName("AccessUchPlan")[0].id = IdStroka;
}

function ShowAccessUchPlan(event) {
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

function ChoisCompletRPD(IdRpd) {
    const but = document.getElementsByClassName("CreateRPD")[0];
    but.innerText = "Открыть";
    but.attributes[2].nodeValue = `/Home/OpenRPD?IdRPD=${IdRpd}`
}


function Search(event, k) {
    // Объявить переменные
    var input, filter, table, tr, td, i, txtValue;
    input = event.currentTarget;
    filter = input.value.toUpperCase();
    table = document.getElementById("myTable");
    tr = table.getElementsByTagName("tr");

    // Перебирайте все строки таблицы и скрывайте тех, кто не соответствует поисковому запросу
    for (i = 2; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[k];
        if (td) {
            txtValue = td.textContent || td.innerText;
            if (txtValue.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}

function initSelectize(element) {
    $(element).selectize({
        // Опции и настройки для Selectize...
        onInitialize: function () {
            var selectize = this;
            var selectWidth = selectize.$control.width();
            selectize.$control.width('250px'); // Устанавливаем ширину
            selectize.settings.placeholder = 'Выберите тип'; // Устанавливаем атрибут placeholder
            selectize.updatePlaceholder(); // Обновляем плейсхолдер
        }
    });
}

function Chois(event, id) {

    let ChBox = event.currentTarget;
    let el = event.currentTarget.parentElement.parentElement.children;
    if (ChBox.checked == true) {
        let tr = document.createElement('tr');
        tr.id = `Chois_${el[1].innerText}`;
        RoomNumber = el[1].innerText;
        Desc = el[2].innerText;
        Equipment = el[3].innerText;
    

        code = `
                        <td> <input class="inpLab" type="hidden"  name="ChoisClassRoom" value="${id}" /></td>
                        <td>${RoomNumber}</td>
                        <td>${Desc}</td>
                         <td width="50px"><select  multiple >
                            <option value="1">Лекция</option>
                            <option value="2">Практика</option>
                            <option value="3">Лаб.работа</option>
                            <option value="4">СРС</option>
                        </select></td>`;
        let item = document.querySelector(`.tasks__list`);
        tr.innerHTML = code;
        item.appendChild(tr);
        initSelectize(tr.children[3].children[0])


        //$(document).ready(function () {
        //    $(".TypeRoom").selectize({
        //        sortField: "text",
        //    });
        //});

    }
    else {
        document.getElementById(`Chois_${el[1].innerText}`).remove();
    }
    Index();

}

function Index() {
    let item = document.querySelector(`.tasks__list`).children;
    for (var i = 1; i < item.length; i++) {

        item[i].children[0].children[0].name = `CCRoom[${i - 1}].IdClassRoom`;
        item[i].children[3].children[0].name = `CCRoom[${i - 1}].TypeClassRoom[]`;

    }


 
}

//function ShowHours(Count) {
//    let Allitog = 0;
//    let Alllab = 0;
//    let Allpr = 0;
//    let Alllek = 0;
//    let Allsrs = 0;

//    for (var i = 0; i < Count; i++) {
//        let itog = 0;
//        let Lab = 0;
//        let Pr = 0;
//        let Lek = 0;
//        let Srs = 0;

//        let AllItog = document.querySelectorAll(`.AllH_${i}`);
//        for (var it = 0; it < AllItog.length; it++) {
//            itog = itog + Number(AllItog[it].textContent);
//        }

//        Allitog = Allitog + itog;
//        document.getElementsByClassName(`itog_${i}`)[0].textContent = itog;

//        let AllLab = document.querySelectorAll(`.Lab_${i}`);
//        for (var la = 0; la < AllLab.length; la++) {
//            Lab = Lab + Number(AllLab[la].textContent);
//        }
//        Verify(Lab, `TLab_${i}`, `itogLab_${i}`);
//        Alllab = Alllab + Lab;
//        document.getElementsByClassName(`itogLab_${i}`)[0].textContent = Lab;

//        let AllPr = document.querySelectorAll(`.Pr_${i}`);
//        for (var p = 0; p < AllPr.length; p++) {
//            Pr = Pr + Number(AllPr[p].textContent);
//        }
//        Verify(Pr, `TPr_${i}`, `itogPr_${i}`);
//        Allpr = Allpr + Pr;
//        document.getElementsByClassName(`itogPr_${i}`)[0].textContent = Pr;

//        let AllLek = document.querySelectorAll(`.Lek_${i}`);
//        for (var le = 0; le < AllLek.length; le++) {
//            Lek = Lek + Number(AllLek[le].textContent);
//        }
//        Verify(Lek, `TLek_${i}`, `itogLek_${i}`);
//        Alllek = Alllek + Lek;
//        document.getElementsByClassName(`itogLek_${i}`)[0].textContent = Lek;

//        let AllSrs = document.querySelectorAll(`.Srs_${i}`);
//        for (var s = 0; s < AllSrs.length; s++) {
//            Srs = Srs + Number(AllSrs[s].textContent);
//        }
//        Allsrs = Allsrs + Srs;
//        document.getElementsByClassName(`itogSrs_${i}`)[0].textContent = Srs;
//    }
//    document.getElementsByClassName(`All`)[0].textContent = Allitog;
//    document.getElementsByClassName(`AllLek`)[0].textContent = Alllek;
//    document.getElementsByClassName(`AllLab`)[0].textContent = Alllab;
//    document.getElementsByClassName(`AllPr`)[0].textContent = Allpr;
//    document.getElementsByClassName(`AllSrs`)[0].textContent = Allsrs;

//}

function Verify(Hours, pathVer, path) {

    const Verif = Number(document.getElementsByClassName(pathVer)[0].textContent);
    if (Hours != Verif)
        document.getElementsByClassName(path)[0].style = "background-color:red"
}

function ViewAddHours() {
    var items = document.getElementsByClassName("Hours");
    console.log(items);
}

function DeleteChapter(event) {

    let rows = event.currentTarget.parentElement.parentElement.children;
    const RowLenght = rows.length;
    if (RowLenght != 4) {
        rows[RowLenght - 1].remove();
        rows[RowLenght - 2].remove();
    }
}

function DeleteTheme(event) {

    let rows = event.currentTarget.parentElement.parentElement.children;
    const RowLenght = rows.length;
    if (RowLenght != 3) {
        rows[RowLenght - 1].remove();

    }
}



//function validatestate(event) {
//    var tar = event.target;
//    var val = event.target.value;
//    var maxNumber = 100;
//    var errorMessage = document.querySelector(".error-message"); // используем селектор класса для выбора элемента
//    if (val > maxNumber) {
//        tar.value = "";
//        errorMessage.textContent = "Введите число, не превышающее " + maxNumber;
//    } else {
//        errorMessage.textContent = "";
//    }
//}

    // Обработчик события клика на кнопке "Проверить"
    //$('.sum-form .check-btn').on('click', function (event) {
    //    event.preventDefault(); // Отмена отправки формы

    //    var isValid = true;
    //    var form = $(this).closest('.sum-form');
    //    $('.sum-form .sum-input').trigger('input');
    //    // Проверка значений на форме
    //    $('.sum-input', form).each(function () {
    //        if ($(this).hasClass('is-invalid')) {
    //            isValid = false;
    //        }
    //    });
        
    //    if (isValid) {
    //        $('#subButton').prop('disabled', false);
    //    } else {
    //        $('#subButton').prop('disabled', true);
    //    }
    //});

    //$(document).ready(function () {
    //    // Инициализация tooltip на полях ввода всех форм
    //    $('[data-bs-toggle="tooltip"]').tooltip();

    //    // Обработчик события input на полях ввода всех форм
    //    $('.sum-form .sum-input').on('input', function (event) {
    //        var form = $(this).closest('.sum-form');
    //        var maxSum = 100;
    //        var sum = 0;

    //        $('.sum-input', form).each(function () {
    //            var inputValue = parseFloat($(this).val()) || 0;
    //            sum += inputValue;
    //        });

    //        if (sum > maxSum) {
    //            $(this).addClass('is-invalid');
    //            $(this).tooltip('show');
    //            form.removeClass('was-validated');
    //        } else {
    //            $(this).removeClass('is-invalid');
    //            $(this).tooltip('hide');
    //        }
    //    });

    //    // Обработчик события submit на формах
    //    $('.sum-form').on('submit', function (event) {
    //        event.preventDefault();
    //        // Ваш код обработки отправки формы

    //        // Валидация формы с использованием встроенной валидации Bootstrap
    //        //var form = $(this);
    //        //if (form[0].checkValidity() === false) {
    //        //    event.stopPropagation();
    //        //}
    //        //form.addClass('was-validated');
    //    });
    //});

    //// Обработчик события submit на формах
    //$('.sum-form').on('submit', function (event) {
    //    event.preventDefault();
    //    // Ваш код обработки отправки формы
    //});


    // Обработка события ввода числа
    //$('.inputNumber').on('input', function ()
    //{
    //    var coll = $('.inputNumber');
    //    // Получение введенного значения
    //    var number = parseInt($(this).val());
    //    // Определенное значение (в данном случае 100)
    //    var maxValue = 50;

    //    // Проверка, является ли введенное значение больше определенного значения
    //    if (number > maxValue) {
    //        // Установка класса 'is-invalid' на поле ввода
    //        $(this).addClass('is-invalid');
    //        $(this).attr('data-original-title', 'Значение должно быть меньше 100');
    //        // Показ tooltip с ошибкой
    //        $(this).tooltip('show');
    //    } else {
    //        // Удаление класса 'is-invalid' с поле ввода
    //        $(this).removeClass('is-invalid');
    //        $(this).attr('data-original-title', 'Значение должно быть меньше 100');
    //        // Скрытие tooltip с ошибкой
    //        $(this).tooltip('hide');
    //    }
    //});



 
//var eventHandler = function (val) {
//    return function () {
//        console.log(val, arguments);
//        var t = $($(this)[0].$wrapper).parent();
//        $('#log').append('<div><span class="name">' + val + '</span></div>');
//    };
//};

        //    $.ajax({
        //        url: '/controller/action',
        //        type: 'POST',
        //        dataType: 'json',
        //        data: JSON.stringify(data),
        //        contentType: 'application/json; charset=utf-8',
        //        success: function (result) {
        //            console.log(result);
        //        },
        //        error: function (xhr, textStatus, errorThrown) {
        //            console.log(xhr.responseText);
        //        }
        //    });
        //});
/*    });*/



    function AddChapter(event, i) {
        let IndexChapter = (event.currentTarget.parentElement.parentElement.children.length - 4) / 2;
        let AppendEl = event.currentTarget.parentElement.parentElement;
        let AddNewChapter = document.createElement('div');
        let NameChapter = event.currentTarget.parentElement.children[1].value;
        event.currentTarget.parentElement.children[1].value = "";
        AddNewChapter.className = `Chapter_${i} _${IndexChapter} Hours rounded`;
        AddNewChapter.style = "background-color:#ffff; padding:10px";
        code = `
        
       <div class="row" style="display:flex; align-items: center">
           <div class="col-3" style="display:flex; align-items: center">
                <label><strong>Раздел ${IndexChapter + 1}: </strong></label>
                <input class="m-2 form-control NameCh w-auto" name="linkSemChapters[${i}].chapterModels[${IndexChapter}].NameChapter" value="${NameChapter}"/>
             </div>
                <div class="SelectComp col">
            </div>
        </div>
        <br>
        <div>
            <div style="display:flex; align-items: center"">
                <label>Лекции: </label>
                <input class="Hour form-control inp" name="linkSemChapters[${i}].chapterModels[${IndexChapter}].Lek" />

                <label>Лаб.раб.: </label>
                <input class="Hour form-control inp" name="linkSemChapters[${i}].chapterModels[${IndexChapter}].Lab" />

                <label>Пр.раб.: </label>
                <input class="Hour form-control inp " name="linkSemChapters[${i}].chapterModels[${IndexChapter}].Pr" />

                <label>Сам.раб.: </label>
                <input class="Hour form-control inp" name="linkSemChapters[${i}].chapterModels[${IndexChapter}].Srs" />

           </div>
            <br>
            <div class="w-auto" style="display:flex;align-items: center">

                <div class="m-0 p-2 ThemeHover" style="width:25px"onclick="AddTheme(event,${i},${IndexChapter})" >+</div>
                <div class="m-0 p-2 ThemeHover" style="width:25px" onclick="DeleteTheme(event)">-</div>
                <div class="col-1">№Темы</div>
                <div class="col-2">Наименование темы</div>
                <div class="col-8">Описание</div>
            </div>
        </div>
    `
        AddNewChapter.innerHTML = code;
        AppendEl.appendChild(AddNewChapter);
        let AddBr = document.createElement('br');
        AppendEl.appendChild(AddBr);

        $.ajax({
            mode: "after",
            type: "GET",
            url: "/Content/GetComp/",
            success: function (html) {
                AddNewChapter.querySelector(".SelectComp").innerHTML = html;
                var k = AddNewChapter.querySelector(".SelectComp");
                k.children[0].attributes[0].value = `linkSemChapters[${i}].chapterModels[${IndexChapter}].Kompetenc`
                initSelectize(k.children[0]);
                
            }
        });


    }

    function AddTheme(event, i, j) {
        let IndexTheme = event.currentTarget.parentElement.parentElement.children.length - 3;

        let AddNewTheme = document.createElement('div');
        AddNewTheme.className = `Theme_${i}_${j}_${IndexTheme} w-auto m-1`;
        AddNewTheme.style = "display:flex;align-items: center";

        code = `
        <div  style="width:50px"></div>
        <label class="col-1">Тема ${j + 1}.${IndexTheme + 1}</label>
        <div class="col-2">
            <input class="form-control w-auto"name="linkSemChapters[${i}].chapterModels[${j}].Themes[${IndexTheme}].NameTheme"/>
        </div>
        <div class="col-8">
            <textarea class=" form-control w-100" name="linkSemChapters[${i}].chapterModels[${j}].Themes[${IndexTheme}].DescTheme"></textarea>
        </div>
         `
        AddNewTheme.innerHTML = code;
        event.currentTarget.parentElement.parentElement.appendChild(AddNewTheme);
    }








//$('tr.header').click(function () {
//    $(this).nextUntil('tr.header').css('display', function (i, v) {
//        return this.style.display === 'table-row' ? 'none' : 'table-row';
//    });
//});

/*}*/

//function DragAndDrop() {
//    const tasksListElement = document.querySelector(`.tasks__list`);
//    //const taskElements = tasksListElement.querySelectorAll(`.tasks__item`);

//    for (const task of taskElements) {
//        task.draggable = true;
//    }

//    tasksListElement.addEventListener(`dragstart`, (evt) => {
//        evt.target.classList.add(`selected`);
//    });

//    tasksListElement.addEventListener(`dragend`, (evt) => {
//        evt.target.classList.remove(`selected`);
//    });

//    const getNextElement = (cursorPosition, currentElement) => {
//        const currentElementCoord = currentElement.getBoundingClientRect();
//        const currentElementCenter = currentElementCoord.y + currentElementCoord.height / 2;

//        const nextElement = (cursorPosition < currentElementCenter) ?
//            currentElement :
//            currentElement.nextElementSibling;

//        return nextElement;
//    };

//    tasksListElement.addEventListener(`dragover`, (evt) => {
//        evt.preventDefault();

//        const activeElement = tasksListElement.querySelector(`.selected`);
//        const currentElement = evt.target;
//        const isMoveable = activeElement !== currentElement &&
//            currentElement.classList.contains(`tasks__item`);

//        if (!isMoveable) {
//            return;
//        }

//        const nextElement = getNextElement(evt.clientY, currentElement);

//        if (
//            nextElement &&
//            activeElement === nextElement.previousElementSibling ||
//            activeElement === nextElement
//        ) {
//            return;
//        }

//        tasksListElement.insertBefore(activeElement, nextElement);
//    });
//}

//DragAndDrop();
