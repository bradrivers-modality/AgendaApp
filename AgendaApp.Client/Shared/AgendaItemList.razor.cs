using AgendaApp.Models;
using Flurl.Http;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaApp.Client.Shared
{
    public partial class AgendaItemList
    {
        private List<AgendaItem> _agendaItems;

        [Parameter]
        public MicrosoftTeamsContext MicrosoftTeamsContext { get; set; }

        [Parameter]
        public short AgendaItemCount { get; set; }

        [Parameter]
        public EventCallback<short> AgendaItemCountChanged { get; set; }

        private Task OnAgendaItemCountChangedAsync()
        {
            Console.WriteLine("AgendaItemCount changed: " + AgendaItemCount);
            return AgendaItemCountChanged.InvokeAsync(AgendaItemCount);
        }

        protected override async Task OnInitializedAsync()
        {
            var token = await LocalStorage.GetItemAsync<string>("access_token");
            var result = await $"http://localhost:3978/api/AgendaItem/GetAllForMeeting?meetingId={MicrosoftTeamsContext.MeetingId}"
                .WithOAuthBearerToken(token)
                .GetJsonAsync<List<AgendaItem>>();

            _agendaItems = result.OrderBy(i => i.Order).ToList();
            Console.WriteLine("_agendaItems.Count: " + _agendaItems.Count);

            AgendaItemCount = Convert.ToInt16(_agendaItems.Count);
            await OnAgendaItemCountChangedAsync();

            await base.OnInitializedAsync();
        }
    }
}
