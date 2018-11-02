using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Wcoder.Blog.Infrastructure;
using Wcoder.Blog.Protocol.Extensions;
using Wcoder.Blog.Protocol.Interfaces;
using Wcoder.Blog.Protocol.Models;

namespace Wcoder.Blog.Services
{
    public class WcoderBlogService : IWcoderBlogService
    {
        private readonly IUnitOfWork unitOfWork;

        public WcoderBlogService(IUnitOfWork unitOfWork)//(BlogContext blogContext, IRepository<Tenant> repository, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<long> AddArticleAsync(Article article)
        {
            var aRepo = unitOfWork.GetRepository<Article>();
            article.Id = GlobalExtensions.NewLongId();
            await aRepo.InsertAsync(article);
            await unitOfWork.SaveChangesAsync();
            return article.Id;
        }

        public async Task<Article[]> ArticleListAsync()
        {
            var aRepo = unitOfWork.GetRepository<Article>();
            var list = await aRepo.GetPagedListAsync();
            return list.Items.ToArray();
        }
    }
}