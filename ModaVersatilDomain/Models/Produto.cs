using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModaVersatilDomain.Models
{
    public class Produto
    {
        public int Id { get; set; }
        
        public int TipoProdutoId { get; set; }

        public string? Descricao { get; set; }

        public string? Conteudo { get; set; }

        public float ValorCompra { get; set; }
        
        public float ValorVenda { get; set; }

        public int Quantidade { get; set; }

        public bool Ativo { get; set; }
    }
}
