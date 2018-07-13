using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AeroKlub.UI.Models
{
    public class UsersList
    {
        public SelectList UserList { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
    }
}