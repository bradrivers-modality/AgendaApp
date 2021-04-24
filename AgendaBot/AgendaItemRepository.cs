using AgendaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgendaApp.Bot
{
    public class AgendaItemRepository : IAgendaItemRepository
    {
        private List<AgendaItem> _agendaItems;

        public AgendaItemRepository()
        {
            _agendaItems = new List<AgendaItem>();
            _agendaItems.Add(new AgendaItem{Name = "Item 1", MeetingId = "1", Duration = TimeSpan.FromMinutes(10), Order = 0, UserName = "Brad"});
            _agendaItems.Add(new AgendaItem { Name = "Item 3", MeetingId = "1", Duration = TimeSpan.FromMinutes(20), Order = 2, UserName = "Joe" });
            _agendaItems.Add(new AgendaItem { Name = "Item 2", MeetingId = "1", Duration = TimeSpan.FromMinutes(15), Order = 3, UserName = "Oli" });
        }

        public IEnumerable<AgendaItem> GetAllForMeeting(string meetingId) => _agendaItems.Where(i => i.MeetingId.Equals(meetingId));

        public void Add(AgendaItem agendaItem)
        {
            _agendaItems.Add(agendaItem);
        }
    }
}
