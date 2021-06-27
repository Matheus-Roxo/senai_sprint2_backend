using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedGroup_webApi_DBFirst.ViewModel
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "Este é um campo OBRIGATÓRIO!!!")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Este é um campo OBRIGATÓRIO!!!")]
        public string Email { get; set; }
    }
}
