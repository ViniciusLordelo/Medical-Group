
using spm_group.Interfaces;
using spm_group.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using spm_group.Contexts;

namespace spm_group.Repositories
{
    public class TiposUsuariosRepository : ITiposUsuario
    {
        SPMGContext ctx = new SPMGContext();

        public void Atualizar(int id, TiposUsuario clinicaAtualizada)
        {
          
        }

        public TiposUsuario BuscarPorId(int id)
        {
            return ctx.TiposUsuarios.Find(id);
        }

        public void Cadastrar(TiposUsuario clinica)
        {
            ctx.TiposUsuarios.Add(clinica);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            TiposUsuario clinica = BuscarPorId(id);

            ctx.TiposUsuarios.Remove(clinica);

            ctx.SaveChanges();
        }

        public List<TiposUsuario> ListarTodos()
        {
            return ctx.TiposUsuarios.ToList();
        }
    }
}
