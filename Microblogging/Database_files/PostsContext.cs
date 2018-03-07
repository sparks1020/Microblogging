using System;
using System.Data.Entity;
using Microblogging.Models;
using System.Linq;
using System.Collections.Generic;
using AuthenticationBase.Models.Authentication;

namespace Microblogging.Database_files
{
    public class PostsContext : DbContext
    {
        public DbSet<Microblog> Posts { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Follow> Follows { get; set; }

        public PostsContext()
        {
            Database.SetInitializer<PostsContext>(null);
        }
    }
}
