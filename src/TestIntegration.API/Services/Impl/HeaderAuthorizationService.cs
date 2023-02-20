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
        public async Task<AuthorizationResult> AuthorizeAsync(HttpContext httpContext)
        {
            var credentials = GetCredentialsFromHeaders(httpContext.Request.Headers);

            if (credentials == null)
            {
                return AuthorizationResult.Failed("Учетные данные не представлены.");
            }

            var usersDataResult = await _infoService.GetUsersAsync();

            if (!usersDataResult.IsSuccess)
            {
                return AuthorizationResult.Failed(usersDataResult.Errors);
            }

            var usersDataDict = usersDataResult.Data
                .ToDictionary(x => x.Email, x => x.Phone);

            if (usersDataDict.TryGetValue(credentials.Email, out var phone) &&
                phone == credentials.Phone)
            {
                return AuthorizationResult.Successed(new AuthorizedUserInformation()
                {
                    Login = credentials.Email
                });
            }
            else
            {
                return new AuthorizationResult()
                {
                    User = new AuthorizedUserInformation()
                    {
                        Login = credentials.Email
                    },
                    Errors = new List<string>() { "Данного пользователя не существует или пароль не верен." }
                };
            }
        }

        /// <summary>
        /// Получить учетные данные из заголовков
        /// </summary>
        private HeaderAuthorizationCredentials GetCredentialsFromHeaders(IHeaderDictionary headers)
        {
            var isLogin = headers.TryGetValue("login", out var email);
            var isPassword = headers.TryGetValue("password", out var phone);

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