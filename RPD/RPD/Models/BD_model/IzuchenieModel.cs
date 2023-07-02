using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPD.Models.BD_model
{
    [Table("Izuchenie", Schema = "UP")]
    [Keyless]
    public class IzuchenieModel
    {
        public int IdUchPlan { get; set; }
        public byte Semestr { get; set; }
        public int IdDiscip { get; set; }
        public Int16 Lek { get; set; }
        public Int16 Lab { get; set; }
        public Int16 Pr { get; set; }
        public Int16 KSR { get; set; }
        public Int16 SRS { get; set; }
        public Int16 ChEkz { get; set; }

        public bool KP { get; set; }
        public bool KR { get; set; }

        public bool Ekzamen { get; set; }
        public bool Zachet { get; set; }
        public bool ZachetO { get; set; }
    }
}
