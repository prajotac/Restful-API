using Entities.Models;
using Moq;
using RESTAPI.Controllers;
using Services.Services;
using System;
using Xunit;

namespace RESTAPI.Test.Controllers
{
    public class UsersControllerTests
    {
        private MockRepository mockRepository;

        private Mock<IUserService> mockUserService;

        public UsersControllerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Default);

            this.mockUserService = this.mockRepository.Create<IUserService>();
        }

        private UsersController CreateUsersController()
        {
            return new UsersController(this.mockUserService.Object);
        }

        [Fact]
        public void PostTestMethod()
        {
            // Arrange
            var usersController = this.CreateUsersController();
            User usr = new User {            
                 Id= 11,
                Name = "Nilesh",
                UserName= "NileshChoudhari",
                Email= "Nilesh@gmail.com",
                Address= new Address
                {
                    street= "123",
                    suite= "suite 123",
                    city= "Pune",
                    zipcode= "411022",
                    geo= new GEO { lat= "24.6464", lng= "-168.283" },
                },
                Phone = "9970997345",
                Website = "Amdocs.com",
                Company =new Company {
                    name= "Amdocs",
                    catchPhrase= "Project",
                    bs = "MainFrame technologies"
                }   
            };

            // Act
            var result = usersController.Post(usr);

            // Assert
            Assert.True(true);
            Assert.Equal(11, result.Value?.Id);
            Assert.NotNull(result.Value?.Email);
            this.mockRepository.VerifyAll();
        }      

        [Fact]
        public void PutTestMethod()
        {
            // Arrange
            var usersController = this.CreateUsersController();
            string id = "628a6647175b220080e76d1b";
            User usr = new User
            {
                Id = 11,
                Name = "Nilesh",
                UserName = "NileshChoudhari",
                Email = "Nilesh@gmail.com",
                Address = new Address
                {
                    street = "123",
                    suite = "suite 123",
                    city = "Pune",
                    zipcode = "411022",
                    geo = new GEO { lat = "24.6464", lng = "-168.283" },
                },
                Phone = "9970997345",
                Website = "Amdocs.com",
                Company = new Company
                {
                    name = "Amdocs",
                    catchPhrase = "Project",
                    bs = "MainFrame technologies"
                }
            };

            // Act
            var result = usersController.Put(id, usr);

            // Assert
            Assert.True(result.Equals(result));
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void DeleteTestMethod()
        {
            // Arrange
            var usersController = this.CreateUsersController();
            string id = "628a6647175b220080e76d1b";

            // Act
            var result = usersController.Delete(id);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }
    }
}
