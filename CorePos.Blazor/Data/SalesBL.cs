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
    public class SalesBL : RestClient
    {
        public SalesBL(HttpClient httpClient, ILocalStorageService localStorage, NavigationManager navigationManager)
            : base(httpClient, localStorage, navigationManager)
        {
        }

        public async Task<CorePOSApi.Model.contract.FindSalesResponse> FindSales(CorePOSApi.Model.contract.FindSalesRequest request)
        {
            return await Post<CorePOSApi.Model.contract.FindSalesResponse>("api/FindSales", request);
        }

        public async Task<CorePOSApi.Model.contract.GetSaleDetailResponse> GetSaleDetail(CorePOSApi.Model.contract.GetSaleDetailRequest request)
        {
            return await Post<CorePOSApi.Model.contract.GetSaleDetailResponse>("api/GetSaleDetail", request);
        }

        public async Task<CorePOSApi.Model.contract.GetSaleResponse> GetSale(CorePOSApi.Model.contract.GetSaleRequest request)
        {
            return await Post<CorePOSApi.Model.contract.GetSaleResponse>("api/GetSale", request);
        }

    }
}
