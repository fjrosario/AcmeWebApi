using Acme.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Acme.Data
{
    public interface IAcmeDataContext
    {
        DbSet<Address> Addresses { get; set; }
        DbSet<Contact> Contacts { get; set; }
        DbSet<Order> Orders { get; set; }

        int SaveChanges();
    }
}