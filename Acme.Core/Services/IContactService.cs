using Acme.Data.Models;

namespace Acme.Domain.Services
{
    public interface IContactService
    {
        void AddContact(Contact contact);
        void DeleteContact(Contact contact);
        Contact? GetContact(int id);
        IEnumerable<Contact> GetContacts();
        IEnumerable<Contact> GetContacts(IList<int> contactIds);
        void UpdateContact(Contact contact);
    }
}