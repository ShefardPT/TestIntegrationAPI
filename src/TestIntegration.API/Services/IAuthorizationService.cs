using Microsoft.AspNetCore.Authorization;

namespace TestIntegration.API.Services
{
    /// <summary>
    /// Класс-сервис авторизации
    /// </summary>
    public interface IAuthorizationService
    {
        /// <summary>
        /// Провести авторизацию
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns>Результат авторизации</returns>
        Task<AuthorizationResult> AuthorizeAsync(HttpContext httpContext);
    }
}
