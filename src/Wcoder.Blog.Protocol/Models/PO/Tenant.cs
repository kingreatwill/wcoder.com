using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Wcoder.Blog.Protocol.Models
{
    [Table("Tenant")]
    public class Tenant : AuditEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override long Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string LogoId { get; set; }

        [MaxLength(200)]
        public string LogoUri { get; set; }
    }
}