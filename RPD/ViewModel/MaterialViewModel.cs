using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RPD.Models.BD_model;
using RPD.Models.Content;
using RPD.Models.Material;
using RPD.Service;

namespace RPD.ViewModel
{
    [BindProperties]
    public class MaterialViewModel : PageModel
    {
        public bool IsChekedEval { get; set; } = true;
        public bool IsChekedTech { get; set; } = false;
        public List<int>? NumSemList { get; set; }
        //public string? MessageView { get; set; }
        public List<Chapter>? Razdels { get; set; }
        public List<ListAllEvaluationTools>? ListAllEvaluationTools { get; set; }
        public List<ListOfControlTasks>? ListOfControlTasks { get; set; }
        public List<EvaluationToolsOthers>? EvaluationToolsListOthers { get; set; }
        public RatingScale? Rating {get;set;} 
    }
}
