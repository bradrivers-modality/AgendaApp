using System;
using Newtonsoft.Json;

namespace AgendaApp.Models
{
    public class MicrosoftTeamsContext
    {
        public string ChatId { get; set; }
        public string EntityId { get; set; }
        public string FrameContext { get; set; }
        public string HostClientType { get; set; }
        public bool IsFullScreen { get; set; }
        public string Locale { get; set; }
        public string LoginHint { get; set; }
        public string MeetingId { get; set; }
        public string TeamSiteDomain { get; set; }
        public string Theme { get; set; }
        public Guid Tid { get; set; }
        public string UserPrincipalName { get; set; }
        public Guid UserObjectId { get; set; }
    }
}
