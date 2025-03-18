using Server.Core.DTOs;
using Server.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Core.Interfaces.Services
{
    public interface ITeacherService
    {
        public Task<IEnumerable<TeacherDto>> GetTeachersDataAsync();
        public Task<IEnumerable<TeacherDto>> GetOrderDataAsync(int id);
        public Task<IEnumerable<TeacherDto>> GetAllAsync();
        public Task<TeacherDto?> GetByIdDataAsync(int id);
        public Task<TeacherDto> AddAsync(TeacherDto t);
        public Task<TeacherDto> UpdateAsync(int id, TeacherDto t);
        public Task<bool> DeleteAsync(int id);
    }
}
