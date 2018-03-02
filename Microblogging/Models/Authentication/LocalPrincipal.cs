using System;
using System.Security.Principal;

namespace AuthenticationBase.Models.Authentication
{
    public class LocalPrincipal : IPrincipal
    {
        public LocalPrincipal(IIdentity identity)
        {
            Identity = identity;
        }

        public IIdentity Identity { get; private set; }

        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }
    }
}
