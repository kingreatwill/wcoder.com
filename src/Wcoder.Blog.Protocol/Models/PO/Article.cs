using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Wcoder.Blog.Protocol.Models
{
    public class Article : ITenantEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        public long CatalogId { get; set; }

        // [ForeignKey("CatalogId")]
        public Catalog Catalog { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [DefaultValue("")]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public string Content { get; set; }

        [DefaultValue("")]
        // [Description("标签")]
        public string Tags { get; set; } = "123";

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