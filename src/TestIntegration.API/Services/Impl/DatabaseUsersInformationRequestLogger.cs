using TestIntegration.API.DataAccess;
using TestIntegration.API.DataAccess.Entities;
using TestIntegration.API.Models;

namespace TestIntegration.API.Services
{
    /// <summary>
    /// Реализация сервиса по журналированию информации о запросах данных пользователей с записью информации в базу данных
    /// </summary>
    public class DatabaseUsersInformationRequestLogger : IUsersInformationRequestLogger
    {
        private readonly AppDbContext _appDbContext;

        public DatabaseUsersInformationRequestLogger(
            AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        /// <inheritdoc />>
        public async Task LogRequestAsync(AuthorizationResult authResult)
        {
            var item = new UsersDataRequestRecord()
            {
                Login = authResult.User?.Login,
                RequestedOn = DateTime.UtcNow
            };

            _appDbContext.Add(item);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
