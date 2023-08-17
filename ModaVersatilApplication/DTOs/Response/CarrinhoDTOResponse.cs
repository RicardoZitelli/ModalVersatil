namespace ModaVersatilApplication.DTOs.Response
{
    public class CarrinhoDTOResponse
    {
        public int Id { get; set; }

        public int? ClienteId { get; set; }

        public int ProdutoId { get; set; }

        public int Quantidade { get; set; }

        public float ValorUnitario { get; set; }

        public float Total { get; set; }

        public DateTime DataCadastro { get; set; }

        public int? VendaId { get; set; }

        public string? ClienteTemporarioId { get; set; }
    }
}
