using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreoKlub.Domain.Entities
{
    public class Plane
    {
        [Key]
        [Display(Name = "PlaneID")]
        public int PlaneID { get; set; }

        [Display(Name ="Name")]
        public string Nazwa { get; set; }

        public int WylataneGodziny { get; set; }
    }
}
