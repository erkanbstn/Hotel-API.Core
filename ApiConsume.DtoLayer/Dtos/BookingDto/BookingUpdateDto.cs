using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsume.DtoLayer.Dtos.BookingDto
{
    public class BookingUpdateDto
    {
        public int Id{ get; set; }
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
