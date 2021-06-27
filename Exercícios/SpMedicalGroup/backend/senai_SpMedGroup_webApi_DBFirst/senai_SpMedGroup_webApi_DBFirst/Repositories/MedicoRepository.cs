using Microsoft.EntityFrameworkCore;
using senai_SpMedGroup_webApi_DBFirst.Context;
using senai_SpMedGroup_webApi_DBFirst.Domains;
using senai_SpMedGroup_webApi_DBFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedGroup_webApi_DBFirst.Repositories
{
    public class MedicoRepository : IMedicoRepository

    {
        SpMedGroupContext ctx = new SpMedGroupContext();

        public void Deletar(int id)
        {
            Medico medicoBuscado = ctx.Medicos.Find(id);

            ctx.Medicos.Remove(medicoBuscado);

            ctx.SaveChanges();
        }

        public void Cadastrar(Medico novoMedico)
        {
            ctx.Medicos.Add(novoMedico);

            ctx.SaveChanges();
        }

        public void Atualizar(int id, Medico medicoAtualizado)
        {
            Medico medicoBuscado = ctx.Medicos.Find(id);

            if (medicoAtualizado.IdUsuario != 0)
            {
                medicoBuscado.IdUsuario = medicoAtualizado.IdUsuario;
            }
            if (medicoAtualizado.IdClinica != null)
            {
                medicoBuscado.IdEspecialidade = medicoAtualizado.IdEspecialidade;
            }
            if (medicoAtualizado.NomeMedico != null)
            {
                medicoBuscado.NomeMedico = medicoAtualizado.NomeMedico;
            }
            if (medicoAtualizado.Crm != null)
            {
                medicoBuscado.Crm = medicoAtualizado.Crm;
            }

            ctx.Medicos.Update(medicoBuscado);

            ctx.SaveChanges();
        }

        public Medico BuscarPorId(int id)
        {
            return ctx.Medicos

                .Include(m => m.IdEspecialidadeNavigation)

                .Include(m => m.IdClinicaNavigation)

                .Select(m => new Medico
                {
                    IdMedico = m.IdMedico,
                    NomeMedico = m.NomeMedico,
                    Crm = m.Crm,

                    IdEspecialidadeNavigation = new Especialidade
                    {
                        IdEspecialidade = m.IdEspecialidadeNavigation.IdEspecialidade,
                        DescricaoEspecialidade = m.IdEspecialidadeNavigation.DescricaoEspecialidade
                    },

                    IdClinicaNavigation = new Clinica
                    {
                        IdClinica = m.IdClinicaNavigation.IdClinica,
                        NomeFantasia = m.IdClinicaNavigation.NomeFantasia
                    }

                })
                .FirstOrDefault(u => u.IdMedico == id);
        }

        public List<Medico> Listar()
        {
            return ctx.Medicos
                .Include(m => m.IdEspecialidadeNavigation)

                .Include(m => m.IdClinicaNavigation)

                .Select(m => new Medico
                {
                    IdMedico = m.IdMedico,
                    NomeMedico = m.NomeMedico,
                    Crm = m.Crm,

                    IdEspecialidadeNavigation = new Especialidade
                    {
                        IdEspecialidade = m.IdEspecialidadeNavigation.IdEspecialidade,
                        DescricaoEspecialidade = m.IdEspecialidadeNavigation.DescricaoEspecialidade
                    },

                    IdClinicaNavigation = new Clinica
                    {
                        IdClinica = m.IdClinicaNavigation.IdClinica,
                        NomeFantasia = m.IdClinicaNavigation.NomeFantasia
                    }

                })
                .ToList();
        }

    }
}
