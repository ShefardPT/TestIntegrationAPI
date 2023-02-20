using System.Text.Json.Serialization;

namespace TestIntegration.API.Models
{
    /// <summary>
    /// Класс-модель для представления данных о пользователе
    /// </summary>
    public record UserDataFullDTO : UserDataBaseDTO
    {
        [JsonPropertyName("id")]
        public long Id { get; init; }

        [JsonPropertyName("username")]
        public string Username { get; init; }
        
        [JsonPropertyName("phone")]
        public string Phone { get; init; }

        [JsonPropertyName("website")]
        public string Website { get; init; }

        [JsonPropertyName("address")]
        public UserAddressDataDTO Address { get; init; }

        [JsonPropertyName("company")]
        public UserCompanyDataDTO Company { get; init; }

        /// <summary>
        /// Преобразовать модель данных из внешнего источника
        /// </summary>
        /// <param name="external"></param>
        /// <returns></returns>
        public static UserDataFullDTO ParseFromExternalDTO(ExternalUserDataDTO external)
        {
            return new UserDataFullDTO()
            {
                Id = external.Id,
                Name = external.Name,
                Username = external.Username,
                Email = external.Email,
                Phone = external.Phone,
                Website = external.Website,
                Address = new UserAddressDataDTO()
                {
                    Street = external.Address.Street,
                    City = external.Address.City,
                    Suite = external.Address.Suite,
                    Zipcode = external.Address.Zipcode,
                    Geo = new UserAddressGeoDataDTO()
                    {
                        Lat = external.Address.Geo.Lat,
                        Lng = external.Address.Geo.Lng
                    }
                },
                Company = new UserCompanyDataDTO()
                {
                    Name = external.Company.Name,
                    CatchPhrase = external.Company.CatchPhrase,
                    Bs = external.Company.Bs
                }
            };
        }
    }

    /// <summary>
    /// Класс-модель для представления данных об адресе пользователя
    /// </summary>
    public record UserAddressDataDTO
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
        public UserAddressGeoDataDTO Geo { get; init; }
    }

    /// <summary>
    /// Класс-модель для представления данных о геопозиции адреса пользователя
    /// </summary>
    public record UserAddressGeoDataDTO
    {
        [JsonPropertyName("lat")]
        public string Lat { get; init; }

        [JsonPropertyName("lng")]
        public string Lng { get; init; }
    }

    /// <summary>
    /// Класс-модель для представления данных о компании пользователя
    /// </summary>
    public record UserCompanyDataDTO
    {
        [JsonPropertyName("name")]
        public string Name { get; init; }

        [JsonPropertyName("catchPhrase")]
        public string CatchPhrase { get; init; }

        [JsonPropertyName("bs")]
        public string Bs { get; init; }
    }
}
