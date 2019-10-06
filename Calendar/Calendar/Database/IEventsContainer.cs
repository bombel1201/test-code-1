using Calendar.Models;
using System;
using System.Collections.Generic;

namespace Calendar.Database
{
    public interface IEventsContainer
    {
        void DeleteEvent(uint id);

        List<Event> GetEvents(DateTime start, DateTime end);

        void InsertEvent(Event @event);

        void UpdateEvent(uint id, Event @event);
    }
}