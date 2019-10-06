using Calendar.Models.Repetitions;
using System;

namespace Calendar.Models
{
    /// <summary>
    /// Class which represents event scheduled in calendar
    /// </summary>
    public class Event
    {

        public Event()
        {

        }

        /// <summary>
        /// The description of the event
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The end date of the event
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Identifier of the event
        /// </summary>
        public uint Identifier { get; set; }

        /// <summary>
        /// The start date of the event
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// The title of the event
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the event is valid for whole day.
        /// If <see cref="WholeDay"/> is equal to true then 
        /// period defined for this event starts at date defined by <see cref="StartDate"/> and time defined as 00:00:00
        /// and event ends at date defined by <see cref="EndDate"/> and time defined as 23:59:59
        /// </summary>
        public bool WholeDay { get; set; }

        public Repetition Repetition { get; set; }
    }
}
