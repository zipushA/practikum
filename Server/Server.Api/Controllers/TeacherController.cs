using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Server.Api.PostModels;
using Server.Core.DTOs;
using Server.Core.Interfaces.Services;
using Server.Core.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController(ITeacherService teacherService,IMapper mapper) : ControllerBase
    {

        private readonly ITeacherService _teacherService=teacherService;
        private readonly IMapper _mapper = mapper;


        // GET: api/<TeacherController>
        [HttpGet]
        public Task<IEnumerable<TeacherDto>> Get()
        {
            return _teacherService.GetAllAsync();
        }
        [HttpGet("Full")]
        public Task<IEnumerable<TeacherDto>> GetFull()
        {
            return _teacherService.GetTeachersDataAsync();
        }
        [HttpGet("OrderData")]
        public Task<IEnumerable<TeacherDto>> GetOrderData(int id)
        {
            return _teacherService.GetOrderDataAsync(id);
        }
        // GET  api/<TeacherController>/5
        [HttpGet("Full/{id}")]
        public Task<TeacherDto?> GetByIdFull(int id)
        {
            return _teacherService.GetByIdDataAsync(id);
        }

        // POST api/<TeacherController>
        [HttpPost]
        public Task<TeacherDto> Post([FromBody]TeacherPostModel t)
        {
            var tDto = _mapper.Map<TeacherDto>(t);
            return _teacherService.AddAsync(tDto);
        }

        // PUT api/<TeacherController>/5
        [HttpPut("{id}")]
        public Task<TeacherDto> Put(int id, [FromBody]TeacherPostModel t)
        {
            var tDto = _mapper.Map<TeacherDto>(t);
            return _teacherService.UpdateAsync(id, tDto);
        }

        // DELETE api/<TeacherController>/5
        [HttpDelete("{id}")]
        public Task< bool> Delete(int id)
        {
            return _teacherService.DeleteAsync(id);
        }
    }
}
