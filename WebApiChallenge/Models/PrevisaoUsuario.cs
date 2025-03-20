using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiChallenge.Models
{
    [Table("t_previsao_usuario_odontoprev")]
    public class PrevisaoUsuario
    {
        [Column("previsao_usuario_id")]
        public int PrevisaoUsuarioId { get; set; }

        [Column("imagem_usuario_id")]
        public int ImagemUsuarioId { get; set; }

        [Column("usuario_id")]
        public int UsuarioId { get; set; }

        [Column("previsao_texto")]
        public string PrevisaoTexto { get; set; }

        [Column("probabilidade")]
        public decimal Probabilidade { get; set; }

        [Column("recomendacao")]
        public string Recomendacao { get; set; }

        [Column("data_previsao")]
        public DateTime DataPrevisao { get; set; } = DateTime.Now;

        public ImagemUsuario? ImagemUsuario { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
