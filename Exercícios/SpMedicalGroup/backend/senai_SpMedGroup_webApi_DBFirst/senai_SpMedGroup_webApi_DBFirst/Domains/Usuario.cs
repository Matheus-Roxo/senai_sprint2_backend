using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai_SpMedGroup_webApi_DBFirst.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Medicos = new HashSet<Medico>();
            Pacientes = new HashSet<Paciente>();
        }

        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Este é um campo OBRIGATÓRIO!!!")]
        public int? IdTipoUsuario { get; set; }

        [Required(ErrorMessage = "Este é um campo OBRIGATÓRIO!!!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Este é um campo OBRIGATÓRIO!!!")]
        public string Senha { get; set; }

        public virtual TiposUsuario IdTipoUsuarioNavigation { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }

        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
