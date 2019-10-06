using System;

namespace Calendar.Models.Repetitions
{
    public class SelectableDay
    {
        public SelectableDay()
        {

        }
        public DayOfWeek Day { get; set; }
        public bool Selected { get; set; }
    }
}
