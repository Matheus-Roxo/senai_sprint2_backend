using Microsoft.EntityFrameworkCore;
using senai_SpMedGroup_webApi_DBFirst.Context;
using senai_SpMedGroup_webApi_DBFirst.Domains;
using senai_SpMedGroup_webApi_DBFirst.Interfaces;
using senai_SpMedGroup_webApi_DBFirst.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedGroup_webApi_DBFirst.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        SpMedGroupContext ctx = new SpMedGroupContext();

        public void Deletar(int id)
        {
            Consulta consultaBuscada = ctx.Consultas.Find(id);

            ctx.Consultas.Remove(consultaBuscada);

            ctx.SaveChanges();
        }

        public void Cadastrar(Consulta novaConsulta)
        {
            ctx.Consultas.Add(novaConsulta);

            ctx.SaveChanges();
        }

        public void Atualizar(int id, Consulta consultaAtualizada)
        {
            Consulta consultaBuscada = ctx.Consultas.Find(id);

            if (consultaAtualizada.IdPaciente != null)
            {
                consultaBuscada.IdPaciente = consultaAtualizada.IdPaciente;
            }
            if (consultaAtualizada.IdMedico != null)
            {
                consultaBuscada.IdMedico = consultaAtualizada.IdMedico;
            }
            if (consultaAtualizada.IdStatusConsulta != null)
            {
                consultaBuscada.IdStatusConsulta = consultaAtualizada.IdStatusConsulta;
            }

            consultaBuscada.DataConsulta = consultaAtualizada.DataConsulta;

            consultaBuscada.HorarioConsulta = consultaAtualizada.HorarioConsulta;

            if (consultaBuscada.DescricaoAtendimento != null)
            {
                consultaBuscada.DescricaoAtendimento = consultaAtualizada.DescricaoAtendimento;
            }

            ctx.Consultas.Update(consultaBuscada);

            ctx.SaveChanges();
        }

        public List<Consulta> Listar()
        {
            return ctx.Consultas

                .Include(c => c.IdPacienteNavigation)

                .Include(c => c.IdMedicoNavigation)

                .Include(c => c.IdMedicoNavigation.IdEspecialidadeNavigation)

                .Include(c => c.IdStatusConsultaNavigation)

                .ToList();
        }

        public Consulta BuscarPorId(int id)
        {
            return ctx.Consultas

                .Include(c => c.IdPacienteNavigation)

                .Include(c => c.IdMedicoNavigation)

                .Include(c => c.IdMedicoNavigation.IdEspecialidadeNavigation)

                .Include(c => c.IdStatusConsultaNavigation)

                .Select(c => new Consulta
                {
                    IdConsulta = c.IdConsulta,
                    DataConsulta = c.DataConsulta,
                    DescricaoAtendimento = c.DescricaoAtendimento,

                    IdPacienteNavigation = new Paciente
                    {
                        IdPaciente = c.IdPacienteNavigation.IdPaciente,
                        IdUsuario = c.IdPacienteNavigation.IdUsuario,
                        NomePaciente = c.IdPacienteNavigation.NomePaciente,
                    },

                    IdMedicoNavigation = new Medico
                    {
                        IdMedico = c.IdMedicoNavigation.IdMedico,
                        IdUsuario = c.IdMedicoNavigation.IdUsuario,
                        NomeMedico = c.IdMedicoNavigation.NomeMedico,
                        Crm = c.IdMedicoNavigation.Crm,

                        IdEspecialidadeNavigation = new Especialidade
                        {
                            IdEspecialidade = c.IdMedicoNavigation.IdEspecialidadeNavigation.IdEspecialidade,
                            DescricaoEspecialidade = c.IdMedicoNavigation.IdEspecialidadeNavigation.DescricaoEspecialidade
                        }
                    },

                    IdStatusConsultaNavigation = new StatusConsulta
                    {
                        IdStatusConsulta = c.IdStatusConsultaNavigation.IdStatusConsulta,
                        DescricaoStatusConsulta = c.IdStatusConsultaNavigation.DescricaoStatusConsulta
                    }

                })

                .FirstOrDefault(c => c.IdConsulta == id);
        }

        public void AtualizarStatusConsulta(int idConsulta, int idStatus)
        {
            Consulta consultaBuscada = ctx.Consultas.Find(idConsulta);

            if (consultaBuscada.IdStatusConsulta != null)
            {
                consultaBuscada.IdStatusConsulta = idStatus;
            }

            ctx.Consultas.Update(consultaBuscada);

            ctx.SaveChanges();
        }
   

    public void AtualizarDescricaoConsulta(int id, ConsultaViewModel atualizarDescricao)
        {
            Consulta consultaBuscada = ctx.Consultas.Find(id);

            if (atualizarDescricao.DescricaoDoAtendimento != null)
            {
                consultaBuscada.DescricaoAtendimento = atualizarDescricao.DescricaoDoAtendimento;
            }

            ctx.Consultas.Update(consultaBuscada);

            ctx.SaveChanges();
        }

        public List<Consulta> ListarConsultas(int id)
        {

            return ctx.Consultas

                .Include(c => c.IdPacienteNavigation)

                .Include(c => c.IdMedicoNavigation)

                .Include(c => c.IdMedicoNavigation.IdEspecialidadeNavigation)

                .Include(c => c.IdStatusConsultaNavigation)

                .Select(c => new Consulta
                {
                    IdConsulta = c.IdConsulta,
                    DataConsulta = c.DataConsulta,
                    DescricaoAtendimento = c.DescricaoAtendimento,

                    IdPacienteNavigation = new Paciente
                    {
                        IdPaciente = c.IdPacienteNavigation.IdPaciente,
                        IdUsuario = c.IdPacienteNavigation.IdUsuario,
                        NomePaciente = c.IdPacienteNavigation.NomePaciente,
                    },

                    IdMedicoNavigation = new Medico
                    {
                        IdMedico = c.IdMedicoNavigation.IdMedico,
                        IdUsuario = c.IdMedicoNavigation.IdUsuario,
                        NomeMedico = c.IdMedicoNavigation.NomeMedico,
                        Crm = c.IdMedicoNavigation.Crm,

                        IdEspecialidadeNavigation = new Especialidade
                        {
                            IdEspecialidade = c.IdMedicoNavigation.IdEspecialidadeNavigation.IdEspecialidade,
                            DescricaoEspecialidade = c.IdMedicoNavigation.IdEspecialidadeNavigation.DescricaoEspecialidade
                        }
                    },

                    IdStatusConsultaNavigation = new StatusConsulta
                    {
                        IdStatusConsulta = c.IdStatusConsultaNavigation.IdStatusConsulta,
                        DescricaoStatusConsulta = c.IdStatusConsultaNavigation.DescricaoStatusConsulta
                    }

                })

                .Where(c => c.IdPacienteNavigation.IdUsuario == id || c.IdMedicoNavigation.IdUsuario == id)

                .ToList();
        }




    }
}
