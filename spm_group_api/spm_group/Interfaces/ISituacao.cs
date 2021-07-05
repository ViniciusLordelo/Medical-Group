using spm_group.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spm_group.Interfaces
{
    interface ISituacao
    {

        List<Situaco> ListarTodos();

        Situaco BuscarPorId(int id);

        void Cadastrar(Situaco clinica);

        void Atualizar(int id, Situaco clinicaAtualizada);

        void Deletar(int id);


    }
}
