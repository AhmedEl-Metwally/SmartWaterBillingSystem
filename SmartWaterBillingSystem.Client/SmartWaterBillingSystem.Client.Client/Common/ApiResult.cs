namespace SmartWaterBillingSystem.Client.Client.Common
{
    public class ApiResult<T>
    {
        public bool IsSuccess { get; set; }
        public T? Value { get; set; }
        public List<ApiErrorDetails> Errors { get; set; } = [];
    }
}
