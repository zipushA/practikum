using Server.Core.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Repositorys
{
   public class RepositoryManager:IRepositoryManager
    {
        private readonly DataContext _context;
        public ITeacherRepository Teachers { get; }
        public IPrincipalRepository Principals { get; }
        public IMatchingDataRepository MatchingData { get; }

        public RepositoryManager(DataContext context, ITeacherRepository teacherRepository, IPrincipalRepository principals,IMatchingDataRepository matchingDataRepository)
        {
            _context = context;
            Teachers = teacherRepository;
            Principals = principals;
            MatchingData=matchingDataRepository;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
