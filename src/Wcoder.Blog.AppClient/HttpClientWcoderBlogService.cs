using Microsoft.AspNetCore.Blazor;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Wcoder.Blog.Protocol.Interfaces;
using Wcoder.Blog.Protocol.Models;

namespace Wcoder.Blog.AppClient
{
    public class HttpClientWcoderBlogService : IWcoderBlogService
    {
        private readonly HttpClient httpClient;
        private readonly string controllerName = "WcoderBlogService";

        public HttpClientWcoderBlogService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        
        public async Task<Int64> AddArticleAsync(Article article)
        {
            var url = $"/{controllerName}/{nameof(AddArticleAsync)}";
            return await httpClient.PostJsonAsync<Int64>(url,article);
        }

        public async Task<Article[]> ArticleListAsync()
        {
            var url = $"/{controllerName}/{nameof(ArticleListAsync)}";
            return await httpClient.GetJsonAsync<Article[]>(url);
        }

     }
}
