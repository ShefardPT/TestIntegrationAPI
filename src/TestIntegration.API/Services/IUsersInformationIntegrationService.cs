using TestIntegration.API.Models;

namespace TestIntegration.API.Services
{
    /// <summary>
    /// Класс-сервис интеграции для получения данных о пользователях
    /// </summary>
    public interface IUsersInformationIntegrationService
    {
        /// <summary>
        /// Получить данные о пользователях
        /// </summary>
        /// <returns></returns>
        Task<IOperationResult<ExternalUserDataDTO[]>> GetUsersAsync();
    }
}
