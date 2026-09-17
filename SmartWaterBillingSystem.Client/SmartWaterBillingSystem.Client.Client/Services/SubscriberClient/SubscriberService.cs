namespace SmartWaterBillingSystem.Client.Client.Services.SubscriberClient
{
    public class SubscriberService(HttpClient _httpClient) : ISubscriberService
    {
        private const string BaseUrl = "api/subscribers";
        private static readonly JsonSerializerOptions _jsonSerializerOptions = new(JsonSerializerDefaults.Web);

        public async Task<Result<string>> CreateSubscriberAsync(CreateSubscriberClientDto createSubscriber)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(BaseUrl, createSubscriber);

                if (response.IsSuccessStatusCode)
                {
                    var resultData = await response.Content.ReadFromJsonAsync<Result<string>>(_jsonSerializerOptions);
                    return resultData ?? Result<string>.Failure("DeserializationError", "Failed to deserialize response.", ErrorType.Failure);
                }

                var errorContent = await response.Content.ReadAsStringAsync();
                return response.ToFailureResultAsync<string>(errorContent);
            }
            catch (Exception ex)
            {
                return Result<string>.Failure("Client.Exception", $"An unexpected error occurred: {ex.Message}", ErrorType.Failure);
            }
        }

        public async Task<Result<SubscriberClientDto>> GetSubscriberByIdAsync(string subscriberId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{BaseUrl}/{subscriberId}");

                if (response.IsSuccessStatusCode)
                {
                    var resultData = await response.Content.ReadFromJsonAsync<Result<SubscriberClientDto>>(_jsonSerializerOptions);
                    return resultData ?? Result<SubscriberClientDto>.Failure("DeserializationError", "Failed to deserialize response.", ErrorType.Failure);
                }
                var errorContent = await response.Content.ReadAsStringAsync();
                return response.ToFailureResultAsync<SubscriberClientDto>(errorContent);
            }
            catch (Exception ex)
            {
                return Result<SubscriberClientDto>.Failure("Client.Exception", $"An unexpected error occurred: {ex.Message}", ErrorType.Failure);
            }
        }

        public async Task<Result<bool>> DeleteSubscriberAsync(string subscriberId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{BaseUrl}/{subscriberId}");
                var result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        var resultData = JsonSerializer.Deserialize<Result<bool>>(result, _jsonSerializerOptions);
                        if (resultData is not null)
                            return resultData;
                    }
                    catch (JsonException)
                    {
                        if (bool.TryParse(result, out bool isSuccess))
                            return isSuccess ? Result<bool>.Success(true) : Result<bool>.Failure("DeserializationError", "Failed to deserialize response.", ErrorType.Failure);
                    }
                    return Result<bool>.Success(true);
                }
                return response.ToFailureResultAsync<bool>(result);
            }
            catch (Exception ex)
            {
                return Result<bool>.Failure("Client.Exception", $"An unexpected error occurred: {ex.Message}", ErrorType.Failure);
            }
        }

     
    }
}
