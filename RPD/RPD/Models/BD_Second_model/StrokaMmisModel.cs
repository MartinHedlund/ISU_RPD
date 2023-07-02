using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPD.Models.BD_Second_model
{
    [Table("ПланыСтроки", Schema = "dbo")]
    public class StrokaMmisModel
    {
        [Column("Код")]
        [Key]
        public int Id { get; set; }

        [ForeignKey("КодПлана")]
        [Column("КодПлана")]
        public int UchPlanMmisModelId { get; set; }

        [Column("Дисциплина")]
        public string? NameDiscip { get; set; }

        [Column("КодДисциплины")]
        public int? IdDiscip { get;set; }

        [Column("КодКафедры")]
        public int? IdKaf { get; set; }        
        
        [Column("Компетенции")]
        public string? Komp { get; set; }
        
        [Column("ЦиклКод")]
        public string? CycleСode { get; set; }        
        
        [Column("ДисциплинаКод")]
        public string? DiscСode { get; set; }        
        
        [Column("ЧасовПоПлану")]
        public double? HoursByPlan { get; set; }        
        
        [Column("ЗЕТфакт")]
        public double? ZetFact { get; set; }
        
        [Column("КодООП")]
        public int CodeOOP { get; set; }      
        
        [Column("СчитатьВПлане")]
        public bool? CheckForPlan { get; set; }


        public UchPlanMmisModel? UchPlanMmisModel { get; set; }
    }
}
