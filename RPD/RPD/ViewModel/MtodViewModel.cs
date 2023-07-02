using RPD.Models.BD_model.LiterAndRoomAndProgramm;
using RPD.Models.Mtod;

namespace RPD.ViewModel
{
    public class MtodViewModel
    {
        //public List<ClassRoomModel> ClassRoom { get; set; }
        public List<rpLit>? RpLits { get; set; }
        public List<ProductTech>? ProductTeches { get; set; }
        public List<ChoisClassRoom> CCRoom { get; set; } = new();
        public string? SearchString { get; set; }


    }
    public class ChoisClassRoom
    {
        public int IdClassRoom { get; set; }
        public List<int> TypeClassRoom { get; set; } = new();
    }
}
