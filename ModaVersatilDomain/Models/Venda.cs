using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModaVersatilDomain.Models
{
    public class Venda
    {
        public int Id { get; set; }
        
        public DateTime DataCadastro { get; set; }
        
        public float Total { get; set; }

        public string? CodigoRastreio { get; set; }

        public int ClienteId { get; set; }
        public bool Estornado { get; set; }
    }
}
