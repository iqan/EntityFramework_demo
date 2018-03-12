using EFCoreDemo.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("init:");

            try
            {

                var optionsBuilder = new DbContextOptionsBuilder<DataContext>();

                var server = ".\\sqlexpress";

                var connection = $"Server={server};Database=Test;Trusted_Connection=True;MultipleActiveResultSets=true";

                optionsBuilder.UseSqlServer(connection);

                var db = new DataContext(optionsBuilder.Options);

                var repository = new TempUserRepository(db);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("saving some users.");

                repository.InsertMultipleTempUsers(new List<tempUser>
                {
                    new tempUser { username = "asd" },
                    new tempUser { username = "qwe" }
                });

                Console.WriteLine("getting all users.");

                foreach (var user in repository.GetTempUsers())
                {
                    Console.WriteLine($"Id: {user.userid} - Name: {user.username}");
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Done!");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("An error occurred.");
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"InnerException: {ex.InnerException}");
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.ReadLine();
        }
    }
}
