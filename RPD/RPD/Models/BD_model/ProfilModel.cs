using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPD.Models.BD_model
{
    [Table("Profil", Schema = "dbo")]
    [Keyless]
    public class ProfilModel
    {
        public int IdProfil { get; set; }
        public string? NProfil { get; set; }
        public int IdSpecFgos { get; set; }
    }
}
