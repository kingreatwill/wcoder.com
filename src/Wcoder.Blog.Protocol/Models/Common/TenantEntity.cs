using System;
using System.Collections.Generic;
using System.Text;

namespace Wcoder.Blog.Protocol.Models
{
    abstract public class TenantEntity : IAuditEntity
    {
        public virtual long Id { get; set; }

        public virtual long TenantId { get; set; }

        public virtual DateTime Created { get; set; }

        public virtual long CreatedBy { get; set; }

        public virtual DateTime Updated { get; set; }

        public virtual long UpdatedBy { get; set; }

        public virtual bool Deleted { get; set; }

        public virtual long DeletedBy { get; set; }
    }
}