using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai_SpMedGroup_webApi_DBFirst.Domains
{
    public partial class Paciente
    {
        public Paciente()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int IdPaciente { get; set; }

        public int? IdUsuario { get; set; }

        [Required(ErrorMessage = "Este é um campo OBRIGATÓRIO!!!")]
        public string NomePaciente { get; set; }

        [Required(ErrorMessage = "Este é um campo OBRIGATÓRIO!!!")]
        public string Rg { get; set; }

        [Required(ErrorMessage = "Este é um campo OBRIGATÓRIO!!!")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Este é um campo OBRIGATÓRIO!!!")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Este é um campo OBRIGATÓRIO!!!")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Este é um campo OBRIGATÓRIO!!!")]
        public string Endereco { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }

        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
