using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AeroKlub.UI.Infrastructure.Abstract
{
    public interface IAuthProvider
    {

        bool Authenticate(string userName, string Password);

    }
}