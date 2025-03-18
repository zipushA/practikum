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
        public async Task<ActionResult<IEnumerable<TeacherDto>>> Get()
        {
            var result = await _teacherService.GetAllAsync();
            if (result == null || !result.Any())
            {
                return NotFound(); // אם אין נתונים, החזר 404
            }
            return Ok(result); // החזר 200 עם הנתונים
        }

        [HttpGet("Full")]
        public async Task<ActionResult<IEnumerable<TeacherDto>>> GetFull()
        {
          
            var result = await _teacherService.GetTeachersDataAsync();
            if (result == null || !result.Any())
            {
                return NotFound(); // אם אין נתונים, החזר 404
            }
            return Ok(result); // החזר 200 עם הנתונים
        }
        [HttpGet("OrderData")]
        public async Task<ActionResult<IEnumerable<TeacherDto>>> GetOrderData(int id)
        {
            var result = await _teacherService.GetOrderDataAsync(id);
            if (result == null || !result.Any())
            {
                return NotFound(); // אם אין נתונים, החזר 404
            }
            return Ok(result);
        }
        // GET  api/<TeacherController>/5
        [HttpGet("Full/{id}")]
        public async Task<ActionResult<TeacherDto?>> GetByIdFull(int id)
        {
            var result = await _teacherService.GetByIdDataAsync(id);
            if (result == null)
            {
                return NotFound(); // החזר 404 אם לא נמצא
            }
            return Ok(result); // החזר 200 עם הנתון
        }

        // POST api/<TeacherController>
        [HttpPost]
        public async Task<ActionResult<TeacherDto>>Post([FromBody]TeacherPostModel teacherPostModel)
        {
            if (teacherPostModel == null)
            {
                return BadRequest("נתונים לא תקינים"); // החזר 400 אם המודל לא תקין
            }

            var teacherDto = _mapper.Map<TeacherDto>(teacherPostModel);
            var createdEntity = await _teacherService.AddAsync(teacherDto);
            return CreatedAtAction(nameof(GetByIdFull), new { id = createdEntity.id }, createdEntity);
        }

        // PUT api/<TeacherController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<TeacherDto>> Put(int id, [FromBody] TeacherPostModel teacherPostModel)
        {
            if (teacherPostModel == null)
            {
                return BadRequest("נתונים לא תקינים"); // החזר 400 אם המודל לא תקין
            }

            var teacherDto = _mapper.Map<TeacherDto>(teacherPostModel);
            var updatedEntity = await _teacherService.UpdateAsync(id, teacherDto);
            if (updatedEntity == null)
            {
                return NotFound(); // החזר 404 אם ה-ID לא קיים
            }
            return Ok(updatedEntity); // החזר 200
        }

        // DELETE api/<TeacherController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _teacherService.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound(); // החזר 404 אם ה-ID לא קיים
            }
            return NoContent(); // החזר 204 אם המחיקה הצליחה
        }
    }
}
