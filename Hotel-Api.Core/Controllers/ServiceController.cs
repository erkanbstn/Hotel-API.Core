using ApiConsume.BusinessLayer.Abstract;
using ApiConsume.DtoLayer.Dtos.ServiceDto;
using ApiConsume.EntityLayer.Concrete;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Api.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _ServiceService;
        private readonly IMapper _mapper;

        public ServiceController(IServiceService serviceService, IMapper mapper)
        {
            _ServiceService = serviceService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ServiceList()
        {
            var values = _ServiceService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddService(ServiceAddDto serviceAddDto)
        {
            var values = _mapper.Map<Service>(serviceAddDto);
            _ServiceService.TInsert(values);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteService(int id)
        {
            _ServiceService.TDelete(_ServiceService.TGetById(id));
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateService(ServiceUpdateDto serviceUpdateDto)
        {
            var values = _mapper.Map<Service>(serviceUpdateDto);
            _ServiceService.TUpdate(values);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetService(int id)
        {
            return Ok(_ServiceService.TGetById(id));
        }
    }
}
