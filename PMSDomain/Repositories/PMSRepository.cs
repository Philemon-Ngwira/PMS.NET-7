using PMSDomain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSDomain.Repositories
{
    public class PMSRepository : GenericRepository
    {
        private readonly PMSDBContext _context;

        public PMSRepository(PMSDBContext context) :base(context) { 
            _context = context;
        }
    }
}
