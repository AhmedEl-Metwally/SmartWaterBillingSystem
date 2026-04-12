using Mapster;
using MediatR;
using SmartWaterBillingSystem.Application.Common.Models;
using SmartWaterBillingSystem.Application.Contracts.Repositorys;
using SmartWaterBillingSystem.Application.DTOS;
using SmartWaterBillingSystem.Domain.Entities;
using SmartWaterBillingSystem.Domain.Specifications;

namespace SmartWaterBillingSystem.Application.Commands.Invoices.PendingInvoices
{
    public class GetPendingInvoicesHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetPendingInvoicesQuery, Result<IEnumerable<InvoiceDto>>>
    {
        public async Task<Result<IEnumerable<InvoiceDto>>> Handle(GetPendingInvoicesQuery request, CancellationToken cancellationToken)
        {
            var specification = new PendingInvoicesSpecification(request.SubscriptionNumber);
            var invoices = await _unitOfWork.GetRepository<Invoice>().GetWithSpecificationAsync(specification);

            var paidIndicators = new[] { "Paid", "Cash", "Visa", "Fawry", "Paid", "Cleared" };

            var pendingInvoices = invoices.Where(i => string.IsNullOrEmpty(i.InvoicesNote) ||
                    !paidIndicators.Any(indicator => i.InvoicesNote.Contains(indicator, StringComparison.OrdinalIgnoreCase))).ToList();

            return Result<IEnumerable<InvoiceDto>>.Success(pendingInvoices.Adapt<IEnumerable<InvoiceDto>>());

        }
    }
}
