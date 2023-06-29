function AddLevelForm(event, flag) {
    var table = event.currentTarget.parentElement.parentElement.parentElement;
    var rowToInsertBefore = document.getElementById(flag);

    var CodeIndex = document.getElementById(flag).previousElementSibling.children; // тут ПК-6.1-У1
    var indexCodeNew = CodeIndex[3].innerText; // тут ПК-6.1-У1
    var regex = /(\d+)$/;
    // Извлечение конечного числа из строки и преобразование его в число
    var lastIndexNumber = parseInt(regex.exec(indexCodeNew)[1]);
    // Увеличение числа на 1 и добавление его к начальной строке
    var newIndexCode = indexCodeNew.replace(regex, lastIndexNumber + 1);


    let NameLevelForm = IndexForRp_1(CodeIndex[3].childNodes[1].getAttribute("name"));
    let NameResult = IndexForRp_1(CodeIndex[4].childNodes[1].getAttribute("name"));
    let NameHigh = IndexForRp_1(CodeIndex[5].childNodes[1].getAttribute("name"));
    let NameAverage = IndexForRp_1(CodeIndex[6].childNodes[1].getAttribute("name"));
    let BelowMiddle = IndexForRp_1(CodeIndex[7].childNodes[1].getAttribute("name"));
    let NameLow = IndexForRp_1(CodeIndex[8].childNodes[1].getAttribute("name"));
    let NameLevel = IndexForRp_1(CodeIndex[9].childNodes[1].getAttribute("name"));
    let NameLevelValue = CodeIndex[9].childNodes[1].getAttribute("value");

    let AddNewLevelForm = document.createElement('tr');
    code = `

                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>
                                      <input hidden name="${NameLevelForm}" value=" ${newIndexCode}" />
                                        ${newIndexCode}
                                    </td>
                                    <td>
                                        <textarea class="form-control"  name="${NameResult}" ></textarea>
                                    </td>
                                    <td>
                                        <textarea class="form-control" name="${NameHigh}"></textarea>
                                    </td>
                                    <td>
                                        <textarea class="form-control" name="${NameAverage}"></textarea>
                                    </td>
                                    <td>
                                        <textarea class="form-control" name="${BelowMiddle}"></textarea>
                                    </td>
                                    <td>
                                        <textarea class="form-control" name="${NameLow}"></textarea>
                                    </td>
                                    <td hidden>
                                    <input name="${NameLevel}" value="${NameLevelValue}" />
                                    </td>
 
    `
    AddNewLevelForm.innerHTML = code;
    table.insertBefore(AddNewLevelForm, rowToInsertBefore);
}

function DeleteLevelForm(flag) {
    var CodeIndex = document.getElementById(flag).previousElementSibling;
    var indexCodeNew = CodeIndex.children[3].innerText; // тут ПК-6.1-У1
    var regex = /(\d+)$/;
    var lastIndexNumber = parseInt(regex.exec(indexCodeNew)[1]);
    if (lastIndexNumber != 1)
        CodeIndex.remove();
}

function IndexForRp_1(str) {

    // разбиваем строку на массив элементов
    let arr = str.split(".");

    // получаем значение текущего индекса x
    let x = parseInt(arr[2].match(/\d+/)[0]);

    // увеличиваем значение индекса на 1
    x++;
    let result = arr[2].split("[")[0];
    // обновляем значение x в массиве
    arr[2] = `${result}[${x}]`;

    // объединяем элементы массива в строку
    let newStr = arr.join(".");

    // выводим новую строку
    return newStr;
}