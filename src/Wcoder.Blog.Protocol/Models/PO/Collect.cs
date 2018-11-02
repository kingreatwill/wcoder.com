using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Wcoder.Blog.Protocol.Models
{
    public class Collect : ITenantEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Uri { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Tags { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public ushort Importance { get; set; }

        public long TenantId { get; set; }

        public long CreatedBy { get; set; }

        public long UpdatedBy { get; set; }

        public long DeletedBy { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Created { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Updated { get; set; }

        public bool Deleted { get; set; }
    }
}