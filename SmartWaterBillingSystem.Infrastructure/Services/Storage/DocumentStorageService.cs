namespace SmartWaterBillingSystem.Infrastructure.Services.Storage
{
    public class DocumentStorageService(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor) : IDocumentStorageService
    {
        private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment ?? throw new ArgumentNullException(nameof(webHostEnvironment));
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));

        public async Task<string> UploadInvoicePdfAsync(byte[] pdfBytes, string fileName)
        {
            var webRootPath = _webHostEnvironment.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            var uploadsFolder = Path.Combine(webRootPath, "invoices");
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var filePath = Path.Combine(uploadsFolder, fileName);
            await File.WriteAllBytesAsync(filePath, pdfBytes);

            string baseUrl = string.Empty;
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext is not null)
            {
                var request = httpContext.Request;
                baseUrl = $"{request.Scheme}://{request.Host}{request.PathBase}";
            }
            else
            {
                baseUrl = "https://localhost:44318";
            }
            return $"{baseUrl}/invoices/{fileName}";
        }
    }
}
