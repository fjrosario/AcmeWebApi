using Acme.Data.Models;
using Acme.Data.Repositories;
using Acme.Domain.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Domain.Tests.Services
{
    [TestClass]
    public class AddressServiceTest: BaseTestService
    {
        IAddressRepository _repo;




        public AddressServiceTest()
        {
            _repo = new AddressRepository<MockDataContext>(TestDbContextFactory);
        }


        public Address GetNewAddress()
        {
            return new Address()
            {
                Street = new string[2]
                {
                    "1313 Mockingbird Lane",
                    string.Empty
                },
                City = "Mockingbird Heights",
                State = "CA",
                Zip = "90210",
                Primary = true
            };
        }

        [TestMethod]
        public void AddAddress()
        {
            var newAddress = GetNewAddress();
            _repo.AddAddress(newAddress);
            var foundAddress = _repo.GetAddress(newAddress.Id);
            Assert.IsNotNull(foundAddress);
        }

        [TestMethod]
        public void DeleteAddress()
        {
            var newAddress = GetNewAddress();
            _repo.AddAddress(newAddress);
            int oldId = newAddress.Id;
            _repo.DeleteAddress(newAddress);
            var foundAddress = _repo.GetAddress(oldId);
            Assert.IsNull(foundAddress);
        }

        [TestMethod]
        public void UpdateAddress()
        {
            const string testCity = "Boston";
            var address = GetNewAddress();
            _repo.AddAddress(address);
            address.City = "Boston";
            _repo.UpdateAddress(address);
            var foundAddress = _repo.GetAddress(address.Id);
            Assert.IsNotNull(foundAddress);
            Assert.AreEqual(foundAddress.City, testCity);
        }

        [TestMethod]
        public void GetAddress()
        {
            var address = GetNewAddress();
            _repo.AddAddress(address);
            var foundAddress = _repo.GetAddress(address.Id);
            Assert.IsNotNull(foundAddress);
        }

        [TestMethod]
        public void GetAddresses()
        {
            var address = GetNewAddress();
            _repo.AddAddress(address);
            var address2 = GetNewAddress();
            address2.Primary = false;
            _repo.AddAddress(address2);

            var addresses = _repo.GetAddresses();
            Assert.IsTrue(addresses.Any());

            var addressIds = addresses.Select(a => a.Id).ToArray();
            addresses = _repo.GetAddresses(addressIds).ToArray();
            Assert.IsNotNull(addresses);
            Assert.IsTrue(addresses.Any());
            Assert.AreEqual(addressIds.Length, addresses.Count());

            addresses = _repo.GetAddresses(Constants.BadIds);
            Assert.IsNotNull(addresses);
            Assert.IsFalse(addresses.Any()); 
        }
    }
}
