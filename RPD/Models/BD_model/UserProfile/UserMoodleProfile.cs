using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPD.Models.BD_model.UserProfile
{
    [Table("User", Schema = "moodle")]
    public class UserMoodleProfile
    {
        [Key]
        public string UserName { get; set; }
        public string Pass { get; set; }
        public string EMail { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ParentName { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Dept { get; set; }
        public string? Position { get; set; }
        public string? Cabinet { get; set; }
        public string? Phone { get; set; }
        public byte IdUserType { get; set; }
        public bool IsBlocked { get; set; }
        public bool IsPassSyncronized { get; set; }
        public DateTime? CreateDate { get; set; }
        public int IdUser { get; set; }
        public string? ConfirmCode { get; set; }
        public short? AttemptCount { get; set; }
        public DateTime? LastAccess { get; set; }
        public byte? IdBlockReason { get; set; }
        public bool? IsActivated { get; set; }
        public int? IdPerson { get; set; }
        public bool? PersDataProcessingAccepted { get; set; }

    }
}
