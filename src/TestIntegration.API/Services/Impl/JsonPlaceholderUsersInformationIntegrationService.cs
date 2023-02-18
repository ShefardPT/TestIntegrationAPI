using System.Text.Json;
using TestIntegration.API.Models;

namespace TestIntegration.API.Services.Impl
{
    public class JsonPlaceholderUsersInformationIntegrationService : IUsersInformationIntegrationService
    {
        private readonly ILogger<JsonPlaceholderUsersInformationIntegrationService> _logger;
        private readonly HttpClient _httpClient;

        public JsonPlaceholderUsersInformationIntegrationService(
            ILogger<JsonPlaceholderUsersInformationIntegrationService> logger,
            HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task<IOperationResult<ExternalUserDataDTO[]>> GetUsersAsync()
        {
            string usersJsonString;
            {
                using var request = new HttpRequestMessage(HttpMethod.Get, "https://jsonplaceholder.typicode.com/users");
                using var response = await _httpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    return OperationDataResult<ExternalUserDataDTO[]>
                        .Failed("Источник данных не вернул успешного ответа на запрос.");
                }

                usersJsonString = await response.Content.ReadAsStringAsync();
            }

            ExternalUserDataDTO[] result;
            try
            {
                result = JsonSerializer.Deserialize<ExternalUserDataDTO[]>(usersJsonString);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.ToString());

                return OperationDataResult<ExternalUserDataDTO[]>
                    .Failed(
                        "Источник данных вернул данные в неожиданном формате.",
                        ex.ToString());
            }

            if (result == null)
            {
                return OperationDataResult<ExternalUserDataDTO[]>
                    .Failed("Источник данных вернул данные в неожиданном формате.");
            }

            return OperationDataResult<ExternalUserDataDTO[]>.Successed(result);
        }
    }
}
