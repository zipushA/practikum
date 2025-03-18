using AutoMapper;
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
    public class TeacherService(IRepositoryManager repositoryManager,IMapper mapper): ITeacherService
    {
        private readonly IRepositoryManager _repositoryManager = repositoryManager;
        private readonly IMapper _mapper = mapper;
        public async Task<IEnumerable<TeacherDto>> GetTeachersDataAsync()
        {
            var teachers = await _repositoryManager.Teachers.GetTeachersDataAsync();
            var teachersDto = _mapper.Map<IEnumerable<TeacherDto>>(teachers);
            return teachersDto;
            
        }
        public async Task<IEnumerable<TeacherDto>> GetOrderDataAsync(int id)
        {
            var teachers = await _repositoryManager.Teachers.GetOrderDataAsync(id);
            var teachersDto = _mapper.Map<IEnumerable<TeacherDto>>(teachers);
            return teachersDto;
            
        }
        public async Task<IEnumerable<TeacherDto>> GetAllAsync()
        {
            var teachers = await _repositoryManager.Teachers.GetAsync();
            var teachersDto = _mapper.Map<IEnumerable<TeacherDto>>(teachers);
            return teachersDto;
            
        }
        public async Task<TeacherDto?> GetByIdDataAsync(int id)
        {
            var t = await _repositoryManager.Teachers.GetByIdDataAsync(id);
            var tDto = _mapper.Map<TeacherDto>(t);
            return tDto;
            
        }
        public async Task<TeacherDto> AddAsync(TeacherDto tDto)
        {
            var t = _mapper.Map<Teacher>(tDto);
            await _repositoryManager.Teachers.AddAsync(t);
           await _repositoryManager.SaveAsync();
            return tDto;
        }
        public async Task<TeacherDto> UpdateAsync(int id, TeacherDto updatedEntity)
        {
            var t = _mapper.Map<Teacher>(updatedEntity);
            await _repositoryManager.Teachers.UpdateAsync(id, t);
            await _repositoryManager.SaveAsync();
            return updatedEntity;
        }
        public async Task<bool> DeleteAsync(int id)
        {
         await _repositoryManager.Teachers.DeleteAsync(id);
            await _repositoryManager.SaveAsync();
            return true;
        }

    }
}
