using System.Text.Json.Serialization;

namespace TestIntegration.API.Models
{
    public record UserDataFullDTO : UserDataBaseDTO
    {
        [JsonPropertyName("username")]
        public string Username { get; set; }
    }
}
