using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSN_Domain.Entities
{
    public class MusicRecord
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public string artist { get; set; }
        public double? rating { get; set; }
        public string? url { get; set; }
        public string? imageUrl { get; set; }
        [Required]
        public string genre { get; set; }
        [Required]
        public string type { get; set; }
    }
}
