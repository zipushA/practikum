using AutoMapper;
using MatchingAPI.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Server.Api.PostModels;
using Server.Core.DTOs;
using Server.Core.Interfaces.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchingDataController(IMatchingDataService matchingDataService,IMapper mapper) : ControllerBase
    {
        private readonly IMatchingDataService _matchingDataService = matchingDataService;
        private readonly IMapper _mapper = mapper;
        // GET: api/<MatchingDataController>
        [HttpGet]
        public async Task< IEnumerable<MatchingDataDto>> Get()
        {
            return await _matchingDataService.GetMatchingDataAsync();
        }

        // GET api/<MatchingDataController>/5
        [HttpGet("{id}")]
        public async Task<MatchingDataDto> Get(int id)
        {
            return await _matchingDataService.GetByIdAsync(id);
        }

        // POST api/<MatchingDataController>
        [HttpPost]
        public async Task<MatchingDataDto> Post([FromBody]MatchingDataPostModel matchingData)
        {
            var matchingDataDto = _mapper.Map<MatchingDataDto>(matchingData);
            return await _matchingDataService.AddAsync(matchingDataDto);

        }

        // PUT api/<MatchingDataController>/5
        [HttpPut("{id}")]
        public async Task<MatchingDataDto> Put(int id, [FromBody]MatchingDataPostModel matchingData)
        {
            var matchingDataDto = _mapper.Map<MatchingDataDto>(matchingData);
            return await _matchingDataService.UpdateAsync(id, matchingDataDto);
        }

        // DELETE api/<MatchingDataController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _matchingDataService.DeleteAsync(id);
        }
    }
}
