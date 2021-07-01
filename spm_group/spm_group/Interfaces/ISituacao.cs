using spm_group.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spm_group.Interfaces
{
    interface ISituacao
    {

        List<Situacao> ListarTodos();

        Situacao BuscarPorId(int id);

        void Cadastrar(Situacao clinica);

        void Atualizar(int id, Situacao clinicaAtualizada);

        void Deletar(int id);


    }
}
