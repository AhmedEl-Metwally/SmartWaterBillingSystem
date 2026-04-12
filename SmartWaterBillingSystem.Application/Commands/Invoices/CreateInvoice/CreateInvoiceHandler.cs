using Mapster;
using MediatR;
using SmartWaterBillingSystem.Application.Common.Models;
using SmartWaterBillingSystem.Application.Contracts.Repositorys;
using SmartWaterBillingSystem.Application.DTOS;
using SmartWaterBillingSystem.Domain.Entities;
using SmartWaterBillingSystem.Domain.Specifications;

namespace SmartWaterBillingSystem.Application.Commands.Invoices.CreateInvoice
{
    public class CreateInvoiceHandler(IUnitOfWork _unitOfWork) : IRequestHandler<CreateInvoiceCommand, Result<InvoiceDto>>
    {
        public async Task<Result<InvoiceDto>> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var subscriptionSpecification = new SubscriptionWithDetailsSpecification(request.SubscriptionNumber);
            var subscription = await _unitOfWork.GetRepository<Subscription>().GetEntityWithSpecificationAsync(subscriptionSpecification);
            if (subscription == null)
                return CreateError("NotFound", "Subscription not found", ErrorType.NotFound);

            var slideDistribution = await GetOrderedSlabsAsync(subscription.HouseType);
            if (!slideDistribution.Any())
                return CreateError("SlideDistributionMissing", "Slide distribution not found", ErrorType.Failure);

            int consumption = request.CurrentReading - subscription.TheLastReadingOfTheMeter;
            if (consumption < 0)
                return CreateError("InvalidReading", "Current reading cannot be less than the last reading", ErrorType.ValidationError);

            decimal perUnit = (decimal)consumption / subscription.TheNumberOfFloorsOfTheHouse;
            decimal waterValue = CalculateWaterValue(slideDistribution, perUnit) * subscription.TheNumberOfFloorsOfTheHouse;
            decimal serviceFee = GetServiceFee(slideDistribution, perUnit) * subscription.TheNumberOfFloorsOfTheHouse;
            decimal finalTotal = CalculateFinalBill(waterValue, serviceFee, request.CurrencyRate);

            int nextSequenceValue = await _unitOfWork.GetNextSequenceValueAsync("InvoiceNumbersSequence");
            string generatedInvoiceNumber = $"INV{DateTime.Now.Year}{nextSequenceValue.ToString("D3")}";
            var invoice = MapToInvoice(request, subscription, consumption, waterValue, serviceFee, finalTotal, generatedInvoiceNumber);

            await _unitOfWork.GetRepository<Invoice>().AddAsync(invoice);
            subscription.TheLastReadingOfTheMeter = request.CurrentReading;
            await _unitOfWork.SaveChangesAsync();

            return new Result<InvoiceDto> { IsSuccess = true, Value = invoice.Adapt<InvoiceDto>() };
        }


        // Helper Methods

        private Result<InvoiceDto> CreateError(string code, string message, ErrorType type)
            => new()
            {
                IsSuccess = false,
                Errors = [new ErrorDetails(code, message, type)]
            };

        private async Task<IEnumerable<SlideDistribution>> GetOrderedSlabsAsync(string houseType)
        {
            var slideDistributionSpecification = new SlideDistributionSpecification(houseType);
            return await _unitOfWork.GetRepository<SlideDistribution>().GetWithSpecificationAsync(slideDistributionSpecification);
        }

        private decimal CalculateWaterValue(IEnumerable<SlideDistribution> slides, decimal consumptionPerUnit)
        {
            decimal waterSum = 0;
            decimal lastLimit = 0;
            decimal remaining = consumptionPerUnit;

            foreach (var slide in slides)
            {
                if (remaining <= 0) break;

                decimal slabCapacity = slide.AmountExpenditureSlide - lastLimit;
                decimal consumedInSlab = Math.Min(remaining, slabCapacity);

                waterSum += consumedInSlab * slide.PricePerCubicMeterOfWater;
                lastLimit = slide.AmountExpenditureSlide;
                remaining -= consumedInSlab;
            }
            return waterSum;
        }

        private decimal GetServiceFee(IEnumerable<SlideDistribution> slides, decimal consumption)
            => slides.FirstOrDefault(S => consumption <= S.AmountExpenditureSlide)?.PriceServiceSewage ?? 0;

        private decimal CalculateFinalBill(decimal waterValue, decimal serviceFee, decimal rate)
        {
            decimal sewage = waterValue * 0.50m;
            decimal subTotal = waterValue + sewage + serviceFee;
            return Math.Round(subTotal * 1.14m * rate, 2);
        }

        private Invoice MapToInvoice(CreateInvoiceCommand create, Subscription subscription, int consumption, decimal water, decimal service, decimal total, string? invoiceNumber)
        {
            return new Invoice
            {
                SubscriptionNumber = create.SubscriptionNumber.ToUpper(),
                InvoiceNumber = invoiceNumber,
                SubscriberNumber = subscription.SubscriberNumber,
                HouseType = subscription.HouseType,
                AmountOfConsumption = consumption,
                TheValueOfWaterConsumption = water,
                WasteWaterConsumptionValue = water * 0.50m,
                ServiceFee = service,
                TotalBill = total,
                TotalInvoice = total,
                InvoiceDate = DateTime.Now,
                FromTheDateOf = create.FromTheDateOf,
                FromTheDateTo = create.FromTheDateTo,
                FiscalYear = create.FromTheDateTo.Year.ToString().Substring(2),
                PreviousConsumptionAmount = subscription.TheLastReadingOfTheMeter,
                CurrentConsumptionAmount = create.CurrentReading
            };
        }

    }
}
