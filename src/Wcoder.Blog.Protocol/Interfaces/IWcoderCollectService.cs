using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wcoder.Blog.Protocol.Models;

namespace Wcoder.Blog.Protocol.Interfaces
{
    public interface IWcoderCollectService
    {
        Task<long> AddAsync(Collect collect);

        Task<Collect[]> ListAsync();

        Task<bool> DeleteAsync();
    }
}