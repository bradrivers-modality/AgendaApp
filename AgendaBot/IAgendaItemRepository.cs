using AgendaApp.Models;
using System.Collections.Generic;

namespace AgendaApp.Bot
{
    public interface IAgendaItemRepository
    {
        IEnumerable<AgendaItem> GetAllForMeeting(string meetingId);
        void Add(AgendaItem agendaItem);
    }
}
