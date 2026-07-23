namespace SmartWaterBillingSystem.Client.Client.Services.TypesOfRealEstateClient
{
    public class TypesOfRealEstateService(HttpClient _httpClient) : ITypesOfRealEstateService
    {
        private const string BaseUrl = "api/TypesOfRealEstates";

        public async Task<Result<IReadOnlyList<TypesOfRealEstateClientDto>>> GetAllTypesOfRealEstatesAsync()
        {
            var response = await _httpClient.GetAsync("api/TypesOfRealEstates");
            var content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonSerializer.Deserialize<Result<IReadOnlyList<TypesOfRealEstateClientDto>>>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return result ?? Result<IReadOnlyList<TypesOfRealEstateClientDto>>.Failure("NullResponse", "Received null response from server.", ErrorType.Failure);
            }

            return response.ToFailureResultAsync<IReadOnlyList<TypesOfRealEstateClientDto>>(content);
        }

        public async Task<Result<string>> CreateTypesOfRealEstateAsync(CreateTypesOfRealEstateClientDto createTypesOfRealEstateDto)
        {
            var response = await _httpClient.PostAsJsonAsync(BaseUrl, createTypesOfRealEstateDto);
            var result = await response.Content.ReadFromJsonAsync<Result<string>>();
            return result ?? Result<string>.Failure("DeserializationError", "Failed to create type of real estate.", ErrorType.Failure);
        }

        public async Task<Result<bool>> UpdateTypesOfRealEstateAsync(string houseType, UpdateTypesOfRealEstateClientDto updateTypesOfRealEstateDto)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{houseType}", updateTypesOfRealEstateDto);
                var rawContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    if (string.IsNullOrEmpty(rawContent))
                        return Result<bool>.Success(true);
                    try
                    {
                        var result = JsonSerializer.Deserialize<Result<bool>>(rawContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                        if (result is not null)
                            return result;
                    }
                    catch (JsonException)
                    {
                        if (bool.TryParse(rawContent, out bool isSuccess))
                            return isSuccess ? Result<bool>.Success(true) : Result<bool>.Failure(houseType, "Failed to update type of real estate.", ErrorType.Failure);
                    }
                    return Result<bool>.Success(true);
                }

                return response.ToFailureResultAsync<bool>(rawContent);
            }
            catch (Exception ex)
            {
                return Result<bool>.Failure("Client.Exception", $"An unexpected error occurred: {ex.Message}", ErrorType.Failure);
            }
        }

        public async Task<Result<bool>> DeleteTypesOfRealEstateAsync(string houseType)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{BaseUrl}/{houseType}");
                var rawContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        var result = JsonSerializer.Deserialize<Result<bool>>(rawContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                        if (result != null) return result;
                    }
                    catch (JsonException)
                    {
                        if (bool.TryParse(rawContent, out bool isSuccess))
                            return isSuccess ? Result<bool>.Success(true) : Result<bool>.Failure(houseType, "Failed to delete type of real estate.", ErrorType.Failure);

                    }

                    return Result<bool>.Success(true);
                }

                return response.ToFailureResultAsync<bool>(rawContent);
            }
            catch (Exception ex)
            {
                return Result<bool>.Failure("Client.Exception", $"An unexpected error occurred: {ex.Message}", ErrorType.Failure);
            }

        }
    }
}
