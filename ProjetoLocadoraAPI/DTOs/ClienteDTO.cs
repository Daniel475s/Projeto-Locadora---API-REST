using System.ComponentModel.DataAnnotations;

namespace ProjetoLocadoraAPI.DTOs
{
    public class ClienteDTO
    {   
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "Obrigatório: Favor informar o nome do cliente.")]
        public string NomeCliente { get; set; }
        public bool Ativo { get; set; }
    }
}
