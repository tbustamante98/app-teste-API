using API.Funcionarios.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Funcionarios.Repository.Interfaces
{
    public interface IHabilidadeRepository
    {
        Task<IEnumerable<Habilidade>> ListarAsync();
    }
}
