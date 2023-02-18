using System.Text.Json.Serialization;

namespace TestIntegration.API.Models
{
    /// <summary>
    /// Класс-модель для представления данных о пользователе
    /// </summary>
    public record UserDataFullDTO : UserDataBaseDTO
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }
        
        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("website")]
        public string Website { get; set; }

        [JsonPropertyName("address")]
        public UserAddressDataDTO Address { get; set; }

        [JsonPropertyName("company")]
        public UserCompanyDataDTO Company { get; set; }

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
        public string Street { get; set; }

        [JsonPropertyName("suite")]
        public string Suite { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("zipcode")]
        public string Zipcode { get; set; }

        [JsonPropertyName("geo")]
        public UserAddressGeoDataDTO Geo { get; set; }
    }

    /// <summary>
    /// Класс-модель для представления данных о геопозиции адреса пользователя
    /// </summary>
    public record UserAddressGeoDataDTO
    {
        [JsonPropertyName("lat")]
        public string Lat { get; set; }

        [JsonPropertyName("lng")]
        public string Lng { get; set; }
    }

    /// <summary>
    /// Класс-модель для представления данных о компании пользователя
    /// </summary>
    public record UserCompanyDataDTO
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("catchPhrase")]
        public string CatchPhrase { get; set; }

        [JsonPropertyName("bs")]
        public string Bs { get; set; }
    }
}
