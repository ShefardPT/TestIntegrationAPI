using System.Text.Json.Serialization;

namespace TestIntegration.API.Models
{
    /// <summary>
    /// Результат операции
    /// </summary>
    public interface IOperationResult
    {
        /// <summary>
        /// Признак успешности выполнения операции
        /// </summary>
        bool IsSuccess { get; }

        /// <summary>
        /// Ошибки выполнения операции
        /// </summary>
        IEnumerable<string> Errors { get; }
    }

    /// <summary>
    /// Результат операции
    /// </summary>
    public interface IOperationResult<T> : IOperationResult
    {
        /// <summary>
        /// Данные результат операции
        /// </summary>
        T Data { get; }
    }
}
