using System;
namespace AuthenticationBase.Models.Authentication
{
    public class Account
    {
        public int Id { get; set; }

        public string Username { get; set; }
        public string HashedPassword { get; set; }
        public string EmailAddress { get; set; }
    }
}
