using AreoKlub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AeroKlub.UI.Models
{
    public class PlaneListViewModel
    {
        public IEnumerable<Service> Serwis {get;set; }
        public IEnumerable<Plane> Samoloty { get; set; }
        public IEnumerable<Reservation> Reservations { get; set; }
        public string PlaneName { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public SelectList ListaSamolotów { get; set; }
        public SelectList MechanicList { get; set; }
        public SelectList ServiceList { get; set; }
        public DateTime Date { get; set; }
    }
}