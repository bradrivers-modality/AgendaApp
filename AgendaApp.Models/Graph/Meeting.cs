using Newtonsoft.Json;
using System;

namespace AgendaApp.Models.Graph
{
    public class Meeting
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("startDateTime")]
        public DateTime StartDate { get; set; }
        [JsonProperty("endDateTime")]
        public DateTime EndDate { get; set; }
    }
}
