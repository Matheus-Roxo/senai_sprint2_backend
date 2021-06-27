using senai_SpMedGroup_webApi_DBFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedGroup_webApi_DBFirst.Interfaces
{
    interface IPacienteRepository
    {
        void Deletar(int id);

        void Cadastrar(Paciente novoPaciente);

        void Atualizar(int id, Paciente pacienteAtualizado);

        Paciente BuscarPorId(int id);

        List<Paciente> Listar();
    }
}
