namespace Calendar.Models.Repetitions
{
    public class DailyRepetition : Repetition
    {
        public DailyRepetition()
            : base(1, RepetitionPeriod.Day)
        {
        }
    }
}
