using Acme.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Data.Repositories
{
    public class ContactRepository<T> : BaseRepository<T>, IContactRepository where T : AcmeDataContext
    {
        public ContactRepository(IDbContextFactory<T> dbContextFactory): base(dbContextFactory)
        {

        }
        public void AddContact(Contact contact)
        {

            ArgumentNullException.ThrowIfNull(contact, nameof(contact));
            Context.Contacts.Add(contact); 
            Context.SaveChanges();
        }

        public void UpdateContact(Contact contact)
        {
            ArgumentNullException.ThrowIfNull(contact, nameof(contact));
            // Update contact in database
            Context.Contacts.Update(contact);
            Context.SaveChanges();
        }

        public void DeleteContact(Contact contact) 
        {
            ArgumentNullException.ThrowIfNull(contact, nameof(contact));
            // Delete contact from database
            Context.Contacts.Remove(contact);
            Context.SaveChanges();
        }

        public Contact? GetContact(int id)
        {
            // Get contact from database
            return Context.Contacts.Find(id);
        }

        public IEnumerable<Contact> GetContacts()
        {
            // Get contacts from database
            return Context.Contacts.ToList();
            Context.SaveChanges();
        }


        public IEnumerable<Models.Contact> GetContacts(IList<int> ids)
        {
            ids = ids ?? Array.Empty<int>();
            if (!ids.Any())
            {
                return Array.Empty<Models.Contact>();
            }
            return Context.Contacts.Where(c => ids.Contains(c.Id)).ToList();
        }

    }
}
