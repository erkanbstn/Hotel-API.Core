namespace Frontend_Mvc.Core.ViewModels.Booking
{
    public class BookingViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string AdultCount { get; set; }
        public string ChildCount { get; set; }
        public string RoomCount { get; set; }
        public string SpecialRequest { get; set; }
    }
}
