using AgendaApp.Client.Model;
using Blazorade.Teams.Model;
using Microsoft.AspNetCore.Components;
using System;
using System.Net.Http;
using Blazorade.Msal.Security;
using Blazorade.Msal.Services;
using Flurl.Http;

namespace AgendaApp.Client.Shared
{
    partial class ProfileViewer
    {
        private static readonly HttpClient Client = new HttpClient();

        [Parameter]
        public ApplicationContext Context { get; set; }

        [Parameter]
        public UserProfileModel Model { get; set; } = new UserProfileModel();

        protected override async void OnAfterRender(bool firstRender)
        {
            var scopes = this.Context.TeamsInterop.Authentication.GetScopes();
            var htoken = await this.Context.TeamsInterop.Authentication.AcquireTokenAsync(
                loginHint: this.Context?.Context?.LoginHint,
                scopes: scopes
            );

            Console.WriteLine($"gtoken: {htoken.AccessToken}");
            if (htoken != null)
            {
                Console.WriteLine($"token: {htoken.AccessToken}");
                var user = await "http://localhost:3978/api/user/GetSignedInUser"
                    .WithHeader("Access-Control-Allow-Origin","*")
                    .WithOAuthBearerToken(htoken.AccessToken)
                    .GetAsync();
            }

            var token1 = await MsalService.AcquireTokenAsync(new TokenAcquisitionRequest
            {
                LoginHint = this.Context.Context.LoginHint,
                Prompt = LoginPrompt.Consent,
                Timeout = 60000
            });
            if (token1 != null)
            {
                Console.WriteLine($"token: {token1.AccessToken}");
                var user = await "http://localhost:3978/api/user/GetSignedInUser"
                    .WithHeader("Access-Control-Allow-Origin", "*")
                    .WithOAuthBearerToken(token1.AccessToken)
                    .GetAsync();
            }

            var token2 = await Context.TeamsInterop.Authentication.AcquireTokenAsync(new TokenAcquisitionRequest
            {
                LoginHint = this.Context.Context.LoginHint,
                Prompt = LoginPrompt.Consent,
                Timeout = 60000
            });
            if (token2 != null)
            {
                Console.WriteLine($"token: {token2.AccessToken}");
                var user2 = await "http://localhost:3978/api/user/GetSignedInUser"
                    .WithOAuthBearerToken(token2.AccessToken)
                    .GetAsync();
            }

            var token3 = await MsalService.AcquireTokenSilentAsync(new TokenAcquisitionRequest
            {
                LoginHint = this.Context.Context.LoginHint,
                Prompt = LoginPrompt.Consent,
                Timeout = 60000
            });
            if (token3 != null)
            {
                Console.WriteLine($"token: {token3.AccessToken}");
                var user3 = await "http://localhost:3978/api/user/GetSignedInUser"
                    .WithOAuthBearerToken(token3.AccessToken)
                    .GetAsync();
            }

            var token4 = await Context.TeamsInterop.Authentication.AuthenticateAsync(new TokenAcquisitionRequest
            {
                LoginHint = this.Context.Context.LoginHint,
                Prompt = LoginPrompt.Consent,
                Timeout = 60000
            });
            if (token4 != null)
            {
                Console.WriteLine($"token: {token4.AccessToken}");
                var user4 = await "http://localhost:3978/api/user/GetSignedInUser"
                    .WithOAuthBearerToken(token4.AccessToken)
                    .GetAsync();
            }

            base.OnAfterRender(firstRender);
        }
    }
}
