using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Wcoder.Blog.Infrastructure;
using Wcoder.Blog.Protocol.Interfaces;
using Wcoder.Blog.Protocol.Models;

namespace Wcoder.Blog.Services
{
    public class WcoderBlogService : IWcoderBlogService
    {
        private readonly BlogContext blogContext;

        public WcoderBlogService(BlogContext blogContext, IRepository<Tenant> repository, IUnitOfWork unitOfWork)
        {
            var s = repository.GetPagedList();
            var userRepo = unitOfWork.GetRepository<Tenant>();
            var s2 = userRepo.GetPagedList();
            //var postRepo = unitOfWork.GetRepository<Catalog>();
            // this.blogContext = blogContext;
        }
    }
}