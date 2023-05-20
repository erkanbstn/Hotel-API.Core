using ApiConsume.BusinessLayer.Abstract;
using ApiConsume.DtoLayer.Dtos.StaffDto;
using ApiConsume.EntityLayer.Concrete;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Api.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;
        private readonly IMapper _mapper;

        public StaffController(IStaffService staffService, IMapper mapper)
        {
            _staffService = staffService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult StaffList()
        {
            var values = _staffService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddStaff(StaffAddDto staffAddDto)
        {
            var values = _mapper.Map<Staff>(staffAddDto);
            _staffService.TInsert(values);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteStaff(int id)
        {
            _staffService.TDelete(_staffService.TGetById(id));
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateStaff(StaffUpdateDto staffUpdateDto)
        {
            var values = _mapper.Map<Staff>(staffUpdateDto);
            _staffService.TUpdate(values);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetStaff(int id)
        {
            return Ok(_staffService.TGetById(id));
        }
    }
}
