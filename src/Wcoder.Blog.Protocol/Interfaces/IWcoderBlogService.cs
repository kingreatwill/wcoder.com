using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wcoder.Blog.Protocol.Models;

namespace Wcoder.Blog.Protocol.Interfaces
{
    public interface IWcoderBlogService
    {
        Task<long> AddArticleAsync(Article article);

        Task<Article[]> ArticleListAsync();
    }
}