using Acme.Data;
using Acme.Data.Models;
using Acme.Data.Repositories;
using Acme.Domain.Tests.Mocks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Domain.Tests.Services
{
    public abstract class BaseTestService
    {
        private MockDataContext _context;

        [ClassInitialize]
        public void ClassInit(TestContext context)
        {
            ;
        }


        internal BaseTestService()
        {
            TestDbContextFactory = new TestDbContextFactory("Acme");
            _context = TestDbContextFactory.CreateDbContext();
        }

        protected TestDbContextFactory TestDbContextFactory { get;}

        protected MockDataContext Context
        {
            get { return _context; }
        }

        [TestInitialize]
        [TestCleanup]
        protected virtual void Cleanup()
        {
            Context.ClearDatabase();
        }
    }
}
