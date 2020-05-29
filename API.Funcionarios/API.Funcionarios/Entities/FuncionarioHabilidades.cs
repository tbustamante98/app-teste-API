using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Funcionarios.Entities
{
    [Table("funcionario_habilidades")]
    public class FuncionarioHabilidades
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("funcionario_id")]
        public int FuncionarioId { get; set; }
        [Column("habilidade_id")]
        [Required]
        public int HabilidadeId { get; set; }
    }
}
