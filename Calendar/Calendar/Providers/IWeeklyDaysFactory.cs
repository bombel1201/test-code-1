using System.Collections.Generic;
using Calendar.Models.Repetitions;

namespace Calendar.Providers
{
    public interface IWeekDaysFactory
    {
        List<SelectableDay> CreateInitialListOfWeekDays(bool todaySelected);
    }
}