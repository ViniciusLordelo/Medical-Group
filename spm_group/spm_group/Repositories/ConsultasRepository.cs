
using Microsoft.EntityFrameworkCore;
using spm_group.Domains;
using spm_group.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using spm_group.Contexts;

namespace spm_group.Repositories
{


    public class ConsultasRepository : IConsultas
    {

        SPMGContext ctx = new SPMGContext();
       

        public void Atualizar(int id, Consulta consultaAtualizada)
        {
            throw new NotImplementedException();
        }

        public Consulta BuscarPorId(int id)
        {
            return ctx.Consultas.Find(id);
        }

        public void Cadastrar(Consulta consulta)
        {
            ctx.Consultas.Add(consulta);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
           ctx.Consultas.Remove(BuscarPorId(id));

           ctx.SaveChanges();
        }

        public List<Consulta> ListarTodos()
        {
                return ctx.Consultas.Select(c => new Consulta
                    {


                        //LISTA AS CONSULTAS (COM NOMES REAIS)
                        IdConsulta = c.IdConsulta,
                        IdPaciente = c.IdPaciente,
                        IdMedico = c.IdMedico,
                        IdSituacao = c.IdSituacao,
                        DataAgendamento = c.DataAgendamento,
                        Descricao = c.Descricao,



                        //LISTA AS INFORMAÇOES DO MÉDICO (COM NOMES REAIS)
                        IdMedicoNavigation = new Medico


                        {


                            IdMedico = c.IdMedicoNavigation.IdMedico,
                            IdUsuario = c.IdMedicoNavigation.IdUsuario,
                            IdClinica = c.IdMedicoNavigation.IdClinica,
                            IdEspecialidade = c.IdMedicoNavigation.IdEspecialidade,
                            Nome = c.IdMedicoNavigation.Nome,
                            Crm = c.IdMedicoNavigation.Crm,
                            Estado = c.IdMedicoNavigation.Estado,


                            //ID DA ESPECIALIDADE E O NOME DA ESPECIALIDADE QUE O MEDICO POSSUI
                            IdEspecialidadeNavigation = new Especialidade
                            {

                                IdEspecialidade = c.IdMedicoNavigation.IdEspecialidadeNavigation.IdEspecialidade,
                                Titulo = c.IdMedicoNavigation.IdEspecialidadeNavigation.Titulo

                            }



                        },








                        //LISTA OS PACIENTES (COM NOMES REAIS)
                        IdPacienteNavigation = new Paciente
                        {
                            IdPaciente = c.IdPacienteNavigation.IdPaciente,
                            IdUsuario = c.IdPacienteNavigation.IdUsuario,
                            Nome = c.IdPacienteNavigation.Nome
                        },


                        //LISTA SE O PACIENTE ESTA COM AS CONSULTAS AGENDADAS, CANCELADAS OU REALIZADA (COM NOMES REAIS)
                        IdSituacaoNavigation = new Situacao
                        {
                            IdSituacao = c.IdSituacaoNavigation.IdSituacao,
                            Titulo = c.IdSituacaoNavigation.Titulo
                        }




                    })
                    .ToList();
            }




            public List<Consulta> consultadospacientes(int id)
            {
                return ctx.Consultas
                    .Select(c => new Consulta
                    {



                        IdConsulta = c.IdConsulta,
                        IdMedico = c.IdMedico,
                        IdPaciente = c.IdPaciente,
                        IdSituacao = c.IdSituacao,
                        DataAgendamento = c.DataAgendamento,
                        Descricao = c.Descricao,

                        IdPacienteNavigation = new Paciente
                        {
                            IdPaciente = c.IdPacienteNavigation.IdPaciente,
                            Nome = c.IdPacienteNavigation.Nome,
                            IdUsuario = c.IdPacienteNavigation.IdUsuario
                        },






                        IdMedicoNavigation = new Medico
                        {
                            IdMedico = c.IdMedicoNavigation.IdMedico,
                            IdUsuario = c.IdMedicoNavigation.IdUsuario,
                            IdEspecialidade = c.IdMedicoNavigation.IdEspecialidade,
                            Nome = c.IdMedicoNavigation.Nome,
                            Crm = c.IdMedicoNavigation.Crm,

                            IdEspecialidadeNavigation = new Especialidade
                            {
                                IdEspecialidade = c.IdMedicoNavigation.IdEspecialidadeNavigation.IdEspecialidade,
                                Titulo = c.IdMedicoNavigation.IdEspecialidadeNavigation.Titulo
                            }
                        },





                        IdSituacaoNavigation = new Situacao
                        {
                            IdSituacao = c.IdSituacaoNavigation.IdSituacao,
                            Titulo = c.IdSituacaoNavigation.Titulo
                        }


                    })


                    .Where(c => c.IdPacienteNavigation.IdUsuario == id || c.IdMedicoNavigation.IdUsuario == id)

                   
                    .ToList();
            }
    }
}
