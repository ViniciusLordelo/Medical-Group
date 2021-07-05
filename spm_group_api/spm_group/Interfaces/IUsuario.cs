
using spm_group.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spm_group.Interfaces
{
    interface IUsuario
    {

        List<Usuario> ListarTodos();

        Usuario BuscarPorId(int id);

        void Cadastrar(Usuario clinica);

        void Atualizar(int id, Usuario clinicaAtualizada);

        void Deletar(int id);

        Usuario Login(string email, string senha);



    }
}
