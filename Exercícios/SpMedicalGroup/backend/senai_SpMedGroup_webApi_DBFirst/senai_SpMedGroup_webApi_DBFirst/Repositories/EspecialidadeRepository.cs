using senai_SpMedGroup_webApi_DBFirst.Context;
using senai_SpMedGroup_webApi_DBFirst.Domains;
using senai_SpMedGroup_webApi_DBFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedGroup_webApi_DBFirst.Repositories
{
    public class EspecialidadeRepository : IEspecialidadeRepository

    {

        SpMedGroupContext ctx = new SpMedGroupContext();


        public void Deletar(int id)
        {
            Especialidade especialidadeBuscada = ctx.Especialidades.Find(id);

            ctx.Especialidades.Remove(especialidadeBuscada);

            ctx.SaveChanges();
        }

        public void Cadastrar(Especialidade novaEspecialidade)
        {
            ctx.Especialidades.Add(novaEspecialidade);

            ctx.SaveChanges();
        }

        public void Atualizar(int id, Especialidade especialidadeAtualizada)
        {
            Especialidade especialidadeBuscada = ctx.Especialidades.Find(id);

            if (especialidadeAtualizada.DescricaoEspecialidade != null)
            {
                especialidadeBuscada.DescricaoEspecialidade = especialidadeAtualizada.DescricaoEspecialidade;
            }

            ctx.Especialidades.Update(especialidadeBuscada);

            ctx.SaveChanges();
        }

        public List<Especialidade> Listar()
        {
            return ctx.Especialidades.ToList();
        }

        public Especialidade BuscarPorId(int id)
        {
            return ctx.Especialidades.FirstOrDefault(e => e.IdEspecialidade == id);
        }

    }
}
