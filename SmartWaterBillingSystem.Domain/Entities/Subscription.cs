namespace SmartWaterBillingSystem.Domain.Entities
{
    public class Subscription       
    {
        public string SubscriptionNumber { get; set; } = string.Empty;
        public int TheNumberOfFloorsOfTheHouse { get; set; }
        public bool IsThereSanitation { get; set; }
        public int TheLastReadingOfTheMeter { get; set; }
        public string SubscriptionNote { get; set; } = string.Empty;

        public string SubscriberNumber { get; set; } = string.Empty;
        public Subscriber Subscriber { get; set; } = null!;
        public string HouseType { get; set; } = string.Empty;   
        public TypesOfRealEstate TypesOfRealEstate { get; set; } = null!;
        public ICollection<Invoice> Invoices { get; set; } = [];
    }
}
