namespace ModaVersatilApplication.DTOs.Request
{
    public class VendaDTORequest
    {
        public int Id { get; set; }

        public DateTime DataCadastro { get; set; }

        public float Total { get; set; }

        public string? CodigoRastreio { get; set; }

        public int ClienteId { get; set; }
        public bool? Estornado { get; set; }
    }
}
