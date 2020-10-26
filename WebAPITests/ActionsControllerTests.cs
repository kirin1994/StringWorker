using Infrastructure.Persistance;
using Moq;
using System;
using System.Collections.Generic;
using WebAPI.Controllers;
using Xunit;
using Action = Core.Entities.Action;

namespace WebAPITests
{
    public class ActionsControllerTests
    {
        [Fact]
        public async void GetActionsReturnsListOfActions()
        {
            var mockRepo = new Mock<IActionAsyncRepository>();
            mockRepo.Setup(repo => repo.GetActionsAsync()).ReturnsAsync(ActionMemoryDb.GetTestActions());
            var controller = new ActionsController(mockRepo.Object);

            var actions = await controller.GetActions();

            Assert.Equal(ActionMemoryDb.GetTestActions().Count, actions.Count);
        }
    }
}
