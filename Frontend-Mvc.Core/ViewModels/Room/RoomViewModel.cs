namespace Frontend_Mvc.Core.ViewModels.Room
{
    public class RoomViewModel
    {
        public int Id{ get; set; }
        public string RoomCoverImage { get; set; }
        public int Price { get; set; }
        public string Title { get; set; }
        public string BedCount { get; set; }
        public string BathCount { get; set; }
        public bool Wifi { get; set; }
        public string Description { get; set; }
        public string No { get; set; }
        public bool RoomStatus { get; set; }
    }
}
