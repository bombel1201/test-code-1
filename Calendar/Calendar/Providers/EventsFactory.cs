using Calendar.Models;
using Calendar.Models.Repetitions;

namespace Calendar.Providers
{
    public class EventsFactory : IEventsFactory
    {
        private readonly IRepetitionFactory repetitionFactory;

        public EventsFactory(IRepetitionFactory repetitionFactory)
        {
            this.repetitionFactory = repetitionFactory;
        }

        public Event CreateSingleEvent()
        {
            var result = new Event
            {
                Repetition = repetitionFactory.CreateAndInit(RepetitionPeriod.None)
            };
            return result;
        }
    }
}
