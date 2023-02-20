namespace TestIntegration.API.Models
{
    /// <summary>
    /// Класс-модель для представления данных об авторизуемом пользователе
    /// </summary>
    public record AuthorizedUserInformation
    {
        /// <summary>
        /// Логин авторизуемого пользователя
        /// </summary>
        public string Login { get; init; }
    }
}
