using AutoMapper;
using MatchingAPI.Core.Models;
using Server.Core.DTOs;
using Server.Core.Interfaces.IRepository;
using Server.Core.Interfaces.Services;
using Server.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Service.Services
{
    public class PrincipalService(IRepositoryManager repositoryManager,IMapper mapper ) : IPrincipalService
    {
        private readonly IRepositoryManager _repositoryManager = repositoryManager;
        private readonly IMapper _mapper = mapper;
        public async Task<IEnumerable<PrincipalDto>> GetPrincipalFullAsync()
        {
            var principals = await _repositoryManager.Principals. GetPrincipalFullAsync();
            var principalsDto = _mapper.Map<IEnumerable<PrincipalDto>>(principals);
            return principalsDto;
        }
        public async Task<IEnumerable<PrincipalDto>> GetAllAsync()
        {
            var principals = await _repositoryManager.Principals.GetAsync();
            var principalsDto = _mapper.Map<IEnumerable<PrincipalDto>>(principals);
            return principalsDto;
        }
        public async Task<PrincipalDto?> GetByIdAsync(int id)
        {
            var p = await _repositoryManager.Principals.GetByIdAsync(id);
            var pDto = _mapper.Map<PrincipalDto>(p);
            return pDto;
        }
        public async Task<PrincipalDto?> GetByIdDataAsync(int id)
        {
            var p = await _repositoryManager.Principals.GetByIdDataAsync(id);
            var pDto = _mapper.Map<PrincipalDto>(p);
            return pDto;
        }
        public async Task<PrincipalDto> AddAsync(PrincipalDto pDto)
        {
            var p = _mapper.Map<Principal>(pDto);
            await _repositoryManager.Principals.AddAsync(p);
            await _repositoryManager.SaveAsync();
            return pDto;
        }
        public async Task<PrincipalDto> UpdateAsync(int id, PrincipalDto updatedEntity)
        {
            var p = _mapper.Map<Principal>(updatedEntity);
            await _repositoryManager.Principals.UpdateAsync(id, p);
            await _repositoryManager.SaveAsync();
            return updatedEntity;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            await _repositoryManager.Principals.DeleteAsync(id);
            await _repositoryManager.SaveAsync();
            return true;
        }

    }
}
