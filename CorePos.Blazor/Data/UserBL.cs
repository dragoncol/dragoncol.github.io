using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Threading.Tasks;
using CorePos.Blazor.Services;
using Microsoft.AspNetCore.Components;

namespace CorePos.Blazor.Data
{
    public class UserBL : RestClient
    {
        AppState appState;

        public UserBL(HttpClient httpClient, ILocalStorageService localStorage , NavigationManager navigationManager , AppState appState)
            : base (httpClient , localStorage , navigationManager)
        {
            this.appState = appState;
        }

        public async Task<CorePOSApi.Model.contract.LoginResponse> Login(CorePOSApi.Model.contract.LoginRequest request)
        {
            var response = await Raw<CorePOSApi.Model.contract.LoginResponse>("oauth/login", request);
            if (response.code == 100)
            {
                if (!UserHasPermission(response, "webreports"))
                {
                    return new CorePOSApi.Model.contract.LoginResponse()
                    {
                        code = 0,
                        message = "UNAUTHORIZED"
                    };
                }
                await localStorage.SetItemAsync("access_token", response.access_token);
                await localStorage.SetItemAsync("userName", response.userName);
            }
            return response;
        }

        public async Task<CorePOSApi.Model.contract.LoginResponse> GetSession()
        {
            CorePOSApi.Model.contract.LoginResponse response = null;
            string userName = await localStorage.GetItemAsync<string>("userName");
            if (!string.IsNullOrEmpty(userName))
            {
                response = new CorePOSApi.Model.contract.LoginResponse();
                response.userName = userName;
            }
            else
            {
                response = new CorePOSApi.Model.contract.LoginResponse();
                response.userName = "Invitado";
            }
            return response;
        }

        public bool UserHasPermission( CorePOSApi.Model.contract.LoginResponse response, string permission )
        {
            var item = response.permissions.Where(x => x.name == permission).FirstOrDefault();
            return (item != null);
        }

        public async Task LogOut()
        {
            await localStorage.SetItemAsync("access_token", "");
            await localStorage.SetItemAsync("userName", "");
            appState.LoggedIn = true;
            appState.LoggedIn = false;
            appState.sales = null;
            appState.references = null;
            appState.loginResponse = null;
            navigationManager.NavigateTo("/login");
        }
    }
}
