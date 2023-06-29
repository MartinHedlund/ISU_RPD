using RPD.Models.BD_Second_model;

namespace RPD.Models.Titul
{
    public class UchPlan
    {
        public PlanProfil planProfil { get; set; } = new();
        public UchPlanMmisModel uchMmisPlans { get; set; } = new();

        public string FormStudy { get; set; } = string.Empty;

    }
}
