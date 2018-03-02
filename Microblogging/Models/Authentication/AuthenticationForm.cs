using System;
namespace AuthenticationBase.Models.Authentication
{
    public class AuthenticationForm
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ErrorMessage { get; set; }
    }
}
