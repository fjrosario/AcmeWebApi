using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Data.Repositories
{
    public abstract class BaseRepository<T> where T : AcmeDataContext
    {
        private T _context;
        private IDbContextFactory<T> _contextFactory; 

        public BaseRepository(IDbContextFactory<T> dbContextFactory)
        {
            _contextFactory = dbContextFactory;
            _context = dbContextFactory.CreateDbContext();
        }


        protected T Context
        {
            get { return _context; }
        }
    }
}
