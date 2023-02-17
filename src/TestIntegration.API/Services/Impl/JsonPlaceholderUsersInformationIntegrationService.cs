using TestIntegration.API.Models;

namespace TestIntegration.API.Services.Impl
{
    public class JsonPlaceholderUsersInformationIntegrationService : IUsersInformationIntegrationService
    {
        private readonly ILogger<JsonPlaceholderUsersInformationIntegrationService> _logger;
        private readonly HttpClient _httpClient;

        public JsonPlaceholderUsersInformationIntegrationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<ExternalUserDataDTO[]> GetUsersAsync()
        {
            throw new NotImplementedException();
        }
    }
}
