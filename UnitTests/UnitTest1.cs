using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Microsoft.EntityFrameworkCore;
using Moq;
using PersonInfo.Models;
using PersonInfo.Repositories;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        public async Task Create()
        {
            //Mock DbContext and DbSet//
            var mockSet = new Mock<DbSet<User>>();
            var mockContext = new Mock<PersonDetailsContext>();
            mockContext.Setup(x => x.Users).Returns(mockSet.Object);

            var userService = new UserRepository(mockContext.Object);
            await userService.Insert(new User() { EmailAddress = "test", Name = "test", Surname = "test" });

            mockSet.Verify(x => x.AddAsync(It.IsAny<User>(), default), Times.Once());
            mockContext.Verify(x => x.SaveChangesAsync(default), Times.Once());

        }

        //[TestMethod]
        //public async Task GetUser()
        //{
        //    var userlist = new List<User>();
        //    {
        //        new User() { Id = 1, Name = "test", Surname = "test" };
        //        new User() { Id = 2, Name = "test", Surname = "test" };
        //        new User() { Id = 3, Name = "test", Surname = "test" };
        //    }


        //    var mockRepo = new Mock<IUserRepository>();
        //    mockRepo.Setup(x => x.GetUsers()).Returns(Task.FromResult(userlist));
        //    var result = await mockRepo.Object.GetUsers();
        //    Assert.AreEqual(result.Count, userlist.Count);
        //}



    }
}