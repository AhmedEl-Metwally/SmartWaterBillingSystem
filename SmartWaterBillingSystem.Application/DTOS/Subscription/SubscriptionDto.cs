namespace SmartWaterBillingSystem.Application.DTOS.Subscription
{
    public record SubscriptionDto(string SubscriptionNumber, int TheNumberOfFloorsOfTheHouse, bool IsThereSanitation, int TheLastReadingOfTheMeter, string SubscriptionNote, string SubscriberNumber, string HouseType);

}
