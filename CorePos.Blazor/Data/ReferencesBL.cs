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
    public class ReferencesBL : RestClient
    {
        public ReferencesBL(HttpClient httpClient, ILocalStorageService localStorage, NavigationManager navigationManager)
            : base(httpClient, localStorage, navigationManager)
        {
        }
        public async Task<CorePOSApi.Model.contract.GetReferenceResponse> GetReference(CorePOSApi.Model.contract.GetReferenceRequest request)
        {
            return await Post<CorePOSApi.Model.contract.GetReferenceResponse>("api/GetReference", request);
        }
    }
}
