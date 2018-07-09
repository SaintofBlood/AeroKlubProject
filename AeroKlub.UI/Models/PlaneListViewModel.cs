using AreoKlub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AeroKlub.UI.Models
{
    public class PlaneListViewModel
    {
        public IEnumerable<Samolot> Samoloty { get; set; }
        public IEnumerable<Reservation> Reservations { get; set; }
        public string Name {get;set; }
        public string NickName { get; set; }

    }
}