using API.Funcionarios.DTOs;
using API.Funcionarios.Entities;
using System.Collections.Generic;

namespace API.Funcionarios.Mappers
{
    public interface IFuncionarioMapper
    {
        FuncionarioDTO ToDTO(Funcionario funcionario);
        Funcionario ToEntity(FuncionarioDTO funcionarioDTO);
        IEnumerable<FuncionarioDTO> ToListDTO(IEnumerable<Funcionario> funcionarios);
        IEnumerable<Funcionario> ToListEntity(IEnumerable<FuncionarioDTO> funcionariosDTO);
    }
}
