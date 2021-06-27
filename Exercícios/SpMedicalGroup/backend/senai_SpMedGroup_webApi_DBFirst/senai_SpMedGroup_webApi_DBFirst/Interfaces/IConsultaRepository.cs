using senai_SpMedGroup_webApi_DBFirst.ViewModel;
using senai_SpMedGroup_webApi_DBFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedGroup_webApi_DBFirst.Interfaces
{
    interface IConsultaRepository
    {
        void Deletar(int id);

        void Cadastrar(Consulta novaConsulta);

        Consulta BuscarPorId(int id);

        List<Consulta> ListarConsultas(int id);

        List<Consulta> Listar();

        void Atualizar(int id, Consulta consultaAtualizada);

        void AtualizarDescricaoConsulta(int id, ConsultaViewModel atualizarDescricao);

        void AtualizarStatusConsulta(int id, int idStatus);

        
    }
}
