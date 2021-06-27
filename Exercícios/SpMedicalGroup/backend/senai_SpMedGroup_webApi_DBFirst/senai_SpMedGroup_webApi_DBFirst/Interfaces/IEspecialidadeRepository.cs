using senai_SpMedGroup_webApi_DBFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedGroup_webApi_DBFirst.Interfaces
{
    interface IEspecialidadeRepository
    {
        void Deletar(int id);

        void Cadastrar(Especialidade novaEspecialidade);

        void Atualizar(int id, Especialidade especialidadeAtualizada);

        List<Especialidade> Listar();

        Especialidade BuscarPorId(int id);

    }
}
