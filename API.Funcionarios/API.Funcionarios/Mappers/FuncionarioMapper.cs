using API.Funcionarios.DTOs;
using API.Funcionarios.Entities;
using System.Collections.Generic;
using System.Linq;

namespace API.Funcionarios.Mappers
{
    public class FuncionarioMapper : IFuncionarioMapper
    {
        public FuncionarioDTO ToDTO(Funcionario funcionario)
        {
            return new FuncionarioDTO
            {
                Id = funcionario.Id,
                Email = funcionario.Email,
                Sexo = funcionario.Sexo,
                Nascimento = funcionario.Nascimento,
                NomeCompleto = funcionario.NomeCompleto,
                Ativo = funcionario.Ativo,
                Habilidades = funcionario.Habilidades.Select(h => new HabilidadeDTO { Id = h.Id, Nome = h.Nome })
            };
        }

        public Funcionario ToEntity(FuncionarioDTO funcionarioDTO)
        {
            return new Funcionario
            {
                Id = funcionarioDTO.Id,
                Email = funcionarioDTO.Email,
                Sexo = funcionarioDTO.Sexo,
                Nascimento = funcionarioDTO.Nascimento.Value,
                NomeCompleto = funcionarioDTO.NomeCompleto,
                Ativo = funcionarioDTO.Ativo.Value,
                Habilidades = funcionarioDTO.Habilidades.Select(h => new Habilidade { Id = h.Id, Nome = h.Nome })
            };
        }

        public IEnumerable<FuncionarioDTO> ToListDTO(IEnumerable<Funcionario> funcionarios) =>
            funcionarios.Select(f => ToDTO(f));

        public IEnumerable<Funcionario> ToListEntity(IEnumerable<FuncionarioDTO> funcionariosDTO) =>
            funcionariosDTO.Select(f => ToEntity(f));
    }
}
