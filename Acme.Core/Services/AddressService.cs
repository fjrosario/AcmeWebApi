using Acme.Data.Models;
using Acme.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Domain.Services
{
    public class AddressService : IAddressService
    {
        private IAddressRepository _addressRepository;
        public AddressService(IAddressRepository addressRepository)
        {
            ArgumentNullException.ThrowIfNull(addressRepository, nameof(addressRepository));
            _addressRepository = addressRepository;
        }

        public void AddAddress(Address address)
        {
            _addressRepository.AddAddress(address);
        }

        public void UpdateAddress(Address address)
        {
            _addressRepository.UpdateAddress(address);
        }

        public void DeleteAddress(Address address)
        {
            _addressRepository.DeleteAddress(address);
        }

        public Address? GetAddress(int id)
        {
            return _addressRepository.GetAddress(id);
        }

        public IEnumerable<Address> GetAddresses()
        {
            return _addressRepository.GetAddresses();
        }

        public IEnumerable<Address> GetAddresses(IList<int> addressIds)
        {
            return _addressRepository.GetAddresses(addressIds);
        }
    }
}
