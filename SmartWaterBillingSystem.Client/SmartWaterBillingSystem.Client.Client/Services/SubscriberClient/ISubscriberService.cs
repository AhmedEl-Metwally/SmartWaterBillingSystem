namespace SmartWaterBillingSystem.Client.Client.Services.SubscriberClient
{
    public interface ISubscriberService
    {
        Task<Result<string>> CreateSubscriberAsync(CreateSubscriberClientDto createSubscriber);
        Task<Result<SubscriberClientDto>> GetSubscriberByIdAsync(string subscriberId);
        Task<Result<bool>> DeleteSubscriberAsync(string subscriberId);
    }
}
