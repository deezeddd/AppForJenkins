using System.Threading.Tasks;
using AppForJenkins.Controllers;
using AppForJenkins.Model;
using AppForJenkins.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace YourNamespace.Tests
{
    [TestClass]
    public class ProfileControllerTests
    {
        [TestMethod]
        public async Task Login_ValidCredentials_ReturnsOk()
        {
            // Arrange
            var model = new ProfileModel { Email = "test@example.com", Password = "password" };
            var expectedMessage = $"Welcome, {model.Email}!";

            var mockProfileService = new Mock<IProfileService>();
            mockProfileService.Setup(service => service.LoginAsync(model.Email, model.Password))
                              .ReturnsAsync(new ProfileModel { Email = model.Email });

            var controller = new ProfileController(mockProfileService.Object);

            // Act
            var result = await controller.Login(model) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(expectedMessage, result.Value);
        }

        [TestMethod]
        public async Task Login_InvalidCredentials_ReturnsBadRequest()
        {
            // Arrange
            var model = new ProfileModel { Email = "test@example.com", Password = "invalidpassword" };

            var mockProfileService = new Mock<IProfileService>();
            // Setup the mock to return null, indicating invalid credentials
            mockProfileService.Setup(service => service.LoginAsync(It.IsAny<string>(), It.IsAny<string>()))
                              .ReturnsAsync((ProfileModel)null);

            var controller = new ProfileController(mockProfileService.Object);

            // Act
            var result = await controller.Login(model) as BadRequestObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
            Assert.AreEqual("Invalid email or password.", result.Value);
        }

    }
}
