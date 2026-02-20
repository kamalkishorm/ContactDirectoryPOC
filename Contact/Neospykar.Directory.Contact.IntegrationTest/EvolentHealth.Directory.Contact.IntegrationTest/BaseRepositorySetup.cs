using Neospykar.Directory.Contact.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neospykar.Directory.Contact.IntegrationTest
{
    public class BaseRepositorySetup
    {
        protected void SetupContacts(DbContextOptions<NeospykarDirectoryContext> options)
        {
            using (var context = new NeospykarDirectoryContext(options))
            {
                context.Contacts.Add(new Repository.Models.Contact()
                {
                    Id = 1,
                    FirstName = "Test",
                    LastName = "John",
                    Email = "test.john@test.com",
                    PhoneNumber = "+91-8989898989",
                    Status = "Active"
                });
                context.Contacts.Add(new Repository.Models.Contact()
                {
                    Id = 2,
                    FirstName = "Test2",
                    LastName = "John",
                    Email = "test2.john@test.com",
                    PhoneNumber = "+91-8989898989",
                    Status = "Active"
                });
                context.SaveChanges();
            }
        }
    }
}
