using API.Funcionarios.DTOs;
using API.Funcionarios.Mappers;
using API.Funcionarios.Repository.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace API.Funcionarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private readonly IFuncionarioRepository funcionarioRepository;
        private readonly IHabilidadeRepository habilidadeRepository;
        private readonly IFuncionarioMapper mapper;

        public FuncionariosController(IFuncionarioRepository repository, IHabilidadeRepository habilidadeRepository, IFuncionarioMapper mapper)
        {
            this.funcionarioRepository = repository;
            this.habilidadeRepository = habilidadeRepository;
            this.mapper = mapper;
        }
        [HttpGet("habilidades")]
        public async Task<IActionResult> ListarHabilidadesAsync()
        {
            try
            {
                var habilidades = await habilidadeRepository.ListarAsync();
                return Ok(habilidades);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> ListarFuncionariosAsync()
        {
            try
            {
                var funcionarios = await funcionarioRepository.ListarAsync();
                return Ok(mapper.ToListDTO(funcionarios).Select(f => f.ToResponse()));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> InserirAsync([FromBody] FuncionarioDTO funcionarioDTO)
        {
            try
            {
                ModelState.Remove("Id");
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                if (funcionarioDTO.Habilidades.Count() == 0)
                    return BadRequest("É necessário, no mínimo, uma habilidade.");
                if (!funcionarioDTO.NomeCompletoValido())
                    return BadRequest("Nome completo inválido. Insira nome e sobrenome.");

                var funcionario = mapper.ToEntity(funcionarioDTO);
                await funcionarioRepository.InserirAsync(funcionario);
                return Ok(mapper.ToDTO(funcionario).ToResponse());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> EditarAsync([FromBody] FuncionarioDTO funcionarioDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                if (funcionarioDTO.Habilidades.Count() == 0)
                    return BadRequest("É necessário, no mínimo, uma habilidade.");
                if (!funcionarioDTO.NomeCompletoValido())
                    return BadRequest("Nome completo inválido. Insira nome e sobrenome.");

                var funcionario = mapper.ToEntity(funcionarioDTO);
                await funcionarioRepository.EditarAsync(funcionario);

                return Ok(mapper.ToDTO(funcionario).ToResponse());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}