using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Event_plus.Domains
{
    [Table("Eventos")]
    public class Eventos
    {
        [Key]
        public Guid IdEvento { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "A data do evento é obrigatória!")]
        public DateTime DataEvento { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome do evento obrigatório!")]
        public string? NomeEvento { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Descrição do evento obrigatório!")]
        public string? Descricao { get; set; }

        //ref.tabela TiposEvento
        public Guid IdTipoEvento { get; set; }

        [ForeignKey("IdTipoEvento")]
        public TiposEventos? TiposEvento { get; set; }

        //ref.tabela Instituicao
        public Guid IdInstituicao { get; set; }

        [ForeignKey("IdInstituicao")]
        public Instituicoes? Instituicao { get; set; }

        public PresencasEventos? PresencasEvento { get; set; }

    }
}