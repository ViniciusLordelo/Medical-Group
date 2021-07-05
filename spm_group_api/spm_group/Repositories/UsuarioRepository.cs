
using spm_group.Interfaces;
using spm_group.Contexts;
using spm_group.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace spm_group.Repositories
{
    public class UsuarioRepository : IUsuario
    {

        private SPMGContext ctx = new SPMGContext();


        public void Atualizar(int id, Usuario clinicaAtualizada)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Usuario clinica)
        {
            ctx.Usuarios.Add(clinica);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Usuario usuario = BuscarPorId(id);

            ctx.Usuarios.Remove(usuario);

            ctx.SaveChanges();
        }

        public List<Usuario> ListarTodos()
        {
            return ctx.Usuarios
                .Include(u => u.IdTipoUsuarioNavigation)
                .Select(u => new Usuario
                {
                    IdUsuario = u.IdUsuario,

                    IdTipoUsuario = u.IdTipoUsuario,

                    Email = u.Email,


                    IdTipoUsuarioNavigation = new TiposUsuario
                    {

                        IdTipoUsuario = u.IdTipoUsuarioNavigation.IdTipoUsuario,

                        Titulo = u.IdTipoUsuarioNavigation.Titulo

                    }
                })
                .ToList();
        }

        public Usuario Login(string email, string senha)
        {
         
               return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
           
        }
    }
}
