using SmartWaterBillingSystem.Domain.Entities;

namespace SmartWaterBillingSystem.Application.Contracts.PDF
{
    public interface IPdfService
    {
        Task<byte[]> GeneratePdfAsync(Invoice invoice, string subscriberName);
    }
}
