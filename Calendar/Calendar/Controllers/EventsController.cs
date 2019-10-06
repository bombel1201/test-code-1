using Calendar.Models;
using Calendar.Models.Repetitions;
using Calendar.Providers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Calendar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventsFactory eventsFactory;
        private readonly IRepetitionFactory repetitionFactory;

        public EventsController(IEventsFactory eventsFactory,
            IRepetitionFactory repetitionFactory)
        {
            this.repetitionFactory = repetitionFactory;
            this.eventsFactory = eventsFactory;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<Event> CreateSingleEvent()
        {
            return eventsFactory.CreateSingleEvent();
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<Repetition> CreateRepetition([FromQuery] RepetitionPeriod period)
        {
            return repetitionFactory.Create(period);
        }

        [HttpPost]
        [Route("[action]")]
        public void SaveEvent([FromBody] Event value)
        {

        }
    }
}
