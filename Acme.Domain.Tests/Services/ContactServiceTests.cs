using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.Data;
using Acme.Domain.Tests.Mocks;
using Acme.Domain.Tests.Services;
using Acme.Data.Repositories;
using Acme.Data.Models;
using Acme.Domain.Tests;

namespace Acme.Domain.Services.Tests
{
    [TestClass]
    public class ContactServiceTests: BaseTestService
    {
        private IContactRepository _repo;
        public ContactServiceTests()
        {
            _repo = new ContactRepository<MockDataContext>(TestDbContextFactory);
        }

        private Contact GetNewContact()
        {
            return new Contact()
            {
                Addresses = new List<Address>(),
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@fakeacmeco.com",
                Phone = "555-222-1234"
            };
        }

        [TestMethod]
        public void AddContactTest()
        {
            var contact = GetNewContact();
            _repo.AddContact(contact);
            var foundContact = _repo.GetContact(contact.Id);
            Assert.IsNotNull(foundContact);
        }

        [TestMethod]
        public void UpdateContactTest()
        {
            const string testName = "Jane";
            var contact = GetNewContact();
            _repo.AddContact(contact);
            var foundContact = _repo.GetContact(contact.Id);
            Assert.IsNotNull(foundContact);
            Assert.AreNotEqual(foundContact.FirstName, testName);

            contact.FirstName = testName;
            _repo.UpdateContact(contact);
            foundContact = _repo.GetContact(contact.Id);
            Assert.IsNotNull(foundContact);
            Assert.AreEqual(contact.FirstName, foundContact.FirstName);
        }

        [TestMethod]
        public void DeleteContactTest()
        {
            var contact = GetNewContact();
            _repo.AddContact(contact);
            var foundContact = _repo.GetContact(contact.Id);
            Assert.IsNotNull(foundContact);
            _repo.DeleteContact(contact);
            foundContact = _repo.GetContact(contact.Id);
            Assert.IsNull(foundContact);
        }

        [TestMethod]
        public void GetContactTest()
        {
            var contact = GetNewContact();
            _repo.AddContact(contact);
            var foundContact = _repo.GetContact(contact.Id);
            Assert.IsNotNull(foundContact);
        }

        [TestMethod]
        public void GetContactsTest()
        {
            var contact1 = GetNewContact();
            var contact2 = GetNewContact();
            contact2.FirstName = "Jane";
            _repo.AddContact(contact1);
            _repo.AddContact(contact2);
            var contacts = _repo.GetContacts(Constants.BadIds);

            Assert.IsFalse(contacts.Any());

            contacts = _repo.GetContacts();

            Assert.IsNotNull(contacts);
            Assert.IsTrue(contacts.Any());

            
            var contactIds = contacts.Select(a => a.Id).ToArray();
            contacts = _repo.GetContacts(contactIds).ToArray();
            Assert.IsNotNull(contacts);
            Assert.IsTrue(contacts.Any());
            Assert.AreEqual(contacts.Count(), contactIds.Count());

        }


    }
}