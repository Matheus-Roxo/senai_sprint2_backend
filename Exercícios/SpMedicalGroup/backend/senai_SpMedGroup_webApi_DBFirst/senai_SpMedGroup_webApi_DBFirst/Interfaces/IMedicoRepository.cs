using senai_SpMedGroup_webApi_DBFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedGroup_webApi_DBFirst.Interfaces
{
    interface IMedicoRepository
    {
        void Deletar(int id);

        void Cadastrar(Medico novoMedico);

        void Atualizar(int id, Medico medicoAtualizado);

        List<Medico> Listar();

        Medico BuscarPorId(int id);
    }
}
