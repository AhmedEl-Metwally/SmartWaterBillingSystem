namespace SmartWaterBillingSystem.Client.Client.Common
{
    public class ApiErrorDetails
    {
        public string Code { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public int Type { get; set; }
    }
}