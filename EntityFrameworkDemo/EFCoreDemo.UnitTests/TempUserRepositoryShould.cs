using EFCoreDemo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace EFCoreDemo.UnitTests
{
    public class TempUserRepositoryShould
    {
        [Fact]
        public void ReturnListOfUsers_WhenGetTempUsersIsCalled()
        {
            const string databaseName = "get_test1";
            const int expectedUsersCount = 2;

            var dbContextOptions = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: databaseName)
                .Options;

            var context = new DataContext(dbContextOptions);

            var usersToAdd = new List<tempUser>
            {
                new tempUser { userid = 123, username = "asd" },
                new tempUser { userid = 456, username = "qwe" }
            };
            context.AddRange(usersToAdd);
            context.SaveChanges();

            var repository = new TempUserRepository(context);

            var users = repository.GetTempUsers();

            Assert.NotNull(users);
            
            Assert.Equal(expectedUsersCount, users.Count());
        }

        [Fact]
        public void AddListOfUsers_WhenInsertMultipleTempUsersIsCalled_WithListOfUsers()
        {
            var warningToIgnore = InMemoryEventId.TransactionIgnoredWarning;
            const string databaseName = "save_test1";
            const int expectedUsersCount = 2;
            var usersToAdd = new List<tempUser>
            {
                new tempUser { userid = 123, username = "asd" },
                new tempUser { userid = 456, username = "qwe" }
            };

            var dbContextOptions = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: databaseName)
                .ConfigureWarnings(w => w.Ignore(warningToIgnore))
                .Options;

            var context = new DataContext(dbContextOptions);
            
            var repository = new TempUserRepository(context);

            repository.InsertMultipleTempUsers(usersToAdd);

            var users = context.TempUser;

            Assert.NotNull(users);

            Assert.Equal(expectedUsersCount, users.Count());
        }
    }
}
