using Microsoft.AspNetCore.Mvc;
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

        public GetUsersController(
            ILogger<GetUsersController> logger,
            IAuthorizationService authorizationService, 
            IUsersInformationService usersInformationService)
        {
            _logger = logger;
            _authorizationService = authorizationService;
            _usersInformationService = usersInformationService;
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

                object result;
                if (authorizationResult.IsSuccess)
                {
                    result = await _usersInformationService.GetUsersFullInfoAsync();
                }
                else
                {
                    result = await _usersInformationService.GetUsersShortInfoAsync();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.ToString());
                return StatusCode(500, ex.ToString());
            }
        }
    }
}