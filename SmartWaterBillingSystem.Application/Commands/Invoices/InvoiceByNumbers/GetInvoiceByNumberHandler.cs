using Mapster;
using MediatR;
using SmartWaterBillingSystem.Application.Common.Models;
using SmartWaterBillingSystem.Application.Contracts.Repositorys;
using SmartWaterBillingSystem.Application.DTOS.Invoice;
using SmartWaterBillingSystem.Domain.Entities;
using SmartWaterBillingSystem.Domain.Specifications.Invoices;

namespace SmartWaterBillingSystem.Application.Commands.Invoices.InvoiceByNumbers
{
    public class GetInvoiceByNumberHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetInvoiceByNumberQuery, Result<InvoiceDto>>
    {
        public async Task<Result<InvoiceDto>> Handle(GetInvoiceByNumberQuery request, CancellationToken cancellationToken)
        {
            var specification = new InvoiceByNumberSpecification(request.InvoiceNumber);
            //var invoice = await _unitOfWork.GetRepository<Invoice>().GetWithSpecificationAsync(specification);
            var invoice = await _unitOfWork.GetRepository<Invoice>().GetEntityWithSpecificationAsync(specification);

            if (invoice == null)
                return Result<InvoiceDto>.Failure("InvoiceNotFound", $"No invoice found with number {request.InvoiceNumber}", ErrorType.NotFound);

            return Result<InvoiceDto>.Success(invoice.Adapt<InvoiceDto>());
        }
    }
}
