using System;
namespace AuthenticationBase.Models.Authentication
{
    public class LocalIdentity : System.Security.Principal.IIdentity
    {
        public LocalIdentity(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public string AuthenticationType => "LocalAuthentication";

        public bool IsAuthenticated => true;

        public string Name { get; private set; }

        public string Email { get; private set; }
    }
}
