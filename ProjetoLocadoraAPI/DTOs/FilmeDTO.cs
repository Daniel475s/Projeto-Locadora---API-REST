using System.ComponentModel.DataAnnotations;

namespace ProjetoLocadoraAPI.DTOs
{
    public class FilmeDTO
    {
        public int IdFilme { get; set; }

        [Required(ErrorMessage = "Obrigatório: Favor informar o nome do cliente.")]
        public string NomeFilme { get; set; }
        public bool Ativo { get; set; }
    }
}
