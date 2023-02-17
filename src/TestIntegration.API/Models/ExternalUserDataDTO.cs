using System.Text.Json.Serialization;

namespace TestIntegration.API.Models
{
    /// <summary>
    /// Класс-модель для представления данных о пользователе из внешнего источника
    /// </summary>
    public record ExternalUserDataDTO
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("website")]
        public string Website { get; set; }

        [JsonPropertyName("address")]
        public ExternalUserAddressDataDTO Address { get; set; }

        [JsonPropertyName("company")]
        public ExternalUserCompanyDataDTO Company { get; set; }
    }

    /// <summary>
    /// Класс-модель для представления данных об адресе пользователя из внешнего источника
    /// </summary>
    public record ExternalUserAddressDataDTO
    {
        [JsonPropertyName("street")]
        public string Street { get; set; }

        [JsonPropertyName("suite")]
        public string Suite { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("zipcode")]
        public string Zipcode { get; set; }

        [JsonPropertyName("geo")]
        public ExternalUserAddressGeoDataDTO Geo { get; set; }
    }

    /// <summary>
    /// Класс-модель для представления данных о геопозиции адреса пользователя из внешнего источника
    /// </summary>
    public record ExternalUserAddressGeoDataDTO
    {
        [JsonPropertyName("lat")]
        public string Lat { get; set; }

        [JsonPropertyName("lng")]
        public string Lng { get; set; }
    }

    /// <summary>
    /// Класс-модель для представления данных о компании пользователя из внешнего источника
    /// </summary>
    public record ExternalUserCompanyDataDTO
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("catchPhrase")]
        public string CatchPhrase { get; set; }

        [JsonPropertyName("bs")]
        public string Bs { get; set; }
    }
}
