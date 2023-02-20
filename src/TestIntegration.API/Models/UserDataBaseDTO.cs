using System.Text.Json.Serialization;

namespace TestIntegration.API.Models
{
    /// <summary>
    /// Класс-модель для представления основных данных о пользователе
    /// </summary>
    public record UserDataBaseDTO
    {
        [JsonPropertyName("name")]
        public string Name { get; init; }

        [JsonPropertyName("email")]
        public string Email { get; init; }

        /// <summary>
        /// Преобразовать модель данных из внешнего источника
        /// </summary>
        /// <param name="external"></param>
        /// <returns></returns>
        public static UserDataBaseDTO ParseFromExternalDTO(ExternalUserDataDTO external)
        {
            return new UserDataBaseDTO()
            {
                Email = external.Email,
                Name = external.Name
            };
        }
    }
}
