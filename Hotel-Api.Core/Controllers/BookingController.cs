using ApiConsume.BusinessLayer.Abstract;
using ApiConsume.DtoLayer.Dtos.BookingDto;
using ApiConsume.EntityLayer.Concrete;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Api.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _BookingService;
        private readonly IMapper _mapper;

        public BookingController(IBookingService BookingService, IMapper mapper)
        {
            _BookingService = BookingService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _BookingService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddBooking(BookingAddDto BookingAddDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = _mapper.Map<Booking>(BookingAddDto);
            _BookingService.TInsert(values);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteBooking(int id)
        {
            _BookingService.TDelete(_BookingService.TGetById(id));
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateBooking(BookingUpdateDto BookingUpdateDto)
        {
            var values = _mapper.Map<Booking>(BookingUpdateDto);
            _BookingService.TUpdate(values);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            return Ok(_BookingService.TGetById(id));
        }
    }
}
