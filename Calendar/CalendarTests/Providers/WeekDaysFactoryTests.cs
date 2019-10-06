using Calendar.Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace CalendarTests.Providers
{
    [TestClass]
    public class WeekDaysFactoryTests
    {
        [TestMethod]
        public void CreateInitialListOfWeekDays_TodaySelectedIsEqualToTrue_ReturnCollectionContainsAllDaysWithCurrentDaySelected()
        {
            var factory = new WeekDaysFactory();
            var actual = factory.CreateInitialListOfWeekDays(true);
            var expectedDays = Enum.GetValues(typeof(DayOfWeek)).OfType<DayOfWeek>().ToList();
            CollectionAssert.AreEqual(expectedDays, actual.Select(x => x.Day).ToList());

            var expectedSelectedDay = DateTime.Today.DayOfWeek;
            foreach (var day in actual)
            {
                if (day.Day == expectedSelectedDay)
                {
                    Assert.IsTrue(day.Selected);
                }
                else
                {
                    Assert.IsFalse(day.Selected);
                }
            }
        }

        [TestMethod]
        public void CreateInitialListOfWeekDays_TodaySelectedIsEqualToFalse_ReturnCollectionContainsAllDaysAllValuesAreUnselected()
        {
            var factory = new WeekDaysFactory();
            var actual = factory.CreateInitialListOfWeekDays(false);
            var expectedDays = Enum.GetValues(typeof(DayOfWeek)).OfType<DayOfWeek>().ToList();
            CollectionAssert.AreEqual(expectedDays, actual.Select(x => x.Day).ToList());
            Assert.IsFalse(actual.Any(x => x.Selected));
        }
    }
}
