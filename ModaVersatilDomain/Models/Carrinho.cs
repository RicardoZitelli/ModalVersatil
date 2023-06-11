using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModaVersatilDomain.Models
{
    public class Carrinho
    {

        public int Id { get; set; }

        public int ClienteId { get; set; }

        public int ProdutoId { get; set; }

        public int Quantidade { get; set; }

        public float ValorVenda { get; set; }
        
        public float Total { get; set; }

        public DateTime DataCadastro { get; set; }

        public int VendaId { get; set; }

        public string? ClienteTemporarioId { get; set; }
    }
}
