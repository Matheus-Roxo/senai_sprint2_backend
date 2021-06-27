using senai_SpMedGroup_webApi_DBFirst.Context;
using senai_SpMedGroup_webApi_DBFirst.Domains;
using senai_SpMedGroup_webApi_DBFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedGroup_webApi_DBFirst.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {

        SpMedGroupContext ctx = new SpMedGroupContext();

        public void Deletar(int id)
        {
            Clinica clinicaBuscada = ctx.Clinicas.Find(id);

            ctx.Clinicas.Remove(clinicaBuscada);

            ctx.SaveChanges();
        }

        public void Cadastrar(Clinica novaClinica)
        {
            ctx.Clinicas.Add(novaClinica);

            ctx.SaveChanges();
        }

        public void Atualizar(int id, Clinica clinicaAtualizada)
        {
            Clinica clinicaBuscada = ctx.Clinicas.Find(id);

            if (clinicaAtualizada.RazaoSocial != null)
            {
                clinicaBuscada.RazaoSocial = clinicaAtualizada.RazaoSocial;
            }
            if (clinicaAtualizada.NomeFantasia != null)
            {
                clinicaBuscada.NomeFantasia = clinicaAtualizada.NomeFantasia;
            }
            if (clinicaAtualizada.Endereco != null)
            {
                clinicaBuscada.Endereco = clinicaAtualizada.Endereco;
            }

            clinicaBuscada.HorarioAbertura = clinicaAtualizada.HorarioAbertura;

            clinicaBuscada.HorarioFechamento = clinicaAtualizada.HorarioFechamento;

            if (clinicaAtualizada.Cnpj != null)
            {
                clinicaBuscada.Cnpj = clinicaAtualizada.Cnpj;
            }
            if (clinicaAtualizada.Site != null)
            {
                clinicaBuscada.Site = clinicaAtualizada.Site;
            }

            ctx.Clinicas.Update(clinicaBuscada);

            ctx.SaveChanges();
        }

        public List<Clinica> Listar()
        {
            return ctx.Clinicas.ToList();
        }

        public Clinica BuscarPorId(int id)
        {
            return ctx.Clinicas.FirstOrDefault(c => c.IdClinica == id);
        }

    }
}