using Acme.Data.Models;

namespace Acme.Domain.Services
{
    public interface IAddressService
    {
        void AddAddress(Address address);
        void DeleteAddress(Address address);
        Address? GetAddress(int id);
        IEnumerable<Address> GetAddresses();
        IEnumerable<Address> GetAddresses(IList<int> addressIds);
        void UpdateAddress(Address address);
    }
}