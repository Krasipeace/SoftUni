using Eventmi.Core.Models;

namespace Eventmi.Core.Contracts
{
    /// <summary>
    /// Service for events
    /// </summary>
    public interface IEventService
    {
        /// <summary>
        /// Add Event
        /// </summary>
        /// <param name="model">Event data</param>
        /// <returns></returns>
        Task AddAsync(EventModel model);

        /// <summary>
        /// Delete Event
        /// </summary>
        /// <param name="Id">Identification of event</param>
        /// <returns></returns>
        Task DeleteAsync(int Id);

        /// <summary>
        /// Update Event
        /// </summary>
        /// <param name="model">Event data</param>
        /// <returns></returns>
        Task UpdateAsync(EventModel model);

        /// <summary>
        /// Display of Event
        /// </summary>
        /// <param name="Id">Identification of event</param>
        /// <returns></returns>
        Task<EventModel> GetEventAsync(int Id);

        /// <summary>
        /// Display of all Events
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<EventModel>> GetAllAsync();
    }
}
