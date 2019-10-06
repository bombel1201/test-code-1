using Calendar.Models.Repetitions;

namespace Calendar.Providers
{
    public interface IRepetitionFactory
    {
        Repetition CreateAndInit(RepetitionPeriod period);
    }
}