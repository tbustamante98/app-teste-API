using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace API.Funcionarios.DTOs
{
    public class FuncionarioDTO
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
        [Required]
        public string NomeCompleto { get; set; }
        [Required]
        public DateTime? Nascimento { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Sexo { get; set; }
        [Required]
        public bool? Ativo { get; set; }
        [Required]
        public IEnumerable<HabilidadeDTO> Habilidades { get; set; }
        public bool NomeCompletoValido()
        {
            string sRegex = @"^((\b[A-zÀ-ú']{2,40}\b)\s*){2,}$";
            Regex regex = new Regex(sRegex);
            Match match = regex.Match(NomeCompleto);
            return match.Success;
        }
        public object ToResponse() =>
            new
            {
                id = Id,
                nomeCompleto = NomeCompleto,
                idade = new DateTime(DateTime.Now.Subtract(Nascimento.Value).Ticks).Year - 1,
                nascimento = Nascimento.Value.ToString("dd/MM/yyyy"),
                email = Email,
                sexo = Sexo,
                status = Ativo.Value ? "Ativo" : "Inativo",
                habilidades = String.Join(", ", Habilidades.Select(h => h.Nome)),
                habilidadesObj = Habilidades
            };
    }
}
