using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Event_plus.Domains
{
    [Table("TiposUsuarios")]
    public class TiposUsuarios
    {
        [Key]
        public Guid IdTipoUsuario { get; set; }
        //get -> acessar
        //set -> atribuir
        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "O título é obrigatório!")]
        public string? TituloTipoUsuario { get; set; }

        //sql = BIT, VARCHAR, int
        //C# = bool, string, int
    }
}
