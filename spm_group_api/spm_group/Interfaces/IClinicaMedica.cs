using spm_group.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spm_group.Interfaces
{
    interface IClinicaMedica
    {

        List<Clinica> ListarTodos();

        Clinica BuscarPorId(int id);

        void Cadastrar(Clinica clinica);

        void Atualizar(int id, Clinica clinicaAtualizada);

        void Deletar(int id);


    }
}
