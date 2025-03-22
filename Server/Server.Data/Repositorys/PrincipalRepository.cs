using Microsoft.EntityFrameworkCore;
using Server.Core.Interfaces.IRepository;
using Server.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Repositorys
{
    public class PrincipalRepository:GeneryRepository<Principal>, IPrincipalRepository
    {
        private readonly DbSet<Principal> _dataSet;
        public PrincipalRepository(DataContext context) : base(context)
        {
            _dataSet = context.Set<Principal>();
        }
        public async Task<IEnumerable<Principal>> GetPrincipalFullAsync()
        {
            return await _dataSet.Include(t => t.demand).ToListAsync();
        } 
        public async Task< Principal?> GetByIdDataAsync(int id)
        {
            return await _dataSet.Where(t => t.Id == id)
                 .Include(t => t.demand).FirstOrDefaultAsync();
        }
    }
}
