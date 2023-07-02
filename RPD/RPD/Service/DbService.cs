using Microsoft.EntityFrameworkCore;
using RPD.Models;
using RPD.Models.BD_model;
using RPD.Models.BD_model.LiterAndRoomAndProgramm;
using RPD.Models.BD_model.LiterAndRoomAndProgramm.BindRPD;
using RPD.Models.BD_model.UserProfile;
using RPD.Models.Content;
using RPD.Models.Material;
using RPD.Models.RP_2;
using RPD.Models.Rpd;
using RPD.Models.Titul;

namespace RPD.Service
{
    public class DbService : DbContext
    {
        public DbService(DbContextOptions<DbService> options) : base(options)
        {
            
        }
        /// <summary>
        /// БД для Home Начальная страница выбора дисциплины
        /// </summary>


        public DbSet<RPDModel> RPD { get; set; } // БД при создании РПД 
        public DbSet<Chapter> Chapter { get; set; } // БД Разделы дисциплин
        public DbSet<ThemeChapterModel> ThemeChapter { get; set; } // Темы разделов
        public DbSet<CommentModel> Comments { get; set; } // Comment
        public DbSet<PersonModel> Persons { get; set; } 

        public DbSet<PersonAgreementModel> personAgreementModels { get; set; } // даты и номер Согласований
        public DbSet<DepartmentModel> departments { get; set; } 
        public DbSet<ListAllEvaluationTools> ListAllEvaluationTools { get; set; }
        public DbSet<EvaluationToolsOthers> EvaluationToolsOther{ get; set; }
        public DbSet<RatingScale> RatingScales{ get; set; }
        public DbSet<ListOfControlTasks> ListOfControlTasks { get; set; }
        public DbSet<MaterialOCWordSegment> MaterialOCWordSegments { get; set; }
        //public DbSet<Kompetenci> Kompetens { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserMoodleProfile> UserMoodleProfiles { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Position> Positions { get; set; }

        public DbSet<KafedraModel> kafedras { get; set; } // Связь кафедр вузка с mmis
        public DbSet<UserDiscipModel> userDiscipModels { get; set; }    

        public DbSet<Competence> Сompetences { get; set; }
        public DbSet<Indicator> Indicators { get; set; }
        public DbSet<LevelFormation> LevelFormations { get; set; }

        //public DbSet<Komp> Komp { get; set; }
        //public DbSet<KompDes> KompDescr { get; set; }

        public DbSet<StroksBindRpd> stroksBindRpds { get;set; }

        // MTOD
        public DbSet<rpLit> rpLit { get; set; }
        public DbSet<Auditoriy> Auditoriys { get; set; }
        public DbSet<ProductTech> ProductTeches { get; set; }

        //Bind Mtod in RPD
        public DbSet<LiterRPD> literRPDs { get; set; }
        public DbSet<ProductTechRPD> productTechRPDs { get; set; }
        public DbSet<AuditoriyRPD> AuditoriyRPDs { get; set; }


        public DbSet<Certificat> certificats { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>()
                  .HasKey(m => new { m.UserId, m.IdRole });
        }
    }
}
 