using Eventmi.Core.Models;
using Eventmi.Core.Services;
using Eventmi.Infrastructure.Data.Common;
using Eventmi.Infrastructure.Data.Models;

using Moq;

namespace Eventmi.Tests
{
    public class EventServiceTests
    {
        private Mock<IRepository> repositoryMock;
        private EventService eventService;

        [SetUp]
        public void Setup()
        {
            repositoryMock = new Mock<IRepository>();
            eventService = new EventService(repositoryMock.Object);
        }

        [Test]
        public async Task AddAsync_WorksCorrectly()
        {
            var model = new EventModel
            {
                Name = "Test Event",
                Start = new DateTime(2023, 5, 10, 10, 0, 0),
                End = new DateTime(2023, 5, 10, 12, 0, 0),
                Place = "Test Place"
            };

            await eventService.AddAsync(model);

            repositoryMock.Verify(r => r.AddAsync(It.Is<Event>(e =>
                e.Name == model.Name &&
                e.Start == model.Start &&
                e.End == model.End &&
                e.Place == model.Place)), Times.Once);

            repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task DeleteAsync_DeletesEventFromRepository_WorksCorrectly()
        {
            var eventId = 1;

            await eventService.DeleteAsync(eventId);

            repositoryMock.Verify(r => r.DeleteAsync<Event>(eventId), Times.Once);
            repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task UpdateAsync_UpdatesEventInRepository_WorksCorrectly()
        {
            var model = new EventModel
            {
                Id = 1,
                Name = "Updated Event",
                Start = new DateTime(2023, 5, 10, 10, 0, 0),
                End = new DateTime(2023, 5, 10, 12, 0, 0),
                Place = "Updated Place"
            };

            var entity = new Event
            {
                Id = model.Id,
                Name = "Test Event",
                Start = new DateTime(2023, 5, 9, 10, 0, 0),
                End = new DateTime(2023, 5, 9, 12, 0, 0),
                Place = "Test Place"
            };

            repositoryMock.Setup(r => r.GetByIdAsync<Event>(model.Id)).ReturnsAsync(entity);

            await eventService.UpdateAsync(model);

            repositoryMock.Verify(r => r.GetByIdAsync<Event>(model.Id), Times.Once);

            repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);

            Assert.That(entity.Name, Is.EqualTo(model.Name));
            Assert.That(entity.Start, Is.EqualTo(model.Start));
            Assert.That(entity.End, Is.EqualTo(model.End));
            Assert.That(entity.Place, Is.EqualTo(model.Place));
        }

        [Test]
        public async Task GetEventAsync_WorksCorrectly()
        {
            int id = 1;
            var eventEntity = new Event
            {
                Id = id,
                Name = "Test Event",
                Start = DateTime.UtcNow,
                End = DateTime.UtcNow.AddDays(1),
                Place = "Test Place"
            };

            repositoryMock.Setup(r => r.GetByIdAsync<Event>(id)).ReturnsAsync(eventEntity);

            var eventModel = await eventService.GetEventAsync(id);

            Assert.That(eventModel, Is.Not.Null);
            Assert.That(eventModel.Name, Is.EqualTo(eventEntity.Name));
            Assert.That(eventModel.Start, Is.EqualTo(eventEntity.Start));
            Assert.That(eventModel.End, Is.EqualTo(eventEntity.End));
            Assert.That(eventModel.Place, Is.EqualTo(eventEntity.Place));
        }            

        [Test]
        public void GetAllAsync_ThrowsException()
        {
            repositoryMock.Setup(r => r.AllReadonly<Event>()).Throws(new Exception("Unknown Error!"));

            Assert.ThrowsAsync<Exception>(() => eventService.GetAllAsync());
        }

        [Test]
        public void GetEventAsync_ThrowsException()
        {
            repositoryMock.Setup(r => r.GetByIdAsync<Event>(It.IsAny<int>())).Throws(new Exception("Unknown Error!"));

            Assert.ThrowsAsync<Exception>(() => eventService.GetEventAsync(It.IsAny<int>()));
        }

        [Test]
        public async Task UpdateAsync_ThrowsException()
        {
            repositoryMock.Setup(r => r.GetByIdAsync<Event>(It.IsAny<int>())).Throws(new Exception("Unknown Error!"));
            var model = new EventModel
            {
                Id = 1,
                Name = "Updated Event",
                Start = new DateTime(2023, 5, 10, 10, 0, 0),
                End = new DateTime(2023, 5, 10, 12, 0, 0),
                Place = "Updated Place"
            };
            Assert.ThrowsAsync<Exception>(() => eventService.UpdateAsync(model));
        }

        [Test]
        public void DeleteAsync_ThrowsException()
        {
            repositoryMock.Setup(r => r.DeleteAsync<Event>(It.IsAny<int>())).Throws(new Exception("Unknown Error!"));

            Assert.ThrowsAsync<Exception>(() => eventService.DeleteAsync(It.IsAny<int>()));
        }

        [Test]
        public async Task AddAsync_ThrowsException()
        {
            repositoryMock.Setup(r => r.AddAsync(It.IsAny<Event>())).Throws(new Exception("Unknown Error!"));
            var model = new EventModel
            {
                Name = "Test Event",
                Start = new DateTime(2023, 5, 10, 10, 0, 0),
                End = new DateTime(2023, 5, 10, 12, 0, 0),
                Place = "Test Place"
            };
            Assert.ThrowsAsync<Exception>(() => eventService.AddAsync(model));
        }

        //to do more tests
    }
}