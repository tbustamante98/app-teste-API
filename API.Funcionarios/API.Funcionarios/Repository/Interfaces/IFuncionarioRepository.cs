using API.Funcionarios.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Funcionarios.Repository.Interfaces
{
    public interface IFuncionarioRepository
    {
        Task InserirHabilidadesFuncionarioAsync(Funcionario funcionario);
        Task<IEnumerable<Habilidade>> ObterHabilidadesFuncionarioAsync(int funcionarioId);
        Task DeletarHabilidadesFuncionarioAsync(int funcionarioId);
        Task<IEnumerable<Funcionario>> ListarAsync();
        Task<Funcionario> ObterPorIdAsync(int id);
        Task InserirAsync(Funcionario funcionario);
        Task EditarAsync(Funcionario funcionario);
    }
}
