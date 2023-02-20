using Microsoft.AspNetCore.Mvc;
using TestIntegration.API.Models;
using TestIntegration.API.Services;

namespace TestIntegration.API.Controllers
{
    /// <summary>
    /// Класс-контроллер получения информации о пользователях
    /// </summary>
    [Route("api/users")]
    [ApiController]
    public class GetUsersController : ControllerBase
    {
        private readonly ILogger<GetUsersController> _logger;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUsersInformationService _usersInformationService;
        private readonly IUsersInformationRequestLogger _requestLogger;

        public GetUsersController(
            ILogger<GetUsersController> logger,
            IAuthorizationService authorizationService, 
            IUsersInformationService usersInformationService, 
            IUsersInformationRequestLogger requestLogger)
        {
            _logger = logger;
            _authorizationService = authorizationService;
            _usersInformationService = usersInformationService;
            _requestLogger = requestLogger;
        }

        /// <summary>
        /// Получить список пользователей
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var authorizationResult = await _authorizationService.AuthorizeAsync(HttpContext);

                await _requestLogger.LogRequestAsync(authorizationResult);
                
                IOperationResult result;
                if (authorizationResult.IsSuccess)
                {
                    result = await _usersInformationService.GetUsersFullInfoAsync();
                }
                else
                {
                    result = await _usersInformationService.GetUsersShortInfoAsync();
                }

                if (result.IsSuccess)
                {
                    return Ok(result); 
                }
                else
                {
                    return StatusCode(500, result);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.ToString());
                return StatusCode(500, ex.Message);
            }
        }
    }
}