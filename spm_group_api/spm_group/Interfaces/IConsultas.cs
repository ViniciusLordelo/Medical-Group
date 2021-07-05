using spm_group.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spm_group.Interfaces
{
    interface IConsultas
    {

        List<Consulta> ListarTodos();

        Consulta BuscarPorId(int id);

        void Cadastrar(Consulta consulta);

        void Atualizar(int id, Consulta consultaAtt);

        List<Consulta> MinhasConsultas(int id);

        void Deletar(int id);


    }
}
