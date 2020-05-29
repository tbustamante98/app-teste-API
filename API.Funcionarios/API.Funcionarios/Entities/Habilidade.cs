using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Funcionarios.Entities
{
    [Table("habilidades")]
    public class Habilidade
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("nome", TypeName = "varchar(100)")]
        public string Nome { get; set; }
    }
}
