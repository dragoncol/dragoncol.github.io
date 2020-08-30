using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CorePos.Blazor.Services
{
    public class RestClient
    {
        protected HttpClient httpClient;
        protected ILocalStorageService localStorage;
        protected NavigationManager navigationManager;

        string serviceUrl = "https://i359uyxpsj.execute-api.us-east-2.amazonaws.com/Prod/";

        public RestClient(HttpClient httpClient, ILocalStorageService localStorage, NavigationManager navigationManager)
        {
            this.httpClient = httpClient;
            this.localStorage = localStorage;
            this.navigationManager = navigationManager;
        }

        protected async Task<T> Raw<T>(string methodName, object param)
        {
            var strJson = JsonSerializer.Serialize(param);
            var content = new StringContent(strJson, Encoding.UTF8, "application/json");
            var result = await httpClient.PostAsync(serviceUrl + methodName, content);
            string jsonResponse;
            if( result.StatusCode == System.Net.HttpStatusCode.Unauthorized )
            {
                navigationManager.NavigateTo("/login");
                CorePOSApi.Model.contract.BaseResponse bresponse = new CorePOSApi.Model.contract.BaseResponse();
                bresponse.code = 98;
                bresponse.message = "Unauthorized";
                jsonResponse = JsonSerializer.Serialize(bresponse);
            }
            else
            {
                jsonResponse = await result.Content.ReadAsStringAsync();
            }
            var response = JsonSerializer.Deserialize<T>(jsonResponse);
            return response;
        }

        protected async Task<T> Post<T>(string methodName, object param)
        {
            string token = await GetToken();
            if (httpClient.DefaultRequestHeaders.Contains("Authorization"))
                httpClient.DefaultRequestHeaders.Remove("Authorization");
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            return await Raw<T>(methodName,param);
        }

        protected async Task<string> GetToken()
        {
            string token = await localStorage.GetItemAsync<string>("access_token");
            return token;
        }
    }
}
