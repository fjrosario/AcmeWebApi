using Acme.Data.Models;
using Acme.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Domain.Tests.Mocks.Repositories
{
    public class ContactRepository : Moq.Mock<IContactRepository>
    {

        public ContactRepository() { 
        
        }
        public void AddContact(Contact contact)
        {
            throw new NotImplementedException();
        }

        public void DeleteContact(Contact contact)
        {
            throw new NotImplementedException();
        }

        public Contact? GetContact(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contact> GetContacts()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contact> GetContacts(IList<int> ids)
        {
            throw new NotImplementedException();
        }

        public void UpdateContact(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
