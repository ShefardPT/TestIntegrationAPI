namespace TestIntegration.API.Models
{
    /// <summary>
    /// Класс-модель для представления данных о запросе данных о пользователях
    /// </summary>
    public record UsersInformationRequestRecordDTO
    {
        /// <summary>
        /// Логин пользователя, запрашивающего данные
        /// </summary>
        public string? Login { get; set; }

        /// <summary>
        /// Дата-время запроса данных
        /// </summary>
        public DateTime RequestedOn { get; set; }
    }
}
