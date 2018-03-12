using EFCoreDemo.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace EFCoreDemo
{
    public class TempUserRepository
    {
        private readonly DataContext dataContext;

        public TempUserRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public IEnumerable<tempUser> GetTempUsers()
        {
            return this.dataContext.TempUser;
        }

        public void InsertMultipleTempUsers(IEnumerable<tempUser> users)
        {
            using (var transaction = this.dataContext.Database.BeginTransaction())
            {
                try
                {
                    this.dataContext.TempUser.AddRange(users);
                    this.dataContext.SaveChanges();
                    transaction.Commit();
                    Console.WriteLine("Users saved successfully.");
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error occured. Rolling back transaction.\r\nError: {ex.Message}");
                    transaction.Rollback();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
            }
        }
    }
}
