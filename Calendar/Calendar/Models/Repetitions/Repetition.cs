namespace Calendar.Models.Repetitions
{
    public abstract class Repetition
    {
        public Repetition(uint count, RepetitionPeriod period)
        {
            Count = count;
            Period = period;
        }
        public RepetitionPeriod Period { get; set; }

        public uint Count { get; set; }
    }

}
