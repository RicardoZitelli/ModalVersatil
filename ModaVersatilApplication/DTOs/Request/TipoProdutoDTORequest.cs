using Newtonsoft.Json;
namespace ModaVersatilApplication.DTOs.Request
{
    public class TipoProdutoDTORequest
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("descricao")]
        public string? Descricao { get; set; }
        
        [JsonProperty("ativo")]
        public bool Ativo { get; set; }

    }
}
