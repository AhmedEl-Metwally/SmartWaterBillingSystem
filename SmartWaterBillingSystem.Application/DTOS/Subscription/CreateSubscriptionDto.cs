namespace SmartWaterBillingSystem.Application.DTOS.Subscription
{
    public record CreateSubscriptionDto(int TheNumberOfFloorsOfTheHouse, bool IsThereSanitation, int TheLastReadingOfTheMeter, string SubscriptionNote, string SubscriberNumber, string HouseType);

}
