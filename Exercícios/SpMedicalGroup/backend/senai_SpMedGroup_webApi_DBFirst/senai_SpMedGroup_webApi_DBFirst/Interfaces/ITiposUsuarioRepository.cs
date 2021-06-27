using senai_SpMedGroup_webApi_DBFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedGroup_webApi_DBFirst.Interfaces
{
    interface ITiposUsuarioRepository
    {
        void Deletar(int id);

        void Cadastrar(TiposUsuario novoTipo);

        void Atualizar(int id, TiposUsuario tipoAtualizado);

        TiposUsuario BuscarPorId(int id);

        List<TiposUsuario> Listar();
    }
}
