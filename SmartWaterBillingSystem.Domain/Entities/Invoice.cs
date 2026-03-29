namespace SmartWaterBillingSystem.Domain.Entities
{
    public class Invoice
    {
        public string InvoiceNumber { get; set; } = string.Empty;
        public string FiscalYear { get; set; } = string.Empty;
        public DateTime InvoiceDate { get; set; }
        public DateTime FromTheDateOf { get; set; }
        public DateTime FromTheDateTo { get; set; }
        public int PreviousConsumptionAmount { get; set; }
        public int CurrentConsumptionAmount { get; set; }
        public int AmountOfConsumption { get; set; }
        public decimal ServiceFee { get; set; }
        public decimal TaxFee { get; set; }
        public bool SanitationIsAvailable { get; set; }
        public decimal TheValueOfWaterConsumption { get; set; }
        public decimal WasteWaterConsumptionValue { get; set; }
        public decimal TotalInvoice { get; set; }
        public decimal TaxValue { get; set; }
        public decimal TotalBill { get; set; }
        public string InvoicesNote { get; set; } = string.Empty;

        public string HouseType { get; set; } = string.Empty;
        public TypesOfRealEstate RealEstateType { get; set; } = null!;
        public string SubscriptionNumber { get; set; } = string.Empty;
        public Subscription Subscription { get; set; } = null!;
        public string SubscriberNumber { get; set; } = string.Empty;
        public Subscriber Subscriber { get; set; } = null!;

    }
}
