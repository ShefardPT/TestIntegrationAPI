using Microsoft.AspNetCore.Authorization;
using TestIntegration.API.Models;

namespace TestIntegration.API.Services
{
    /// <summary>
    /// Класс-сервис реализации авторизации через проверку заголовка
    /// </summary>
    public class HeaderAuthorizationService : IAuthorizationService
    {
        private readonly ILogger<HeaderAuthorizationService> _logger;
        private readonly IUsersInformationIntegrationService _infoService;

        public HeaderAuthorizationService(
            ILogger<HeaderAuthorizationService> logger,
            IUsersInformationIntegrationService infoService)
        {
            _logger = logger;
            _infoService = infoService;
        }

        /// <inheritdoc />
        public async Task<IOperationResult> AuthorizeAsync(HttpContext httpContext)
        {
            var credentials = GetCredentialsFromHeaders(httpContext.Request.Headers);

            if (credentials == null)
            {
                return OperationResult.Failed("Учетные данные не представлены.");
            }

            var usersData = await _infoService.GetUsersAsync();
            var usersDataDict = usersData
                .ToDictionary(x => x.Email, x => x);

            if (usersDataDict.TryGetValue(credentials.Email, out var user) &&
                user.Phone == credentials.Phone)
            {
                return OperationResult.Successed();
            }
            else
            {
                return OperationResult.Failed("Данного пользователя не существует или пароль не вереню");
            }
        }

        /// <summary>
        /// Получить учетные данные из заголовков
        /// </summary>
        private HeaderAuthorizationCredentials GetCredentialsFromHeaders(IHeaderDictionary headers)
        {
            var isLogin = headers.TryGetValue("email", out var email);
            var isPassword = headers.TryGetValue("phone", out var phone);

            if (isLogin && isPassword)
            {
                return new HeaderAuthorizationCredentials()
                {
                    Email = email,
                    Phone = phone
                };
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Класс-модель представления учетных данных для авторизации через проверку заголовка
        /// </summary>
        private record HeaderAuthorizationCredentials
        {
            public string Email { get; init; }
            public string Phone { get; init; }
        }
    }
}