using System.ComponentModel.DataAnnotations;

namespace RPD.Models.BD_model
{
    public class DiscipModel
    {

        [Key]
        public int IdDiscip { get; set; }
        public string? NDiscip { get; set; }
        public string? ShortName { get; set; }
        //public int IdKaf { get; set; }

    }
}
