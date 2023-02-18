using TestIntegration.API.Models;

namespace TestIntegration.API.Services
{
    /// <inheritdoc />
    public class UsersInformationService : IUsersInformationService
    {
        private readonly IUsersInformationIntegrationService _integrationService;

        public UsersInformationService(
            IUsersInformationIntegrationService integrationService)
        {
            _integrationService = integrationService;
        }

        /// <inheritdoc />
        public async Task<IOperationResult<UserDataBaseDTO[]>> GetUsersShortInfoAsync()
        {
            var dataResult = await _integrationService.GetUsersAsync();
            if (!dataResult.IsSuccess)
            {
                return OperationDataResult<UserDataBaseDTO[]>.Failed(dataResult.Errors);
            }

            var result = dataResult.Data
                .Select(UserDataBaseDTO.ParseFromExternalDTO)
                .ToArray();

            return OperationDataResult<UserDataBaseDTO[]>.Successed(result);
        }
        
        /// <inheritdoc />
        public async Task<IOperationResult<UserDataFullDTO[]>> GetUsersFullInfoAsync()
        {
            var dataResult = await _integrationService.GetUsersAsync();
            if (!dataResult.IsSuccess)
            {
                return OperationDataResult<UserDataFullDTO[]>.Failed(dataResult.Errors);
            }

            var result = dataResult.Data
                .Select(UserDataFullDTO.ParseFromExternalDTO)
                .ToArray();

            return OperationDataResult<UserDataFullDTO[]>.Successed(result);
        }
    }
}
