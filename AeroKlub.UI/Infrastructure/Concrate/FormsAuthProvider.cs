using AeroKlub.UI.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace AeroKlub.UI.Infrastructure.Concrate
{
    public class FormsAuthProvider : IAuthProvider
    {
        public bool Authenticate(string username , string password)
        {
            bool result = FormsAuthentication.Authenticate(username, password);

            if (result)
            {
                FormsAuthentication.SetAuthCookie(username, true);
            }

            return result;
        }
    }
}