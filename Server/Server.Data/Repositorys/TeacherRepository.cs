using Microsoft.EntityFrameworkCore;
using Server.Core.Interfaces.IRepository;
using Server.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Repositorys
{
    public class TeacherRepository : GeneryRepository<Teacher>, ITeacherRepository
    {
        private readonly DbSet<Teacher> _dataSet;
        private readonly IPrincipalRepository _principalRepository;
        public TeacherRepository(DataContext context,IPrincipalRepository principalRepository) : base(context)
        {
            _dataSet = context.Set<Teacher>();
            _principalRepository = principalRepository;
        }
        public async Task<IEnumerable<Teacher>> GetTeachersDataAsync()
        {
            return await _dataSet.Include(t=>t.Data).ToListAsync();
        }
        public async Task<IEnumerable<Teacher>> GetOrderDataAsync(int id)
        {
            Principal p = await _principalRepository.GetByIdDataAsync(id);

            if (p == null)
            {
                // טיפול במקרה שבו המנהל לא נמצא
                throw new Exception("Principal not found");
            }

            return await _dataSet
                .Include(t => t.Data)
                .Where(t => t.Data != null && // בדוק אם t.data לא null
                            t.Data.Seniority >= p.demand.Seniority &&
                            t.Data.IsBoys == p.demand.IsBoys &&
                            t.Data.IsKeruv == p.demand.IsKeruv &&
                            t.Data.ResidentialArea == p.demand.ResidentialArea)
                .ToListAsync();
        }
        public async Task<Teacher?> GetByIdDataAsync(int id)
        {
            return await _dataSet.Where(t => t.Id == id)
                 .Include(t=>t.Data).FirstOrDefaultAsync();
        }

    }


}
