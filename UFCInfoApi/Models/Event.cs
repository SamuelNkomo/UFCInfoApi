// Models/Event.cs
using System;
using System.Collections.Generic;

namespace UFCInfoApi.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string EventTime { get; set; }
        public List<Fighter> Fighters { get; set; } = new List<Fighter>();  // Fighters participating in the event
    }
}
