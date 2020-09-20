using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TuristInBanat.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext() : base("ChatDB")
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Reply> Replies { get; set; }
    }
}