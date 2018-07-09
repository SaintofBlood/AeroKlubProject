using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreoKlub.Domain.Entities
{
    public class Service
    {
        [Key]
        public int Id { get; set; }

        public string Samolot { get; set; }
        public string Data { get; set; }
        public string By { get; set; }
    }
}
