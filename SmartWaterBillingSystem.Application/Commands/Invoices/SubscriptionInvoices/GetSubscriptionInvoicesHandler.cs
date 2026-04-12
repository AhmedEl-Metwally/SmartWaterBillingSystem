using Mapster;
using MediatR;
using SmartWaterBillingSystem.Application.Common.Models;
using SmartWaterBillingSystem.Application.Contracts.Repositorys;
using SmartWaterBillingSystem.Application.DTOS;
using SmartWaterBillingSystem.Domain.Entities;
using SmartWaterBillingSystem.Domain.Specifications;

namespace SmartWaterBillingSystem.Application.Commands.Invoices.SubscriptionInvoices
{
    public class GetSubscriptionInvoicesHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetSubscriptionInvoicesQuery, Result<IEnumerable<InvoiceDto>>>
    {
        public async Task<Result<IEnumerable<InvoiceDto>>> Handle(GetSubscriptionInvoicesQuery request, CancellationToken cancellationToken)
        {
            var specification = new InvoicesBySubscriptionSpecification(request.SubscriptionNumber);
            var invoices = await _unitOfWork.GetRepository<Invoice>().GetWithSpecificationAsync(specification);
            return Result<IEnumerable<InvoiceDto>>.Success(invoices.Adapt<IEnumerable<InvoiceDto>>());
        }
    }
}
