using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreoKlub.Domain.Entities
{
    public class Samolot
    {
        [Key]
        public int PlaneID { get; set; }
        public string Nazwa { get; set; }
    }
}
