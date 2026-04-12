namespace SmartWaterBillingSystem.Application.Common.Models
{
    public class Result<T>
    {
        public bool IsSuccess { get; set; }
        public T? Value { get; set; }
        public List<ErrorDetails> Errors { get; set; } = [];

        public static Result<T> Success(T Value) => new() {IsSuccess = true, Value = Value };

        public static Result<T> Failure(string code, string message, ErrorType type) => new()
        {
            IsSuccess = false,
            Errors = [new ErrorDetails(code,message,type)]
        };
    }
}
