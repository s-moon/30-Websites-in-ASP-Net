using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace GuestForm
{
    public class GuestCommentDbContext : DbContext
    {
        public GuestCommentDbContext()
            : base("name=GuestCommentDbContext")
        {

        }

        public DbSet<GuestComment> GuestComments { get; set; }
    }
}