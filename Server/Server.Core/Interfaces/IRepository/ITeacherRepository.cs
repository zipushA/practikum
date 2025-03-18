using Server.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Core.Interfaces.IRepository
{
    public interface ITeacherRepository: IGeneryRepository<Teacher>
    {
         Task<IEnumerable<Teacher>> GetTeachersDataAsync();

         Task<IEnumerable<Teacher>> GetOrderDataAsync(int id);

        Task<Teacher?> GetByIdDataAsync(int id);
       
    }
}
