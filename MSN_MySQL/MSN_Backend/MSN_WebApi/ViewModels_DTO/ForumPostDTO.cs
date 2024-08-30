using MSN_Domain.Entities;
using MSN_Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MSN_WebApi.ViewModels_DTO
{
    public class ForumPostDTO
    {


        public string title { get; set; }

        public string artist { get; set; }

        public string type { get; set; }
        public string genre { get; set; }
        public string? description { get; set; }

    }
}
