using senai_SpMedGroup_webApi_DBFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedGroup_webApi_DBFirst.Interfaces
{
    interface IUsuarioRepository
    {
        void Deletar(int id);

        void Cadastrar(Usuario novoUsuario);

        void Atualizar(int id, Usuario usuarioAtualizado);

        Usuario Login(string email, string senha);

        List<Usuario> Listar();

        Usuario BuscarPorId(int id);
    }
}
