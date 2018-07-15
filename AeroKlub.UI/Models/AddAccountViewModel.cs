using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AeroKlub.UI.Models
{
    public class AddAccountViewModel
    {
        [Required(ErrorMessage = "Proszę podać nazwę użytkownika!")]
        public string Name { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string paswd { get; set; }

        public string secondpaswd { get; set; }

        public string email { get; set; }

    }
}