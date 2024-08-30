using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSN_Domain.Entities
{
    public class MSNUser: IdentityUser
    {
        public string firstname {  get; set; }
        public string lastname { get; set; }
        public int age { get; set; }
        public string? role { get; set; }

    }
}
