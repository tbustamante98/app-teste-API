using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Funcionarios.Entities
{
    [Table("funcionarios")]
    public class Funcionario
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("nome_completo", TypeName = "varchar(255)")]
        public string NomeCompleto { get; set; }
        [Required]
        [Column("nascimento")]
        public DateTime Nascimento { get; set; }
        [EmailAddress]
        [Column("email", TypeName = "varchar(255)")]
        public string Email { get; set; }
        [Required]
        [Column("sexo", TypeName = "varchar(20)")]
        public string Sexo { get; set; }
        [Column("ativo")]
        public bool Ativo { get; set; }
        [NotMapped]
        public IEnumerable<Habilidade> Habilidades { get; set; }
    }
}
