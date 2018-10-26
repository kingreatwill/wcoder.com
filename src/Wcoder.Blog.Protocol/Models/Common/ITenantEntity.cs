using System;
using System.Collections.Generic;
using System.Text;

namespace Wcoder.Blog.Protocol.Models
{
    public interface ITenantEntity : IAuditEntity
    {
        long TenantId { get; set; }
    }
}