using senai_SpMedGroup_webApi_DBFirst.Context;
using senai_SpMedGroup_webApi_DBFirst.Domains;
using senai_SpMedGroup_webApi_DBFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedGroup_webApi_DBFirst.Repositories
{
    public class TiposUsuarioRepository : ITiposUsuarioRepository

    {

        SpMedGroupContext ctx = new SpMedGroupContext();

        public void Deletar(int id)
        {
            TiposUsuario tipoBuscado = ctx.TiposUsuarios.Find(id);

            ctx.TiposUsuarios.Remove(tipoBuscado);

            ctx.SaveChanges();
        }

        public void Cadastrar(TiposUsuario novoTipo)
        {
            ctx.TiposUsuarios.Add(novoTipo);

            ctx.SaveChanges();
        }

        public void Atualizar(int id, TiposUsuario tipoAtualizado)
        {
            TiposUsuario tipoBuscado = ctx.TiposUsuarios.Find(id);

            if (tipoAtualizado.TituloTipoUsuario != null)
            {
                tipoBuscado.TituloTipoUsuario = tipoAtualizado.TituloTipoUsuario;
            }

            ctx.TiposUsuarios.Update(tipoBuscado);

            ctx.SaveChanges();
        }

        public TiposUsuario BuscarPorId(int id)
        {
            return ctx.TiposUsuarios.FirstOrDefault(t => t.IdTipoUsuario == id);
        }

        public List<TiposUsuario> Listar()
        {
            return ctx.TiposUsuarios.ToList();
        }
    }
}
