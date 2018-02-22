using EFCoreDemo.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EFCoreDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("init:");

            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();

            var server = "nv-sql-285-02.dev.kingsway.asos.com\\backoffice";

            var connection = $"Server={server};Database=AsosBackoffice;Trusted_Connection=True;MultipleActiveResultSets=true";

            optionsBuilder.UseSqlServer(connection);
                
            var db = new DataContext(optionsBuilder.Options);

            var users = db.TempUser;

            foreach (var user in users)
            {
                Console.WriteLine($"Id: {user.userid} - Name: {user.username}");
            }

            Console.WriteLine("Done!");
            Console.ReadLine();
        }
    }
}
