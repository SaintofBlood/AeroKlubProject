﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AeroKlub.UI.Infrastructure
{
    public class MyAuthorizeAttribute : AuthorizeAttribute
    {

        public MyAuthorizeAttribute(params string[] roleKeys)
        {
            List<string> roles = new List<string>(roleKeys.Length);

            
            var allRoles = (NameValueCollection)ConfigurationManager.GetSection("roles");

            foreach (var roleKey in roleKeys)
            {
                roles.Add(allRoles[roleKey]);
            }

            this.Roles = string.Join(",", roles);
        }
    }
}