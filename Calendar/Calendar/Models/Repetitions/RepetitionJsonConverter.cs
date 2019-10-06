using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Calendar.Models.Repetitions
{
    public class RepetitionJsonConverter : JsonConverter
    {
        public override bool CanWrite => false;

        public override bool CanConvert(Type objectType)
        {
            return typeof(Repetition).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var repetitionAsJObject = JObject.Load(reader);
            var periodToken = repetitionAsJObject.GetValue("period");
            var period = periodToken.ToObject<RepetitionPeriod>();
            var target = CreateRepetition(period);
            serializer.Populate(repetitionAsJObject.CreateReader(), target);
            return target;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        private static Repetition CreateRepetition(RepetitionPeriod period)
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
                        return new WeeklyRepetition();
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
