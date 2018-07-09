using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AeroKlub.UI.Models
{
    public class ReservationsListViewModel
    {
       public List<string> reservations { get; set; }
       public List<string> hisreservations { get; set; }

        public string Name { get; set; }
        public string NickName { get; set; }
    }
}