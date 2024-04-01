using Acme.Data.Models;

namespace Acme.Data.Repositories
{
    public interface IAddressRepository
    {
        void AddAddress(Address address);
        void DeleteAddress(Address address);
        Address? GetAddress(int id);
        IEnumerable<Address> GetAddresses();
        IEnumerable<Address> GetAddresses(IList<int> ids);
        void UpdateAddress(Address address);
    }
}