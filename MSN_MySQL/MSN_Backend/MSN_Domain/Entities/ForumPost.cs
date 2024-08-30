using MSN_Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSN_Domain.Entities
{
    public class ForumPost
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public string artist { get; set; }
        public bool isApproved { get; set; } = false;
        [Required]
        public string type { get; set; }
        public string genre { get; set; }
        public string? description { get; set; }
        public DateTime timeCreated { get; set; }
        public string userName { get; set; }
        [ForeignKey("CreatedByUser")]
        public MSNUser createdBy { get; set; }

    }
}
