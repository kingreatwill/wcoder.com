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
        }
    }
}