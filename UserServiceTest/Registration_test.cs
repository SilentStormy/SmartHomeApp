using Core_Domain;
using Core_Domain.Entities;
using Core_Domain.Service;
using Infrastructure.Data.DTO;
using Infrastructure.Data.Interfaces;
using Moq;
using Xunit;

namespace UserServiceTest
{
    public class Registration_test
    {
        [Fact]
        public void Register_ShouldAddUser()
        {
            var MockUserRepository = new Mock<IUserRepository>();
            var Mockconfirmation=new Mock<IRegistrationConfirmation>(); 
            var user = new User
            {
                Firstname = "Safa",
                Lastname = "Rrhioua",
                Email = "safa@test.com",
                Password = "password",
                Role = "Guest"

            };

            MockUserRepository.Setup(u=>u.EmailExists(user.Email)).Returns(false);

            var userservice=new UserService(MockUserRepository.Object);
            
            var reuslt = userservice.Register(user);

            Assert.True(reuslt.Success);
            Assert.Contains("geregistreerd", reuslt.Message);

        }
    }
}