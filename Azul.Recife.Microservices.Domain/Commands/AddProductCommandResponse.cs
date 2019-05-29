using Newtonsoft.Json;

namespace Azul.Recife.Microservices.Domain.Commands
{
    public class AddProductCommandResponse
    {   
        [JsonProperty("productId")]
        public int ProductId { get; set; }
    }
}