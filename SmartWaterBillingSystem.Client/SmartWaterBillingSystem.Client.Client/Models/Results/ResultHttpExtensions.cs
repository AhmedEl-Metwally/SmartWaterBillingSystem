namespace SmartWaterBillingSystem.Client.Client.Models.Results
{
    public static class ResultHttpExtensions
    {
        public static ErrorType ToErrorType(this HttpStatusCode statusCode) => statusCode switch
        {
            HttpStatusCode.BadRequest => ErrorType.ValidationError,
            HttpStatusCode.NotFound => ErrorType.NotFound,
            HttpStatusCode.Unauthorized => ErrorType.Unauthorized,
            HttpStatusCode.Forbidden => ErrorType.Forbidden,
            _ => ErrorType.Failure
        };

        public static Result<T> ToFailureResultAsync<T>(this HttpResponseMessage responseMessage, string rawContent)
        {
            try
            {
                using var document = JsonDocument.Parse(rawContent);
                var root = document.RootElement;

                string errorCode = root.TryGetProperty("title", out var titleProp) ? titleProp.GetString() ?? "Error" : "Error";
                string errorMessage = root.TryGetProperty("detail", out var detailProp) ? detailProp.GetString() ?? "An error occurred." : "An error occurred.";
                return Result<T>.Failure(errorCode, errorMessage, responseMessage.StatusCode.ToErrorType());
            }
            catch
            {
                return Result<T>.Failure("API.Error", string.IsNullOrWhiteSpace(rawContent) ? responseMessage.ReasonPhrase ?? "An error occurred." : rawContent, responseMessage.StatusCode.ToErrorType());
            }
        }

    }
}
