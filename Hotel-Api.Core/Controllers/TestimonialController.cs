using ApiConsume.BusinessLayer.Abstract;
using ApiConsume.DtoLayer.Dtos.TestimonialDto;
using ApiConsume.EntityLayer.Concrete;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Api.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _TestimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _TestimonialService = testimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _TestimonialService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddTestimonial(TestimonialAddDto testimonialAddDto)
        {
            var values = _mapper.Map<Testimonial>(testimonialAddDto);
            _TestimonialService.TInsert(values);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            _TestimonialService.TDelete(_TestimonialService.TGetById(id));
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateTestimonial(TestimonialUpdateDto testimonialUpdateDto)
        {
            var values = _mapper.Map<Testimonial>(testimonialUpdateDto);
            _TestimonialService.TUpdate(values);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetTestimonial(int id)
        {
            return Ok(_TestimonialService.TGetById(id));
        }
    }
}
