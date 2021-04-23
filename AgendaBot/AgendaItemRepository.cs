using AgendaApp.Models;
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
        }

        public IEnumerable<AgendaItem> GetAllForMeeting(string meetingId) => _agendaItems.Where(i => i.MeetingId.Equals(meetingId));

        public void Add(AgendaItem agendaItem)
        {
            _agendaItems.Add(agendaItem);
        }
    }
}
