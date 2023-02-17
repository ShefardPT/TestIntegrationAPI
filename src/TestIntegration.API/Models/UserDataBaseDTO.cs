using System.Text.Json.Serialization;

namespace TestIntegration.API.Models
{
    public record UserDataBaseDTO
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}
