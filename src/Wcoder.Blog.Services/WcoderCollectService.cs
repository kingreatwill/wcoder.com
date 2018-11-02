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
    public class WcoderCollectService : IWcoderCollectService
    {
        private readonly IUnitOfWork unitOfWork;

        public WcoderCollectService(IUnitOfWork unitOfWork)//(BlogContext blogContext, IRepository<Tenant> repository, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<long> AddAsync(Collect collect)
        {
            var aRepo = unitOfWork.GetRepository<Collect>();
            collect.Id = GlobalExtensions.NewLongId();
            await aRepo.InsertAsync(collect);
            await unitOfWork.SaveChangesAsync();
            return collect.Id;
        }

        public Task<bool> DeleteAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Collect[]> ListAsync()
        {
            var aRepo = unitOfWork.GetRepository<Collect>();
            var list = await aRepo.GetPagedListAsync();
            return list.Items.ToArray();
        }
    }
}