using TestIntegration.API.Models;

namespace TestIntegration.API.Services
{
    /// <summary>
    /// Класс-сервис по журналированию информации о запросах данных пользователей
    /// </summary>
    public interface IUsersInformationRequestLogger
    {
        /// <summary>
        /// Записать информацию о запросе данных пользователей
        /// </summary>
        Task LogRequestAsync(AuthorizationResult authResult);
    }
}
