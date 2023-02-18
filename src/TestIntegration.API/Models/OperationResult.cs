using System.Text.Json.Serialization;

namespace TestIntegration.API.Models
{
    /// <summary>
    /// Результат операции
    /// </summary>
    public record OperationResult : IOperationResult
    {
        /// <summary>
        /// Признак успешности выполнения операции
        /// </summary>
        [JsonPropertyName("isSuccess")]
        public bool IsSuccess => Errors.Count == 0;

        /// <summary>
        /// Ошибки выполнения операции
        /// </summary>
        [JsonPropertyName("errors")]
        public List<string> Errors { get; init; } = new List<string>();

        IEnumerable<string> IOperationResult.Errors => Errors;

        /// <summary>
        /// Успешный результат
        /// </summary>
        public static OperationResult Successed()
        {
            return new OperationResult();
        }

        /// <summary>
        /// Неуспешный результат
        /// </summary>
        /// <returns></returns>
        public static OperationResult Failed()
        {
            return new OperationResult() { Errors = new List<string>() { "Произошла ошибка при выполнении операции." } };
        }

        /// <summary>
        /// Неуспешный результат с указанием причин
        /// </summary>
        /// <returns></returns>
        public static OperationResult Failed(params string[] errors)
        {
            return new OperationResult() { Errors = errors.ToList() };
        }

        /// <summary>
        /// Неуспешный результат с указанием причин
        /// </summary>
        /// <returns></returns>
        public static OperationResult Failed(IEnumerable<string> errors)
        {
            return new OperationResult() { Errors = errors.ToList() };
        }
    }

    /// <summary>
    /// Результат операции
    /// </summary>
    public record OperationDataResult<T> : OperationResult, IOperationResult<T>
    {
        /// <summary>
        /// Данные результат операции
        /// </summary>
        [JsonPropertyName("data")]
        public T? Data { get; init; }

        /// <summary>
        /// Успешный результат
        /// </summary>
        public new static OperationDataResult<T> Successed(T data)
        {
            return new OperationDataResult<T>() { Data = data };
        }

        /// <summary>
        /// Неуспешный результат
        /// </summary>
        /// <returns></returns>
        public new static OperationDataResult<T> Failed()
        {
            return new OperationDataResult<T> { Errors = new List<string>() { "Произошла ошибка при выполнении операции." } };
        }

        /// <summary>
        /// Неуспешный результат с указанием причин
        /// </summary>
        /// <returns></returns>
        public new static OperationDataResult<T> Failed(params string[] errors)
        {
            return new OperationDataResult<T> { Errors = errors.ToList() };
        }

        /// <summary>
        /// Неуспешный результат с указанием причин
        /// </summary>
        /// <returns></returns>
        public new static OperationDataResult<T> Failed(IEnumerable<string> errors)
        {
            return new OperationDataResult<T>() { Errors = errors.ToList() };
        }
    }
}
