using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using WebApiRestLogging.Controllers;
using WebApiRestLogging.Services;
using Xunit;

namespace WebApiRestLogging.UnitTests
{
    public class GroceryControllerTests
    {
        [Fact]
        public async System.Threading.Tasks.Task GetAllGroceriesAsync()
        {
            //create the mock 
            var mockRepo = new Mock<IGroceryRepository>();
            var mockLogger = new Mock<ILogger<GroceryController>>();
            var groceryController = new GroceryController(mockRepo.Object, mockLogger.Object);
            //Act
            var result = await groceryController.GetAllGroceries();
            // Assert
             Assert.NotNull(result);
        }
    }
}