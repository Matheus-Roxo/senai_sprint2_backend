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
    public class PacienteRepository : IPacienteRepository

    {

        SpMedGroupContext ctx = new SpMedGroupContext();

        public void Deletar(int id)
        {
            Paciente pacienteBuscado = ctx.Pacientes.Find(id);

            ctx.Pacientes.Remove(pacienteBuscado);

            ctx.SaveChanges();
        }

        public void Cadastrar(Paciente novoPaciente)
        {
            ctx.Pacientes.Add(novoPaciente);

            ctx.SaveChanges();
        }

        public void Atualizar(int id, Paciente pacienteAtualizado)
        {
            Paciente pacienteBuscado = ctx.Pacientes.Find(id);

            if (pacienteAtualizado.IdUsuario != 0)
            {
                pacienteBuscado.IdUsuario = pacienteAtualizado.IdUsuario;
            }
            if (pacienteAtualizado.NomePaciente != null)
            {
                pacienteBuscado.NomePaciente = pacienteAtualizado.NomePaciente;
            }
            if (pacienteAtualizado.Rg != null)
            {
                pacienteBuscado.Rg = pacienteAtualizado.Rg;
            }
            if (pacienteAtualizado.Cpf != null)
            {
                pacienteBuscado.Telefone = pacienteAtualizado.Telefone;
            }
            if (pacienteAtualizado.Endereco != null)
            {
                pacienteBuscado.Endereco = pacienteAtualizado.Endereco;
            }

            ctx.Pacientes.Update(pacienteBuscado);

            ctx.SaveChanges();
        }

        public Paciente BuscarPorId(int id)
        {
            return ctx.Pacientes
                .Include(p => p.IdUsuarioNavigation)
                .Select(p => new Paciente
                {
                    IdUsuario = p.IdUsuario,
                    IdPaciente = p.IdPaciente,
                    NomePaciente = p.NomePaciente,
                    DataNascimento = p.DataNascimento,
                    Telefone = p.Telefone,
                    Rg = p.Rg,
                    Cpf = p.Cpf,
                    Endereco = p.Endereco
                })
                .FirstOrDefault(u => u.IdPaciente == id);
        }

        public List<Paciente> Listar()
        {
            return ctx.Pacientes
                .Include(p => p.IdUsuarioNavigation)
                .Select(p => new Paciente
                {
                    IdUsuario = p.IdUsuario,
                    IdPaciente = p.IdPaciente,
                    NomePaciente = p.NomePaciente,
                    DataNascimento = p.DataNascimento,
                    Telefone = p.Telefone,
                    Rg = p.Rg,
                    Cpf = p.Cpf,
                    Endereco = p.Endereco
                })
                .ToList();
        }

    }
}
