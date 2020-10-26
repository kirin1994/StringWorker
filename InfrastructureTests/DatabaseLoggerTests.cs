using Infrastructure.Loggers;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Linq;
using Xunit;

namespace InfrastructureTests
{
    public class ActionAsyncRepositoryTests
    {
        [Fact]
        public void LogActionAddsRecordToDatabase()
        {
            var options = new DbContextOptionsBuilder<ActionDbContext>()
               .UseInMemoryDatabase(databaseName: "ActionTestDb")
               .Options;

            int numberOfActionsBeforeLogging;
            using (var context = new ActionDbContext(options))
            {
                context.AddRange(ActionMemoryDb.GetTestActions());
                context.SaveChanges();
                numberOfActionsBeforeLogging = context.Actions.ToList().Count;
            }

            int numberOfActionsAfterLogging;
            using (var context = new ActionDbContext(options))
            {
                ActionRepository actionRepository = new ActionRepository(context);
                var logger = new DatabaseLogger(actionRepository);
                logger.LogAction("TestAction", "TestInput", "TestOutput");
                numberOfActionsAfterLogging = actionRepository.GetActions().Count;
            }
          
            Assert.Equal(numberOfActionsBeforeLogging + 1, numberOfActionsAfterLogging);
        }
    }
}
