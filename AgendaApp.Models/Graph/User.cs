using AgendaApp.Global;
using Newtonsoft.Json;
using System;

namespace AgendaApp.Models.Graph
{
    [JsonConverter(typeof(DefaultToUnknownEnumConverter), (int)Unknown)]
    public enum UserType
    {
        Unknown = -1,
        Owner = 0,
        Member = 1,
        Guest = 2
    }

    public class User
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
        [JsonProperty("userType")]
        public UserType Type { get; set; }
        [JsonProperty("preferredDataLocation")]
        public string PreferredDataLocation { get; set; }
    }
}
