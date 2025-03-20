using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiChallenge.Models
{
    [Table("t_usuario_odontoprev")]
    public class Usuario
    {
        [Column("usuario_id")]
        public int UsuarioId { get; set; }

        [Column("cpf")]
        public string Cpf { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("sobrenome")]
        public string Sobrenome { get; set; }

        [Column("data_nascimento")]
        public DateTime DataNascimento { get; set; }

        [Column("genero")]
        public char Genero { get; set; }

        [Column("data_cadastro")]
        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
