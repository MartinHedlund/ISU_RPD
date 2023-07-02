using DocumentFormat.OpenXml.Drawing.Diagrams;
using Microsoft.EntityFrameworkCore;
using RPD.Models.BD_model;
using RPD.Models.BD_model.LiterAndRoomAndProgramm;
using RPD.Models.BD_Second_model;
using RPD.Models.RP_2;
using System.Diagnostics;

namespace RPD.Service
{
    public class DbSecondService:DbContext
    {
        public DbSecondService(DbContextOptions<DbSecondService> options) : base(options)
        {

        }
        public DbSet<KafedraMmisModel> kafedraMmisModels { get; set; }
        public DbSet<UchPlanMmisModel> uchPlanMmisModels { get;set; }
        public DbSet<StrokaMmisModel> strokaMmisModels { get; set; }

        public DbSet<OOP> OOPs { get; set; }
        public DbSet<PlanProfil> planProfils { get; set; }

        public DbSet<PlanHours> planHours { get; set; }

        public DbSet<PlanKomp> planKomps { get; set; }

        public DbSet<PlanKompDiscip> planKompDiscips { get; set; }

        
        public DbSet<Discip> discips { get; set; }
        public List<Competence> Competence { get;  set; }
    }
}
