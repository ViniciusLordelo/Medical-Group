using spm_group.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spm_group.Interfaces
{
    interface IPacientes
    {

        List<Paciente> ListarTodos();

        Paciente BuscarPorId(int id);

        void Cadastrar(Paciente clinica);

        void Atualizar(int id, Paciente clinicaAtualizada);

        void Deletar(int id);


    }
}
