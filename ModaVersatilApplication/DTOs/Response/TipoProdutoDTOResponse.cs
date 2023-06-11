using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModaVersatilApplication.DTOs.Response
{
    public class TipoProdutoDTOResponse
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public bool Ativo { get; set; }
    }
}
