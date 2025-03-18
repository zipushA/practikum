using Server.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Core.Interfaces.IRepository
{
    public interface IPrincipalRepository: IGeneryRepository<Principal>
    {
         Task<IEnumerable<Principal>> GetPrincipalFullAsync();
        Task<Principal?> GetByIdDataAsync(int id);
    }
}
