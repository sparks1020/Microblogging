using System;
using System.Data.Entity;
using AuthenticationBase.Models.Authentication;

namespace AuthenticationBase
{
    public class AuthenticationContext : DbContext
    {
        public AuthenticationContext() : base()
        {
        }

        public DbSet<Account> Accounts { get; set; }
    }
}
