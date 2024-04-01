using Acme.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Data.Repositories
{
    public class AddressRepository<T> : BaseRepository<T>, IAddressRepository where T : AcmeDataContext
    {
        public AddressRepository(IDbContextFactory<T> dbContextFactory) : base(dbContextFactory)
         {

        }

        public Address? GetAddress(int id)
        {
            return Context.Addresses.FirstOrDefault(a => a.Id == id);
        }

        public void AddAddress(Address address)
        {
            Context.Addresses.Add(address);
            Context.SaveChanges();
        }

        public void UpdateAddress(Address address)
        {
            Context.Addresses.Update(address);
            Context.SaveChanges();
        }

        public void DeleteAddress(Address address)
        {
            Context.Addresses.Remove(address);
            Context.SaveChanges();
        }

        public IEnumerable<Address> GetAddresses()
        {
            return Context.Addresses.ToList();
        }

        public IEnumerable<Address> GetAddresses(IList<int> ids)
        {
            ids = ids ?? Array.Empty<int>();
            if (!ids.Any())
            {
                return Array.Empty<Address>();
            }
            return Context.Addresses.Where(a => ids.Contains(a.Id)).ToList();
        }
    }
}
