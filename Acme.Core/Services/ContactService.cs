using Acme.Data.Models;
using Acme.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Domain.Services
{
    public class ContactService : IContactService
    {
        private IContactRepository _contactRepository;
        public ContactService(IContactRepository contactRepository)
        {
            ArgumentNullException.ThrowIfNull(contactRepository, nameof(contactRepository));
            _contactRepository = contactRepository;
        }
        public void AddContact(Contact contact)
        {
            // Add contact to database
            _contactRepository.AddContact(contact);
        }

        public void UpdateContact(Contact contact)
        {
            // Update contact in database
            _contactRepository.UpdateContact(contact);
        }

        public void DeleteContact(Contact contact)
        {
            // Delete contact from database
            _contactRepository.DeleteContact(contact);
        }

        public Contact? GetContact(int id)
        {
            // Get contact from database
            return _contactRepository.GetContact(id);
        }

        public IEnumerable<Contact> GetContacts()
        {
            // Get all contacts from database
            return _contactRepository.GetContacts();
        }

        public IEnumerable<Contact> GetContacts(IList<int> contactIds)
        {
            // Get all contacts from database by ids
            return _contactRepository.GetContacts(contactIds);
        }
    }
}
