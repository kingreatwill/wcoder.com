using Microsoft.AspNetCore.Blazor;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Wcoder.Blog.Protocol.Interfaces;
using Wcoder.Blog.Protocol.Models;

namespace Wcoder.Blog.AppClient
{
    public class HttpClientWcoderCollectService : IWcoderCollectService
    {
        private readonly HttpClient httpClient;
        private readonly string controllerName = "WcoderCollectService";

        public HttpClientWcoderCollectService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        
        public async Task<Int64> AddAsync(Collect collect)
        {
            var url = $"/{controllerName}/{nameof(AddAsync)}";
            return await httpClient.PostJsonAsync<Int64>(url,collect);
        }

        public async Task<Collect[]> ListAsync()
        {
            var url = $"/{controllerName}/{nameof(ListAsync)}";
            return await httpClient.GetJsonAsync<Collect[]>(url);
        }

        public async Task<Boolean> DeleteAsync()
        {
            var url = $"/{controllerName}/{nameof(DeleteAsync)}";
            return await httpClient.PostJsonAsync<Boolean>(url,null);
        }

     }
}
