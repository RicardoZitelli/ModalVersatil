using System.ComponentModel.DataAnnotations;

namespace ModaVersatilDomain.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        
        public string? Nome { get; set; }
        
        public string? Cpf { get; set; }

        public string? Endereco { get; set; }

        public string? Numero { get; set; }

        public string? Cep { get; set; }

        public string? Cidade { get; set; }

        public string? Estado { get; set; }

        [Required]
        public string Email { get; set; }

        public DateTime DataCadastro { get; set; }
        
        [Required]
        public string Usuario { get; set; }

        [Required]
        public string Senha { get; set; }
        
        public bool Ativo { get; set; }
    }
}
