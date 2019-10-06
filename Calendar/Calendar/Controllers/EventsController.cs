using Calendar.Database;
using Calendar.Models;
using Calendar.Models.Repetitions;
using Calendar.Providers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Calendar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventsContainer eventContainer;
        private readonly IEventsFactory eventsFactory;
        private readonly IRepetitionFactory repetitionFactory;
        public EventsController(IEventsFactory eventsFactory,
            IRepetitionFactory repetitionFactory,
            IEventsContainer eventContainer)
        {
            this.eventContainer = eventContainer;
            this.repetitionFactory = repetitionFactory;
            this.eventsFactory = eventsFactory;
        }

        /// <summary>
        /// (An Action that handles HTTP GET requests) creates a repetition based on requested period.
        /// Should be use in UI part to define repetition for event 
        /// </summary>
        /// <param name="period">   The period. </param>
        /// <returns>
        /// The new repetition.
        /// </returns>
        [HttpGet]
        [Route("[action]")]
        public ActionResult<Repetition> CreateRepetition([FromQuery] RepetitionPeriod period)
        {
            return repetitionFactory.CreateAndInit(period);
        }

        /// <summary>
        /// (An Action that handles HTTP GET requests) creates single event.
        /// This method should be use on UI side to create initial event object 
        /// </summary>
        /// <returns>
        /// The new single event.
        /// </returns>
        [HttpGet]
        [Route("[action]")]
        public ActionResult<Event> CreateSingleEvent()
        {
            return eventsFactory.CreateSingleEvent();
        }

        /// <summary>
        /// (An Action that handles HTTP DELETE requests) deletes the event described by ID.
        /// DELETE api/events/DeleteEvent?id=123
        /// </summary>
        /// <param name="id">   The identifier. </param>
        [HttpDelete]
        [Route("[action]")]
        public void DeleteEvent([FromQuery] uint id)
        {
            eventContainer.DeleteEvent(id);
        }

        /// <summary>
        /// (An Action that handles HTTP GET requests) gets the events 
        /// in requested period of time defined by <paramref name="start"/> and <paramref name="end"/>
        /// If both <paramref name="start"/> and <paramref name="end"/> are equal to default value then all events are returned
        /// </summary>
        /// <param name="start">    The start Date/Time. </param>
        /// <param name="end">      The end Date/Time. </param>
        /// <returns>
        /// The events.
        /// </returns>
        [HttpGet]
        public ActionResult<IEnumerable<Event>> GetEvents(DateTime start, DateTime end)
        {
            return eventContainer.GetEvents(start, end);
        }

        /// <summary>
        /// (An Action that handles HTTP POST requests) saves an event.
        /// </summary>
        /// <param name="event">    The event. </param>
        [HttpPost]
        [Route("[action]")]
        public void SaveEvent([FromBody] Event @event)
        {
            eventContainer.InsertEvent(@event);
        }

        /// <summary>
        /// (An Action that handles HTTP PUT requests) updates the event.
        /// PUT api/events/UpdateEvent?id=123
        /// </summary>
        /// <param name="id">       The identifier. </param>
        /// <param name="event">    The event. </param>
        [HttpPut]
        [Route("[action]")]
        public void UpdateEvent([FromQuery] uint id, [FromBody] Event @event)
        {
            eventContainer.UpdateEvent(id, @event);
        }
    }
}
