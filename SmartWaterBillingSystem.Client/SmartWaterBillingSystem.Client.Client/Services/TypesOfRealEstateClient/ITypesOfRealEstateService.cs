namespace SmartWaterBillingSystem.Client.Client.Services.TypesOfRealEstateClient
{
    public interface ITypesOfRealEstateService
    {
        Task<Result<IReadOnlyList<TypesOfRealEstateClientDto>>> GetAllTypesOfRealEstatesAsync();
        Task<Result<string>> CreateTypesOfRealEstateAsync(CreateTypesOfRealEstateClientDto createTypesOfRealEstateDto);
        Task<Result<bool>> UpdateTypesOfRealEstateAsync(string houseType, UpdateTypesOfRealEstateClientDto updateTypesOfRealEstateDto);
        Task<Result<bool>> DeleteTypesOfRealEstateAsync(string houseType);
    }
}
