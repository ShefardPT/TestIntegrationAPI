﻿using TestIntegration.API.Models;

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
        Task<IOperationResult> AuthorizeAsync(HttpContext httpContext);
    }
}
