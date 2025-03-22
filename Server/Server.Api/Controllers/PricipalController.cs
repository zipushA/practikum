using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Server.Api.PostModels;
using Server.Core.DTOs;
using Server.Core.Interfaces.IRepository;
using Server.Core.Interfaces.Services;
using Server.Core.Models;
using Server.Service.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricipalController (IPrincipalService principalService,IMapper mapper): ControllerBase
    {
        private readonly IPrincipalService _principalService = principalService;
        private readonly IMapper _mapper = mapper;

        // GET: api/<PricipalController>
        [HttpGet]
        
        public async Task<ActionResult<IEnumerable<PrincipalDto>>> Get()
        {
            var result = await _principalService.GetAllAsync();
            if (result == null || !result.Any())
            {
                return NotFound(); // אם אין נתונים, החזר 404
            }
            return Ok(result); // החזר 200 עם הנתונים
        }
        [HttpGet("Full")]
        public async Task<ActionResult<IEnumerable<PrincipalDto>>> GetFull()
        {
            // return await _principalService.GetPrincipalFullAsync();
            var result = await _principalService.GetPrincipalFullAsync();
            if (result == null || !result.Any())
            {
                return NotFound(); // אם אין נתונים, החזר 404
            }
            return Ok(result); // החזר 200 עם הנתונים
        }
        // GET api/<PricipalController>/5
        [HttpGet("{id}")]
       
        public async Task<ActionResult<PrincipalDto>> GetById(int id)
        {
            var result = await _principalService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound(); // החזר 404 אם לא נמצא
            }
            return Ok(result); // החזר 200 עם הנתון
        }
        [HttpGet("Full/{id}")]
        public async Task<ActionResult<PrincipalDto>> GetByIdFull(int id)
        {
            var result = await _principalService.GetByIdDataAsync(id);
            if (result == null)
            {
                return NotFound(); // החזר 404 אם לא נמצא
            }
            return Ok(result);
        }
            // POST api/<PricipalController>
            [HttpPost]
        public async Task<ActionResult<PrincipalDto>> Post([FromBody] PrincipalPostModel principalPostModel)
        {
            if (principalPostModel == null)
            {
                return BadRequest("נתונים לא תקינים"); // החזר 400 אם המודל לא תקין
            }

            var principalDto = _mapper.Map<PrincipalDto>(principalPostModel);
            var createdEntity = await _principalService.AddAsync(principalDto);
            return CreatedAtAction(nameof(GetById), new { id = createdEntity.Id }, createdEntity); // החזר 201
        }

        // PUT api/<PricipalController>/5
        [HttpPut("{id}")]
       
        public async Task<ActionResult<PrincipalDto>> Put(int id, [FromBody] PrincipalPostModel principalPostModel)
        {
            if (principalPostModel == null)
            {
                return BadRequest("נתונים לא תקינים"); // החזר 400 אם המודל לא תקין
            }

            var principalDto = _mapper.Map<PrincipalDto>(principalPostModel);
            var updatedEntity = await _principalService.UpdateAsync(id, principalDto);
            if (updatedEntity == null)
            {
                return NotFound(); // החזר 404 אם ה-ID לא קיים
            }
            return Ok(updatedEntity); // החזר 200
        }

        // DELETE api/<PricipalController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            // return await _principalService.DeleteAsync(id);
            var deleted = await _principalService.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound(); // החזר 404 אם ה-ID לא קיים
            }
            return NoContent();
        }
    }
}
