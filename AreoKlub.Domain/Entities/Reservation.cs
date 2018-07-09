using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AreoKlub.Domain.Entities
{
    public class Reservation
    {

        [Key]
        [Display(Name = "ID")]
        public int ReservationID { get; set; }


        [Display(Name = "Nazwa samolotu")]
        public string PlaneName { get; set; }


        [Display(Name = "Data")]
        public string Date { get; set; }

        [Display(Name = "Od")]
        public int From { get; set; }


        [Display(Name = "Do")]
        public int To { get; set; }

        [HiddenInput(DisplayValue = false)]
        [Display(Name = "By")]
        public string By { get; set; }
    }
}
