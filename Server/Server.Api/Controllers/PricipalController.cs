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
        public async Task<IEnumerable<PrincipalDto>> Get()
        {
            return await _principalService.GetAllAsync();
        }
        [HttpGet("Full")]
        public async Task<IEnumerable<PrincipalDto>> GetFull()
        {
            return await _principalService.GetPrincipalFullAsync();
        }
        // GET api/<PricipalController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PrincipalDto>>GetById(int id)
        {
            return await _principalService.GetByIdAsync(id);
        }
        [HttpGet("Full/{id}")]
        public async Task<ActionResult<PrincipalDto>> GetByIdFull(int id)
        {
            return await _principalService.GetByIdDataAsync(id);
        }

        // POST api/<PricipalController>
        [HttpPost]
        public async Task<PrincipalDto> Post([FromBody]PrincipalPostModel p)
        {
            var pDto = _mapper.Map<PrincipalDto>(p);
            return await _principalService.AddAsync(pDto);
        }

        // PUT api/<PricipalController>/5
        [HttpPut("{id}")]
        public async Task<PrincipalDto> Put(int id, [FromBody]PrincipalPostModel value)
        {
            var pDto = _mapper.Map<PrincipalDto>(value);
            return await _principalService.UpdateAsync(id, pDto);
        }

        // DELETE api/<PricipalController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _principalService.DeleteAsync(id);
        }
    }
}
