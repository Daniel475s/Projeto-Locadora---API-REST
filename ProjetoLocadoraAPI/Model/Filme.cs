using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProjetoLocadoraAPI.Model
{
    [Table("FILME")]
    public class Filme
    {
        [Key]
        [Column("ID_FILME")]
        public int IdFilme { get; set; }

        [Column("NOME_FILME")]
        public string NomeFilme { get; set; }

        [Column("ATIVO")]
        public int Ativo { get; set; }
    }
}
