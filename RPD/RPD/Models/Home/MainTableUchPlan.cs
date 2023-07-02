using RPD.Models.BD_model.UserProfile;

namespace RPD.Models.Home
{
    public class MainTableUchPlan
    {
        public int IdUchPlan { get; set; }
        public List<string>? NameUchPlan { get; set; } = new();

        public int IdStroka { get; set; }
        public int? IdDiscip { get; set; }
        public string? NameDiscip { get; set; }
        public List<string>? UsersAccess { get; set; }
        public DateTime? DateTimeCreater { get; set; }
        public string? Status { get; set; }
        public bool ChekRPD { get; set; } = false;
        public int? IdRpd { get; set; }
        public List<CommentModel>? Comment { get; internal set; }
        public string ToStringNameUchPlan()
        {
            string strCode = "";
            foreach (string item in NameUchPlan)
                strCode += $"<p>{item}<p>";
            return strCode;
        }
        public string ToStringUsersAccess() 
        {
            string strCode = "";
            foreach (string item in UsersAccess)
                strCode += $"<p>{item}<p>";
            return strCode;
        }
        public string ToStringComment()
        {
            string comm = "";
            foreach (CommentModel item in Comment)
                comm += $"<p>{item.FIO} ({item.CreatedAt}): {item.CommentText}<p>";
            return comm;
        }

    }
}