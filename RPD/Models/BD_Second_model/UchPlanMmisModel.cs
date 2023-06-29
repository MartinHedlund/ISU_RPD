using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPD.Models.BD_Second_model
{
    [Table("Планы", Schema = "dbo")]
    public class UchPlanMmisModel
    {
        [Column("Код")]
        [Key]
        public int Id { get; set; }

        [Column("ИмяФайла")]
        public string NameFile { get; set; } = string.Empty;
        
        [Column("УчебныйГод")]
        public string Year { get; set; } = string.Empty;

        [Column("Специальность")]
        public string Specialnost { get; set; } = string.Empty;

        [Column("Титул")]
        public string? Titul { get; set; }

        [Column("Квалификация")]
        public string? Kvalification { get ; set; }

        [Column("КодФормыОбучения")]
        public int? FormStudy { get; set; }     
        [Column("КодФакультета")]
        public int? Facult { get; set; }


        [Column("КодПрофКафедры")]
        public int? IdKaf { get; set; }
        
        [Column("ГодНачалаПодготовки")]
        public int? StartYearPreparation { get; set; }
        

  
        


        public List<StrokaMmisModel>? StrokaMmis { get; set;}
    }
}
