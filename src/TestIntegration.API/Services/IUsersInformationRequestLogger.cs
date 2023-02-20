using TestIntegration.API.Models;

namespace TestIntegration.API.Services
{
    public interface IUsersInformationRequestLogger
    {
        Task LogRequestAsync(AuthorizationResult authResult);
    }
}
