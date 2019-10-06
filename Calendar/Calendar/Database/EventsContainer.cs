using Calendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Calendar.Database
{
    public class EventsContainer : IEventsContainer
    {
        private readonly List<Event> events = new List<Event>();
        private uint idCounter = 0;
        public void DeleteEvent(uint id)
        {
            events.RemoveAll(x => x.Identifier == id);
        }

        public List<Event> GetEvents(DateTime start, DateTime end)
        {
            if (start == default && end == default)
            {
                return events.ToList();
            }
            var startPeriod = new DateTime(start.Year, start.Month, start.Day, 0, 0, 0);
            var endPeriod = new DateTime(end.Year, end.Month, end.Day, 23, 59, 59);
            return events.Where(x => x.StartDate >= startPeriod && x.EndDate <= endPeriod).ToList();
        }

        public void InsertEvent(Event @event)
        {
            if (@event == null)
            {
                return;
            }
            @event.Identifier = ++idCounter;
            events.Add(@event);
        }
        public void UpdateEvent(uint id, Event @event)
        {
            if (!events.Any(x => x.Identifier == id))
            {
                return;
            }

            DeleteEvent(id);
            if (@event == null)
            {
                return;
            }
            @event.Identifier = id;
            events.Add(@event);
        }
    }
}
