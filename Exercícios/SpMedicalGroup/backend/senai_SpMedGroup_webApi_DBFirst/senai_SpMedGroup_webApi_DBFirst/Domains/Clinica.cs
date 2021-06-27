using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai_SpMedGroup_webApi_DBFirst.Domains
{
    public partial class Clinica
    {
        public Clinica()
        {
            Medicos = new HashSet<Medico>();
        }

        public int IdClinica { get; set; }

        [Required(ErrorMessage = "Este é um campo OBRIGATÓRIO!!!")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "Este é um campo OBRIGATÓRIO!!!")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "Este é um campo OBRIGATÓRIO!!!")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Este é um campo OBRIGATÓRIO!!!")]
        public TimeSpan HorarioAbertura { get; set; }

        [Required(ErrorMessage = "Este é um campo OBRIGATÓRIO!!!")]
        public TimeSpan HorarioFechamento { get; set; }

        [Required(ErrorMessage = "Este é um campo OBRIGATÓRIO!!!")]
        public string Site { get; set; }

        [Required(ErrorMessage = "Este é um campo OBRIGATÓRIO!!!")]
        public string Cnpj { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
