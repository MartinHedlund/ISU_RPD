var saveButton = document.querySelector('.SaveAgree');

class Person {
    constructor(IdPerson, IdDep, Type, DateAgree, NumberAgree) {
        this.IdPerson = IdPerson;
        this.IdDepartament = IdDep;
        this.Type = Type;
        this.DateAgree = DateAgree;
        this.NumberAgree = NumberAgree;
    }
}
// Определяем функцию, которая будет вызываться при клике на кнопку
function saveAgreeHandler() {

    var personArray = [];

    var dateAgreeElements = document.querySelectorAll('.PersonAgreement');
    dateAgreeElements.forEach(function (element) {
        var IdPerson = element.querySelector('.IdPerson').textContent;
        var IdDep = element.querySelector('.IdDep').textContent;
        var Type = element.querySelector('.Type').textContent;
        var DateAgree = element.querySelector('.DateAgree').value;
        var NumberAgree = element.querySelector('.NumberAgree').value;

        var person = new Person(IdPerson, IdDep, Type, DateAgree, NumberAgree);
        personArray.push(person);
    });

    $.ajax({
        url: '/Titul/SavePersonAgreement',
        type: "POST",
        data: { Persons: personArray },
        success: function (data) {
            alert("Сохранено");
        },
        error: function () {
            alert('Произошла ошибка ');
        }
    });
}


// Привязываем функцию к событию "click" на кнопке
saveButton.addEventListener('click', saveAgreeHandler);