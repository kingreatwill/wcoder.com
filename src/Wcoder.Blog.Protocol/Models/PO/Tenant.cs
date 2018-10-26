using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Wcoder.Blog.Protocol.Models
{
    [Table("Tenant")]
    public class Tenant : IAuditEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string LogoId { get; set; }

        [MaxLength(200)]
        public string LogoUri { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Created { get; set; }

        public long CreatedBy { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Updated { get; set; }

        public long UpdatedBy { get; set; }

        public bool Deleted { get; set; }

        public long DeletedBy { get; set; }
    }
}