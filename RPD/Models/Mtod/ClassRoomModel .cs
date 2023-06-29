namespace RPD.Models.Mtod
{
    public class ClassRoomModel
    {
        public int Id { get; set; }
        public string? RoomNumber { get; set; }
        public string? Appointments { get; set; }
        public string? Equipment { get; set; }
        public bool Cheked { get; set; } = false;

    }
}
