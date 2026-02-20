using System.Linq;
using System.Threading.Tasks;
using Neospykar.Directory.Contact.Contract.Interface.Repository;
using Neospykar.Directory.Contact.Contract.Models.Dto;
using Neospykar.Directory.Contact.Repository;
using Neospykar.Directory.Contact.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Neospykar.Directory.Contact.IntegrationTest
{
    [TestClass]
    public class ContactRepositoryTest
    {
        [TestMethod]
        public async Task Test_GetContactList()
        {
            Mock<ILogger<ContactRepository>> loggerMock = new Mock<ILogger<ContactRepository>>();
            var options = new DbContextOptionsBuilder<NeospykarDirectoryContext>()
                .UseInMemoryDatabase("ContactRepositoryInMemoryDb")
                .Options;
            using (var context = new NeospykarDirectoryContext(options))
            {
                context.Database.EnsureCreated();
            }
            using (var context = new NeospykarDirectoryContext(options))
            {
                IContactRepository contactRepository = new ContactRepository(context, loggerMock.Object);
                var response = await contactRepository.GetContactList().ConfigureAwait(false);
                Assert.IsTrue(response.Count() > 0);
            }
        }

        [TestMethod]
        public async Task Test_GetContactById()
        {
            Mock<ILogger<ContactRepository>> loggerMock = new Mock<ILogger<ContactRepository>>();
            var options = new DbContextOptionsBuilder<NeospykarDirectoryContext>()
                .UseInMemoryDatabase("ContactRepositoryInMemoryDb")
                .Options;
            using (var context = new NeospykarDirectoryContext(options))
            {
                context.Database.EnsureCreated();
            }
            using (var context = new NeospykarDirectoryContext(options))
            {
                const int contactId = 1;
                IContactRepository contactRepository = new ContactRepository(context, loggerMock.Object);
                var response = await contactRepository.GetContactById(contactId).ConfigureAwait(false);
                Assert.IsNotNull(response);
                Assert.IsTrue(response.Id == contactId);
            }
        }

        [TestMethod]
        public async Task Test_CreateContact()
        {
            Mock<ILogger<ContactRepository>> loggerMock = new Mock<ILogger<ContactRepository>>();
            var options = new DbContextOptionsBuilder<NeospykarDirectoryContext>()
                .UseInMemoryDatabase("ContactRepositoryInMemoryDb")
                .Options;
            using (var context = new NeospykarDirectoryContext(options))
            {
                context.Database.EnsureCreated();
            }
            using (var context = new NeospykarDirectoryContext(options))
            {
                var contact = new ContactDto()
                {
                    FirstName = "Kamal",
                    Email = "kkm7668@gmail.com",
                    Status = "Active"
                };
                IContactRepository contactRepository = new ContactRepository(context, loggerMock.Object);
                var response = await contactRepository.CreateContact(contact).ConfigureAwait(false);
                Assert.IsNotNull(response);
                Assert.IsTrue(response);
            }
        }

        [TestMethod]
        public async Task Test_UpdateContact()
        {
            Mock<ILogger<ContactRepository>> loggerMock = new Mock<ILogger<ContactRepository>>();
            var options = new DbContextOptionsBuilder<NeospykarDirectoryContext>()
                .UseInMemoryDatabase("ContactRepositoryInMemoryDb")
                .Options;
            using (var context = new NeospykarDirectoryContext(options))
            {
                context.Database.EnsureCreated();
            }
            using (var context = new NeospykarDirectoryContext(options))
            {
                const int contactId = 1;
                var contact = new ContactDto()
                {
                    FirstName = "Kamal",
                    Email = "kkm7668@gmail.com",
                    Status = "Active"
                };
                IContactRepository contactRepository = new ContactRepository(context, loggerMock.Object);
                var response = await contactRepository.UpdateContact(contactId, contact).ConfigureAwait(false);
                Assert.IsNotNull(response);
                Assert.IsTrue(response);
            }
        }

        [TestMethod]
        public async Task Test_UpdateStatusContact()
        {
            Mock<ILogger<ContactRepository>> loggerMock = new Mock<ILogger<ContactRepository>>();
            var options = new DbContextOptionsBuilder<NeospykarDirectoryContext>()
                .UseInMemoryDatabase("ContactRepositoryInMemoryDb")
                .Options;
            using (var context = new NeospykarDirectoryContext(options))
            {
                context.Database.EnsureCreated();
            }
            using (var context = new NeospykarDirectoryContext(options))
            {
                const int contactId = 1;
                const string status = "Inactive";
                IContactRepository contactRepository = new ContactRepository(context, loggerMock.Object);
                var response = await contactRepository.UpdateStatusContact(contactId, status).ConfigureAwait(false);
                Assert.IsNotNull(response);
                Assert.IsTrue(response);
            }
        }
    }
}
