using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.CreateUser;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateUserCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnUserId()
        {
            //Arrange
            var userRepository = new Mock<IUserRepository>();
            var authService = new Mock<IAuthService>();


            var createUserCommand = new CreateUserCommand
            {
                FullName = "Titulo de Teste",
                BirthDate = DateTime.Now,
                Email = "teste@gmail.com",
                Password = "Teste#123",
                Role = "Client"

            };

            var createUSerCommandHandler = new CreateUserCommandHandler(userRepository.Object, authService.Object);

            //Act

            var id = await createUSerCommandHandler.Handle(createUserCommand, new CancellationToken());
            //Assert

            Assert.True(id >= 0);

            userRepository.Verify(pr => pr.AddUser(It.IsAny<User>()), Times.Once);

        }
    }
}
