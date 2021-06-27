using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai_SpMedGroup_webApi_DBFirst.Domains
{
    public partial class Consulta
    {
        public int IdConsulta { get; set; }

        [Required(ErrorMessage = "Este é um campo OBRIGATÓRIO!!!")]
        public int? IdPaciente { get; set; }

        [Required(ErrorMessage = "Este é um campo OBRIGATÓRIO!!!")]
        public int? IdMedico { get; set; }

        [Required(ErrorMessage = "Este é um campo OBRIGATÓRIO!!!")]
        public int? IdStatusConsulta { get; set; }

        [Required(ErrorMessage = "Este é um campo OBRIGATÓRIO!!!")]
        public DateTime DataConsulta { get; set; }

        [Required(ErrorMessage = "Este é um campo OBRIGATÓRIO!!!")]
        public TimeSpan HorarioConsulta { get; set; }

        public string DescricaoAtendimento { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; }

        public virtual Paciente IdPacienteNavigation { get; set; }

        public virtual StatusConsulta IdStatusConsultaNavigation { get; set; }
    }
}
