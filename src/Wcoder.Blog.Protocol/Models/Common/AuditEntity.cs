using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wcoder.Blog.Protocol.Models
{
    abstract public class AuditEntity : IAuditEntity
    {
        [Key]
        public virtual long Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual DateTime Created { get; set; }

        public virtual long CreatedBy { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public virtual DateTime Updated { get; set; }

        public virtual long UpdatedBy { get; set; }

        public virtual bool Deleted { get; set; }

        public virtual long DeletedBy { get; set; }
    }
}