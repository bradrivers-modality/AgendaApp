using System;

namespace AgendaApp.Models
{
    public class AgendaItem
    {
        public string Name { get; set; }
        public string MeetingId { get; set; }
        public Int16 Order { get; set; }
        public TimeSpan Duration { get; set; }
        public Guid UserId { get; set; }
    }
}
