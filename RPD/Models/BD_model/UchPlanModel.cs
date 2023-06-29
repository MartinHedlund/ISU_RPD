using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPD.Models.BD_model
{

    [Table("UchPlan", Schema = "UP")]
    [Keyless]
    public class UchPlanModel
    {

        public int IdUchPlan { get; set; }
        public int IdKafedra { get; set; }
        public string? GosInsp { get; set; }
        public short Year { get; set; }
        public int IdDisc { get; set; }
        public int IdProfil { get; set; }
        public int IdSpec { get; set; }
        //public Specialnost Spec { get; set; }

    }

}
