using System.ComponentModel.DataAnnotations;

namespace API.Funcionarios.DTOs
{
    public class HabilidadeDTO
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
    }
}
