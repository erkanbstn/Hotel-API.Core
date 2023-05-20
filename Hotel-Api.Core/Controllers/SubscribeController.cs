using ApiConsume.BusinessLayer.Abstract;
using ApiConsume.DtoLayer.Dtos.SubscribeDto;
using ApiConsume.EntityLayer.Concrete;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Api.Core.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly ISubscribeService _SubscribeService;
        private readonly IMapper _mapper;

        public SubscribeController(ISubscribeService subscribeService, IMapper mapper)
        {
            _SubscribeService = subscribeService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SubscribeList()
        {
            var values = _SubscribeService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddSubscribe(SubscribeAddDto subscribeAddDto)
        {
            var values = _mapper.Map<Subscribe>(subscribeAddDto);
            _SubscribeService.TInsert(values);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteSubscribe(int id)
        {
            _SubscribeService.TDelete(_SubscribeService.TGetById(id));
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateSubscribe(SubscribeUpdateDto subscribeUpdateDto)
        {
            var values = _mapper.Map<Subscribe>(subscribeUpdateDto);
            _SubscribeService.TUpdate(values);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetSubscribe(int id)
        {
            return Ok(_SubscribeService.TGetById(id));
        }
    }
}
