using Acme.Data.Models;

namespace Acme.Data.Repositories
{
    public interface IContactRepository
    {
        void AddContact(Contact contact);
        void UpdateContact(Contact contact);
        void DeleteContact(Contact contact);
        Contact? GetContact(int id);
        IEnumerable<Contact> GetContacts();
        IEnumerable<Contact> GetContacts(IList<int> ids);
    }
}