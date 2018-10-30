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

        
     }
}
