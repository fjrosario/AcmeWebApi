using Acme.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Data
{
    public class DbInitializer
    {
        public static void Initialize(AcmeDataContext context)
        {
            context.Database.EnsureCreated();

            var addresses = new Address[]
            {
            };

            context.Addresses.AddRange(addresses);
            context.SaveChanges();

            var contacts = new Contact[]
            {
            };

            context.Contacts.AddRange(contacts);

            context.SaveChanges();

            var orders = new Order[]
            {
            };
            context.Orders.AddRange(orders);
            context.SaveChanges();

        }
    }
}
