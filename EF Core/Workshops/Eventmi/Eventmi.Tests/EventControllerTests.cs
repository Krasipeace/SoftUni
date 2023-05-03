using Eventmi.Controllers;
using Eventmi.Core.Contracts;
using Eventmi.Core.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Moq;

namespace Eventmi.Tests
{
    public class EventControllerTests
    {
        private Mock<IEventService> eventServiceMock;
        private Mock<ILogger<EventController>> loggerMock;
        private EventController controller;

        [SetUp]
        public void SetUp()
        {
            eventServiceMock = new Mock<IEventService>();
            loggerMock = new Mock<ILogger<EventController>>();
            controller = new EventController(eventServiceMock.Object, loggerMock.Object);
        }

        [Test]
        public void Index_WorksCorrectly()
        {
            var result = controller.Index();
            Assert.IsInstanceOf<Task<IActionResult>>(result);

            var viewResult = result.Result as ViewResult;
            Assert.IsInstanceOf<ViewResult>(viewResult);

            var model = viewResult.Model as IEnumerable<EventModel>;
            Assert.IsInstanceOf<IEnumerable<EventModel>>(model);

            Assert.AreEqual("All", viewResult.ViewName);
            Assert.AreEqual(model, viewResult.Model);
            Assert.AreEqual(Enumerable.Empty<EventModel>(), model);
        }

        [Test]
        public void Add_Get_WorksCorrectly()
        {
            var result = controller.Add();
            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.IsInstanceOf<ViewResult>(viewResult);
            var model = viewResult.Model as EventModel;
            Assert.IsInstanceOf<EventModel>(model);

            Assert.AreEqual(DateTime.Today, model.Start);
            Assert.AreEqual(DateTime.Today, model.End);
            Assert.AreEqual(model, viewResult.Model);
        }

        [Test]
        public async Task Add_Post_WorksCorrectly()
        {
            var model = new EventModel
            {
                Name = "Test Event",
                Start = new DateTime(2023, 5, 10, 10, 0, 0),
                End = new DateTime(2023, 5, 10, 12, 0, 0),
                Place = "Test Place"
            };
            var result = await controller.Add(model);

            Assert.IsInstanceOf<RedirectToActionResult>(result);
            eventServiceMock.Verify(e => e.AddAsync(model), Times.Once);
        }

        [Test]
        public async Task Delete_WorksCorrectly()
        {
            var eventId = 1;
            var result = await controller.Delete(eventId);

            Assert.IsInstanceOf<RedirectToActionResult>(result);
            eventServiceMock.Verify(e => e.DeleteAsync(eventId), Times.Once);
        }

        //to do more tests
    }
}