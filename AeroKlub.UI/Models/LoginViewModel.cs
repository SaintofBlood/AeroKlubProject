using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AeroKlub.UI.Models
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "Proszę podać nazwę użytkownika!")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Proszę podać hasło")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}