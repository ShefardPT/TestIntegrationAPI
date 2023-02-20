using System.Text.Json.Serialization;

namespace TestIntegration.API.Models
{
    /// <summary>
    /// Класс-модель для представления данных о пользователе из внешнего источника
    /// </summary>
    public record ExternalUserDataDTO
    {
        [JsonPropertyName("id")]
        public long Id { get; init; }

        [JsonPropertyName("name")]
        public string Name { get; init; }

        [JsonPropertyName("username")]
        public string Username { get; init; }

        [JsonPropertyName("email")]
        public string Email { get; init; }

        [JsonPropertyName("phone")]
        public string Phone { get; init; }

        [JsonPropertyName("website")]
        public string Website { get; init; }

        [JsonPropertyName("address")]
        public ExternalUserAddressDataDTO Address { get; init; }

        [JsonPropertyName("company")]
        public ExternalUserCompanyDataDTO Company { get; init; }
    }

    /// <summary>
    /// Класс-модель для представления данных об адресе пользователя из внешнего источника
    /// </summary>
    public record ExternalUserAddressDataDTO
    {
        [JsonPropertyName("street")]
        public string Street { get; init; }

        [JsonPropertyName("suite")]
        public string Suite { get; init; }

        [JsonPropertyName("city")]
        public string City { get; init; }

        [JsonPropertyName("zipcode")]
        public string Zipcode { get; init; }

        [JsonPropertyName("geo")]
        public ExternalUserAddressGeoDataDTO Geo { get; init; }
    }

    /// <summary>
    /// Класс-модель для представления данных о геопозиции адреса пользователя из внешнего источника
    /// </summary>
    public record ExternalUserAddressGeoDataDTO
    {
        [JsonPropertyName("lat")]
        public string Lat { get; init; }

        [JsonPropertyName("lng")]
        public string Lng { get; init; }
    }

    /// <summary>
    /// Класс-модель для представления данных о компании пользователя из внешнего источника
    /// </summary>
    public record ExternalUserCompanyDataDTO
    {
        [JsonPropertyName("name")]
        public string Name { get; init; }

        [JsonPropertyName("catchPhrase")]
        public string CatchPhrase { get; init; }

        [JsonPropertyName("bs")]
        public string Bs { get; init; }
    }
}
