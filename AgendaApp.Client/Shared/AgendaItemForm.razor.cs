using AgendaApp.Models;
using Flurl.Http;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace AgendaApp.Client.Shared
{
    public partial class AgendaItemForm
    {
        private AgendaItem _agendaItem = new AgendaItem { Duration = TimeSpan.FromMinutes(10) };
        private EditContext _editContext;

        [Parameter]
        public MicrosoftTeamsContext MicrosoftTeamsContext { get; set; }

        [Parameter]
        public short AgendaItemCount { get; set; }

        protected override void OnInitialized()
        {
            SetModelAndContext();
            base.OnInitialized();
        }

        protected override void OnParametersSet()
        {
            Console.WriteLine("params set: ");

            if (MicrosoftTeamsContext != null)
            {
                Console.WriteLine("meetingId: " + MicrosoftTeamsContext.MeetingId);
                _agendaItem.MeetingId = MicrosoftTeamsContext.MeetingId;
            }
            _agendaItem.Order = AgendaItemCount;
            Console.WriteLine("AgendaItemCount: " + AgendaItemCount);

            base.OnParametersSet();
        }

        private async Task HandleValidSubmitAsync()
        {
            var agendaItem = _editContext.Model;
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(agendaItem))
            {
                Console.WriteLine($"\t {descriptor.Name}: {descriptor.GetValue(agendaItem)}");
            }

            var isValid = _editContext.Validate();
            if (isValid)
            {
                var token = await LocalStorage.GetItemAsync<string>("access_token");
                await $"http://localhost:3978/api/AgendaItem/AddAsync"
                    .WithOAuthBearerToken(token)
                    .WithHeader("Content-type", "application/json")
                    .PostJsonAsync(agendaItem);

                UriHelper.NavigateTo(UriHelper.Uri, forceLoad: true);
            }
            else
            {
                Console.WriteLine("invalid");
            }
        }

        private void HandleReset()
        {
            SetModelAndContext();
        }

        private void SetModelAndContext()
        {
            _agendaItem = new AgendaItem { Duration = TimeSpan.FromMinutes(10) };
            if (MicrosoftTeamsContext != null)
            {
                _agendaItem.MeetingId = MicrosoftTeamsContext.MeetingId;
            }
            _agendaItem.Order = AgendaItemCount;
            _editContext = new EditContext(_agendaItem);
        }

    }
}
