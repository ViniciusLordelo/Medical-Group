
using spm_group.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spm_group.Interfaces
{
    interface ITiposUsuario
    {

        List<TiposUsuario> ListarTodos();

        TiposUsuario BuscarPorId(int id);

        void Cadastrar(TiposUsuario clinica);

        void Atualizar(int id, TiposUsuario clinicaAtualizada);

        void Deletar(int id);



    }
}
