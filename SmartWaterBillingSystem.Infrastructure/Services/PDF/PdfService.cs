using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SmartWaterBillingSystem.Application.Contracts.PDF;
using SmartWaterBillingSystem.Domain.Entities;

namespace SmartWaterBillingSystem.Infrastructure.Services.PDF
{
    public class PdfService : IPdfService
    {
        public async Task<byte[]> GeneratePdfAsync(Invoice invoice, string subscriberName)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            var document = Document.Create(container =>
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(1, Unit.Centimetre);
                    page.DefaultTextStyle(P => P.FontFamily("Arial").FontSize(12));

                    page.Content().Column(column =>
                    {
                        column.Item().BorderBottom(2).BorderColor(Colors.Blue.Medium).PaddingBottom(5).Row(row =>
                        {
                            row.RelativeItem().Column(C =>
                            {
                                C.Item().Text("Smart Water Billing System").FontSize(14).Bold().FontColor(Colors.Blue.Medium);
                                C.Item().Text("Official Consumption Invoice").FontSize(10).FontColor(Colors.Grey.Medium);
                            });
                        });
                        column.Item().PaddingTop(10).PaddingBottom(10);

                        column.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            table.Cell().Text($"Invoice No: {invoice.InvoiceNumber}").Bold();
                            table.Cell().Text($"Subscription No: {invoice.SubscriptionNumber}");
                            table.Cell().Text($"Subscriber No: {subscriberName}");
                            table.Cell().Text($"Property Type No: {invoice.HouseType}");
                            table.Cell().Text($"Invoice Date No: {invoice.InvoiceDate:yyyy/MM/dd}");
                            table.Cell().Text($"Period No: {invoice.FromTheDateOf:yyyy/MM/dd} - {invoice.FromTheDateTo:MM/yyyy}");

                        });
                        column.Item().PaddingTop(10);

                        column.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(3);
                                columns.RelativeColumn(2);
                            });

                            table.Header(header =>
                            {
                                header.Cell().Background(Colors.Blue.Medium).Padding(5).Text("Description").FontColor(Colors.White).Bold();
                                header.Cell().Background(Colors.Blue.Medium).Padding(5).Text("Value").FontColor(Colors.White).Bold();
                            });

                            table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(4).Text("Current Reading");
                            table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(4).Text($"{invoice.CurrentConsumptionAmount} m³");

                            table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(4).Text("Previous Reading");
                            table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(4).Text($"{invoice.PreviousConsumptionAmount} m³");

                            table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(4).Text("Consumption Amount");
                            table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(4).Text($"{invoice.AmountOfConsumption} m³");

                            table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(4).Text("Water Consumption Value");
                            table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(4).Text($"{invoice.TheValueOfWaterConsumption:N2} EGY");

                            table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(4).Text("Wastewater Value (50%)");
                            table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(4).Text($"{invoice.WasteWaterConsumptionValue:N2} EGY");

                            table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(4).Text("Service Fee");
                            table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(4).Text($"{invoice.ServiceFee:N2} EGY");

                            table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(4).Text("Tax Fee (14%)");
                            table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(4).Text($"{invoice.TaxFee:N2} EGY");

                            table.Cell().Background(Colors.Grey.Lighten3).Padding(5).Text("Total Due").Bold().FontColor(Colors.Blue.Medium);
                            table.Cell().Background(Colors.Grey.Lighten3).Padding(5).Text($"{invoice.TotalInvoice:N2} EGP").Bold().FontColor(Colors.Blue.Medium);
                        });

                        column.Item().PaddingTop(35).Text("Collector Signature: ........................").FontSize(10);
                        column.Item().PaddingTop(15).AlignCenter().Text("Thank you for conserving water").FontSize(9).FontColor(Colors.Blue.Medium);

                    });
                })
             );

            //return await Task.FromResult(document.GeneratePdf());
            return await Task.Run(() => document.GeneratePdf());
        }
    }
}
