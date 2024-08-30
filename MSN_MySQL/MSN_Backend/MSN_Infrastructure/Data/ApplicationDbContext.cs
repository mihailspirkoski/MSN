using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MSN_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSN_Infrastructure.Data
{
    public class ApplicationDbContext: IdentityDbContext<MSNUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
           

        }
        public DbSet<MSNUser> MSNUsers { get; set; }
        public DbSet<MusicRecord> MusicRecords { get; set; }
        public DbSet<ForumPost> ForumPosts { get; set; }
    }
}
