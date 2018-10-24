using System;
using System.Collections.Generic;
using System.Text;

namespace Wcoder.Blog.Protocol.Models
{
    public interface IAuditEntity : IEntity
    {
        long CreatedBy { get; set; }

        long UpdatedBy { get; set; }

        long DeletedBy { get; set; }
    }
}