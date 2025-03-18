using Server.Core.DTOs;
using Server.Core.Interfaces.IRepository;
using Server.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Core.Interfaces.Services
{
    public interface IPrincipalService
    {
        Task<IEnumerable<PrincipalDto>> GetPrincipalFullAsync();
       
        Task<IEnumerable<PrincipalDto>> GetAllAsync();
       
        Task<PrincipalDto?> GetByIdAsync(int id);
        Task<PrincipalDto?> GetByIdDataAsync(int id);


        Task<PrincipalDto> AddAsync(PrincipalDto p);


       Task<PrincipalDto> UpdateAsync(int id, PrincipalDto updatedEntity);


         Task<bool> DeleteAsync(int id);
        
    }
}
