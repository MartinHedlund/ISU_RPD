class RP_1 {
    constructor() {
        this.Purpose = '';
        this.Tasks = '';
        this.Requirements = '';
        this.SubsequentDisciplines = [];
        this.PreviousDisciplines = [];
        this.ThemPlanLab = '';
        this.ThemPlanPr = '';
        this.ThemPlanKpKr = '';
    }
}

function SaveRP_1() {

    const rp = new RP_1();
    rp.Purpose = document.getElementsByClassName("Purpose")[0].value;
    rp.Tasks = document.getElementsByClassName("Tasks")[0].value;
    rp.ThemPlanLab = document.getElementsByClassName("ThemPlanLab")[0].value;
    rp.ThemPlanPr = document.getElementsByClassName("ThemPlanPr")[0].value;
    rp.ThemPlanKpKr = document.getElementsByClassName("ThemPlanKpKr")[0].value;
    rp.PreviousDisciplines = $('.Pred').val();
    rp.SubsequentDisciplines = $('.NoPred').val();


    $.ajax({
        url: '/RP_1/Save',
        type: "POST",
        data: { ViewModel: rp },
        success: function (data) {
                alert("Сохранено");
              
        },
        error: function () {
            alert('Произошла ошибка: ');
        }
    });
}