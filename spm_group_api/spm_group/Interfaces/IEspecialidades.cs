using spm_group.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spm_group.Interfaces
{
    interface IEspecialidades
    {

        List<Especialidade> ListarTodos();

        Especialidade BuscarPorId(int id);

        void Cadastrar(Especialidade clinica);

        void Atualizar(int id, Especialidade clinicaAtualizada);

        void Deletar(int id);


    }
}
