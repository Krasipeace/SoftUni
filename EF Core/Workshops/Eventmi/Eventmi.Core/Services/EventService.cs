using Eventmi.Core.Contracts;
using Eventmi.Core.Models;
using Eventmi.Infrastructure.Data.Common;
using Eventmi.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Eventmi.Core.Services
{
    /// <summary>
    /// Service for control of the events
    /// </summary>
    public class EventService : IEventService
    {
        /// <summary>
        /// Database access
        /// </summary>
        private readonly IRepository repository;

        /// <summary>
        /// Dependency injection
        /// </summary>
        /// <param name="_repository">Database access</param>
        public EventService(IRepository _repository)
        {
            repository = _repository;
        }

        /// <summary>
        /// Add of Event
        /// </summary>
        /// <param name="model">Event data</param>
        /// <returns></returns>
        public async Task AddAsync(EventModel model)
        {
            var entity = new Event()
            {
                Name = model.Name,
                Start = model.Start,
                End = model.End,
                Place = model.Place
            };

            await repository.AddAsync(entity);
            await repository.SaveChangesAsync();
        }

        /// <summary>
        /// Delete of Event
        /// </summary>
        /// <param name="Id">Identification of Event</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task DeleteAsync(int Id)
        {
            await repository.DeleteAsync<Event>(Id);
            await repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(EventModel model)
        {
            var entity = await repository.GetByIdAsync<Event>(model.Id);

            if (entity == null)
            {
                throw new ArgumentException("Invalid Id", nameof(model.Id));
            }

            entity.Name = model.Name;
            entity.Start = model.Start;
            entity.End = model.End;
            entity.Place = model.Place;

            await repository.SaveChangesAsync();
        }

        /// <summary>
        /// Display of Event
        /// </summary>
        /// <param name="Id">Id of Event</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<EventModel> GetEventAsync(int Id)
        {
            var entity = await repository.GetByIdAsync<Event>(Id);

            if (entity == null)
            {
                throw new ArgumentException("Invalid Id", nameof(Id));
            }

            return new EventModel()
            {
                Name = entity.Name,
                Start = entity.Start,
                End = entity.End,
                Place = entity.Place
            };
        }

        /// <summary>
        /// Display all Events
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<EventModel>> GetAllAsync()
        {
            return await repository
                .AllReadonly<Event>()
                .Select(e => new EventModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Start = e.Start,
                    End = e.End,
                    Place = e.Place
                })
                .OrderBy(e => e.Start)
                .ToListAsync();
        }
    }
}
