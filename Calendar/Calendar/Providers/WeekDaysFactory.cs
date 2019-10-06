using Calendar.Models.Repetitions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Calendar.Providers
{
    public class WeekDaysFactory : IWeekDaysFactory
    {
        /// <summary>
        /// Creates initial list of selectable week days.
        /// </summary>
        /// <param name="todaySelected">    True if actual day must be selected. </param>
        /// <returns>
        /// The new initial list of week days.
        /// </returns>
        public List<SelectableDay> CreateInitialListOfWeekDays(bool todaySelected)
        {
            var days = new List<SelectableDay>();
            var actualDay = DateTime.Today.DayOfWeek;
            foreach (var day in Enum.GetValues(typeof(DayOfWeek)).OfType<DayOfWeek>())
            {
                days.Add(new SelectableDay
                {
                    Day = day,
                    Selected = todaySelected ? day == actualDay : false
                });
            }
            return days;
        }
    }
}
