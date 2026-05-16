namespace SmartWaterBillingSystem.Application.DTOS.Subscriber
{
    public record CreateSubscriberDto(string PersonalIDNumber, string SubscriberName, string SubscriberGovernorate, string SubscriberArea, string SubscriberPhoneNumber, string SubscriberNote);

}
