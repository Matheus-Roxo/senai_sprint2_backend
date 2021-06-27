using senai_SpMedGroup_webApi_DBFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedGroup_webApi_DBFirst.Interfaces
{
    interface IClinicaRepository
    {
        void Deletar(int id);

        void Cadastrar(Clinica novaClinica);

        void Atualizar(int id, Clinica clinicaAtualizada);

        Clinica BuscarPorId(int id);

        List<Clinica> Listar();
    }
}
