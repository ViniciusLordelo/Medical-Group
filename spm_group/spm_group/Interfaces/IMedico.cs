using spm_group.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spm_group.Interfaces
{
    interface IMedico
    {

        List<Medico> ListarTodos();

        Medico BuscarPorId(int id);

        void Cadastrar(Medico clinica);

        void Atualizar(int id, Medico clinicaAtualizada);

        void Deletar(int id);


    }
}
