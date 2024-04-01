using Acme.Data;
using Acme.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Domain.Tests.Mocks
{
    public class TestDbContextFactory : IDbContextFactory<MockDataContext>
    {
        private DbContextOptions<MockDataContext> _options;

        public TestDbContextFactory(string databaseName = "Acme")
        {
            _options = new DbContextOptionsBuilder<MockDataContext>()
                .UseInMemoryDatabase(databaseName)
                .Options;
        }

        public MockDataContext CreateDbContext()
        {
            return new MockDataContext(_options);
        }
    }
    public class MockDataContext: AcmeDataContext
    {

        public MockDataContext(DbContextOptions<MockDataContext> options) : base(new DbContextOptionsBuilder<AcmeDataContext>()
                .UseInMemoryDatabase("Acme")
                .Options)
        {
            
        }

        public void SeedDatabase()
        {

        }

        public void ClearDatabase()
        {
            Contacts.RemoveRange(Contacts);
            Addresses.RemoveRange(Addresses);
            Orders.RemoveRange(Orders);
            this.SaveChanges();
        }
    }
}
