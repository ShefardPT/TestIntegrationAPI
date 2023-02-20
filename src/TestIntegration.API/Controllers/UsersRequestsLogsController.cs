using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestIntegration.API.DataAccess;
using TestIntegration.API.Models;

namespace TestIntegration.API.Controllers
{
    /// <summary>
    /// Класс-контроллер для получение журнала запросов данных о пользователях
    /// </summary>
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/users/logs")]
    [ApiController]
    public class UsersRequestsLogsController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public UsersRequestsLogsController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetLogsAsync(
            [FromQuery] DateTime? requestedFrom,
            [FromQuery] DateTime? requestedTo,
            [FromQuery] string? userLogin)
        {
            var query = _appDbContext.UsersDataRequestRecords
                .AsNoTracking();

            if (requestedFrom.HasValue)
            {
                query = query.Where(x => requestedFrom.Value <= x.RequestedOn);
            }

            if (requestedTo.HasValue)
            {
                query = query.Where(x => x.RequestedOn <= requestedTo.Value);
            }

            if (!string.IsNullOrWhiteSpace(userLogin))
            {
                query = query.Where(x => EF.Functions.ILike(x.Login, $"%{userLogin}%"));
            }

            var logs = await query
                .Select(x => new UsersInformationRequestRecordDTO()
                {
                    Login = x.Login,
                    RequestedOn = x.RequestedOn
                })
                .ToArrayAsync();
            
            return Ok(logs);
        }
    }
}
