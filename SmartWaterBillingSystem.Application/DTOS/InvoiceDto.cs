namespace SmartWaterBillingSystem.Application.DTOS
{
    public record InvoiceDto
    {
        public string InvoiceNumber { get; init; } = string.Empty;
        public string SubscriptionNumber { get; init; } = string.Empty;
        public DateTime InvoiceDate { get; init; }
        public int AmountOfConsumption { get; init; }
        public decimal TheValueOfWaterConsumption { get; init; }
        public decimal WasteWaterConsumptionValue { get; init; }
        public decimal ServiceFee { get; init; }
        public decimal TaxValue { get; init; }
        public decimal TotalBill { get; init; }

    }
}
