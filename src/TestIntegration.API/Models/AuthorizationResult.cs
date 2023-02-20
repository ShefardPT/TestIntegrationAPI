namespace TestIntegration.API.Models
{
    public record AuthorizationResult : OperationResult
    {
        public AuthorizedUserInformation User { get; init; }

        /// <summary>
        /// Успешный результат
        /// </summary>
        public static AuthorizationResult Successed(AuthorizedUserInformation user)
        {
            return new AuthorizationResult()
            {
                User = user
            };
        }

        /// <summary>
        /// Неуспешный результат с указанием причин
        /// </summary>
        /// <returns></returns>
        public new static AuthorizationResult Failed(params string[] errors)
        {
            return new AuthorizationResult() { Errors = errors.ToList() };
        }

        /// <summary>
        /// Неуспешный результат с указанием причин
        /// </summary>
        /// <returns></returns>
        public new static AuthorizationResult Failed(IEnumerable<string> errors)
        {
            return new AuthorizationResult() { Errors = errors.ToList() };
        }
    }
}
