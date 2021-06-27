using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai_SpMedGroup_webApi_DBFirst.Domains
{
    public partial class StatusConsulta
    {
        public StatusConsulta()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int IdStatusConsulta { get; set; }

        [Required(ErrorMessage = "Este é um campo OBRIGATÓRIO!!!")]
        public string DescricaoStatusConsulta { get; set; }

        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
