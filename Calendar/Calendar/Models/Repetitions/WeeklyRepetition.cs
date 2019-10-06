using System.Collections.Generic;

namespace Calendar.Models.Repetitions
{
    public class WeeklyRepetition : Repetition
    {
        public WeeklyRepetition()
            : base(1, RepetitionPeriod.Week)
        {
        }

        public List<SelectableDay> Days { get; set; } = new List<SelectableDay>();
    }
}
