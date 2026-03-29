namespace SmartWaterBillingSystem.Domain.Entities
{
    public class Subscriber
    {
        public string PersonalIDNumber { get; set; } = string.Empty;
        public string SubscriberName { get; set; } = string.Empty;
        public string SubscriberGovernorate { get; set; } = string.Empty;
        public string SubscriberArea { get; set; } = string.Empty;
        public string SubscriberPhoneNumber { get; set; } = string.Empty;
        public string SubscriberNote { get; set; } = string.Empty;

        public ICollection<Subscription> Subscriptions { get; set; } = [];
    }
}
