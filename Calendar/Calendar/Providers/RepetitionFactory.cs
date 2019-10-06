using Calendar.Models.Repetitions;

namespace Calendar.Providers
{
    public class RepetitionFactory : IRepetitionFactory
    {
        private readonly IWeekDaysFactory weekDaysFactory;

        public RepetitionFactory(IWeekDaysFactory weekDaysFactory)
        {
            this.weekDaysFactory = weekDaysFactory;
        }

        /// <summary>
        /// Creates a new instance of Repetition based on passed <paramref name="period"/>
        /// Initialize sub properties if needed
        /// </summary>
        /// <param name="period">   The period. </param>
        /// <returns>
        /// New instance of repetition.
        /// </returns>
        public Repetition CreateAndInit(RepetitionPeriod period)
        {
            switch (period)
            {
                case RepetitionPeriod.Day:
                    {
                        return new DailyRepetition();
                    }
                case RepetitionPeriod.Month:
                    {
                        return new MonthlyRepetition();
                    }
                case RepetitionPeriod.Week:
                    {
                        var result = new WeeklyRepetition
                        {
                            Days = weekDaysFactory.CreateInitialListOfWeekDays(true)
                        };
                        return result;
                    }
                case RepetitionPeriod.Year:
                    {
                        return new YearlyRepetition();
                    }
                default:
                    {
                        return new NoneRepetition();
                    }
            }
        }
    }
}
