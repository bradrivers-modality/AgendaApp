using System;
using System.ComponentModel.DataAnnotations;

namespace AgendaApp.Models
{
    public class AgendaItem
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string MeetingId { get; set; }
        [Required]
        public short Order { get; set; }
        [Required]
        public TimeSpan Duration { get; set; }
        public string UserName { get; set; }
    }
}
