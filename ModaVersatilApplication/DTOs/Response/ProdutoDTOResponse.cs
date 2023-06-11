namespace ModaVersatilApplication.DTOs.Response
{
    public class ProdutoDTOResponse
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
