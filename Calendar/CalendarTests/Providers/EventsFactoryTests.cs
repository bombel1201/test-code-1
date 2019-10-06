using Calendar.Models;
using Calendar.Models.Repetitions;
using Calendar.Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CalendarTests
{
    [TestClass]
    public class EventsFactoryTests
    {
        [TestMethod]
        public void Call_CreateSingleEvent_WithoutParameter_ReturnsProperInstance()
        {
            var repetition = new Mock<Repetition>((uint)1, RepetitionPeriod.None);
            var repetitionFactory = Mock.Of<IRepetitionFactory>(
                x => x.CreateAndInit(RepetitionPeriod.None) == repetition.Object);
            var factory = new EventsFactory(repetitionFactory);

            var actual = factory.CreateSingleEvent();

            Assert.IsInstanceOfType(actual, typeof(Event));
            Assert.AreEqual(repetition.Object, actual.Repetition);
        }
    }
}
