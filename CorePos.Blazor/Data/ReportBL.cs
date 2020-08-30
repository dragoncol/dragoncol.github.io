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
    public class ReportBL : RestClient
    {
        public ReportBL(HttpClient httpClient, ILocalStorageService localStorage, NavigationManager navigationManager)
            : base(httpClient, localStorage, navigationManager)
        {
        }

        public async Task<CorePOSApi.Model.report.ReportResponse> Query(CorePOSApi.Model.report.ReportRequest request)
        {
            return await Post<CorePOSApi.Model.report.ReportResponse>("api/report/query", request);
        }
    }
}
