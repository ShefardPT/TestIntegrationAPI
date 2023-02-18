﻿using TestIntegration.API.Models;

namespace TestIntegration.API.Services
{
    /// <summary>
    /// Класс-сервис  для получения информации о пользователях
    /// </summary>
    public interface IUsersInformationService
    {
        /// <summary>
        /// Получить информацию о пользователях в кратком виде
        /// </summary>
        Task<IOperationResult<UserDataBaseDTO[]>> GetUsersShortInfoAsync();

        /// <summary>
        /// Получить информацию о пользователях в полном виде
        /// </summary>
        Task<IOperationResult<UserDataFullDTO[]>> GetUsersFullInfoAsync();
    }
}
