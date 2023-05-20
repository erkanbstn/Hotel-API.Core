using ApiConsume.BusinessLayer.Abstract;
using ApiConsume.DtoLayer.Dtos.MessageDto;
using ApiConsume.EntityLayer.Concrete;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Api.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _MessageService;
        private readonly IMapper _mapper;

        public MessageController(IMessageService MessageService, IMapper mapper)
        {
            _MessageService = MessageService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult MessageList()
        {
            var values = _MessageService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddMessage(MessageAddDto MessageAddDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = _mapper.Map<Message>(MessageAddDto);
            _MessageService.TInsert(values);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteMessage(int id)
        {
            _MessageService.TDelete(_MessageService.TGetById(id));
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateMessage(MessageUpdateDto MessageUpdateDto)
        {
            var values = _mapper.Map<Message>(MessageUpdateDto);
            _MessageService.TUpdate(values);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetMessage(int id)
        {
            return Ok(_MessageService.TGetById(id));
        }
    }
}
