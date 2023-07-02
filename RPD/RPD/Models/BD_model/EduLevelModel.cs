using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPD.Models.BD_model
{
    [Table("EduLevel", Schema = "dbo")]
    [Keyless]
    public class EduLevelModel
    {
        public Byte IdEduLevel { get; set; }
        public string? NEduLevel { get; set; }
    }
}
