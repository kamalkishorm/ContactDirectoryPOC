using Neospykar.Directory.Contact.Repository.Context;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Neospykar.Directory.Contact.RunMigration
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Run Migration!");
            var optionsBuilder = new DbContextOptionsBuilder<NeospykarDirectoryContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-7168J1M\\MSSQLSERVER01;Initial Catalog=NeospykarDirectory;Integrated Security=True;");
            var context = new NeospykarDirectoryContext(optionsBuilder.Options);
            context.SaveChanges();

        }


    }

}
