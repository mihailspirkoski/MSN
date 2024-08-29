using MSN_Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MSN_WebApi.ViewModels_DTO
{
    public class ApproveForumPostDTO
    {

        public string Id { get; set; }

        public string title { get; set; }

        public string artist { get; set; }
        public string isApproved { get; set; } 

        public string type { get; set; }
        public string genre { get; set; }
        public string? description { get; set; }
        public string timeCreated { get; set; }
        public string userName { get; set; }
        public string createdBy { get; set; }

    }
}
