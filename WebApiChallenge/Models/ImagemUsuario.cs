using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiChallenge.Models
{
    [Table("t_imagem_usuario_odontoprev")]
    public class ImagemUsuario
    {
        [Column("imagem_usuario_id")]
        public int ImagemUsuarioId { get; set; }
        [Column("usuario_id")]
        public int UsuarioId { get; set; }
        [Column("imagem_url")]
        public string ImagemUrl { get; set; }
        [Column("data_envio")]
        public DateTime DataEnvio { get; set; } = DateTime.Now;

        // Relação com Usuario
        public Usuario? Usuario { get; set; }
    }
}
