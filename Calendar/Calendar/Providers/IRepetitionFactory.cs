using Calendar.Models.Repetitions;

namespace Calendar.Providers
{
    public interface IRepetitionFactory
    {
        Repetition Create(RepetitionPeriod period);
    }
}