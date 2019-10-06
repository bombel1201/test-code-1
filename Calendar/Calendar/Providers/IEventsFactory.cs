using Calendar.Models;

namespace Calendar.Providers
{
    public interface IEventsFactory
    {
        Event CreateSingleEvent();
    }
}