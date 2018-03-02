using System;
namespace AuthenticationBase.Models.Authentication
{
    public class RegistrationForm
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string EmailAddress { get; set; }
        public string ErrorMessage { get; set; }
    }
}
