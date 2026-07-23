namespace SmartWaterBillingSystem.Client.Client.Pages.TypesOfRealEstates
{
    public partial class TypesOfRealEstateForm(ITypesOfRealEstateService _typesOfRealEstateService, ISnackbar _snackbar, IDialogService _dialogService, NavigationManager _navigationManager)
    {
        private List<TypesOfRealEstateClientDto> _typesOfRealEstates = [];
        private bool _isLoading = true;
        private string _searchString = string.Empty;

        protected override async Task OnInitializedAsync() => await LoadData();

        private async Task LoadData()
        {
            _isLoading = true;
            var result = await _typesOfRealEstateService.GetAllTypesOfRealEstatesAsync();
            if (result.IsSuccess)
                _typesOfRealEstates = result.Value?.ToList() ?? new List<TypesOfRealEstateClientDto>();
            else
            {
                if (result.Errors.Any(E => E.Type == ErrorType.Unauthorized))
                {
                    _navigationManager.NavigateTo("/login");
                    return;
                }
                var firstError = result.Errors.FirstOrDefault();
                string errorMessage = firstError is not null ? firstError.Message : "Failed to load types of real estates.";
                _snackbar.Add(errorMessage, Severity.Error);
            }

            _isLoading = false;
            StateHasChanged();
        }

        private async Task OpenUpsertDialog(TypesOfRealEstateClientDto? typesOfRealEstateDto = null)
        {
            var parameters = new DialogParameters<TypesOfRealEstateUpdate> { { T => T.EditedTypesOfRealEstateDto, typesOfRealEstateDto } };
            var options = new DialogOptions { MaxWidth = MaxWidth.Small, FullWidth = true, BackdropClick = true };
            var dialog = await _dialogService.ShowAsync<TypesOfRealEstateUpdate>(typesOfRealEstateDto is null ? "Add Type of Real Estate" : "Edit Type of Real Estate", parameters, options);
            var result = await dialog.Result;
            if (result is not null && !result.Canceled)
                await LoadData();
        }

        private async Task ConfirmDelete(TypesOfRealEstateClientDto typesOfRealEstateDto)
        {
            var parameters = new DialogParameters<DeleteConfirmationDialog> {{ x => x.ItemName, typesOfRealEstateDto.TypesName }};

            var options = new DialogOptions
            {
                MaxWidth = MaxWidth.ExtraSmall,
                FullWidth = true,
                BackdropClick = true,
                NoHeader = true
            };
            var dialog = await _dialogService.ShowAsync<DeleteConfirmationDialog>(string.Empty, parameters, options);
            // var dialog = await _dialogService.ShowAsync<DeleteConfirmationDialog>("Confirm Delete", parameters, options);
            var result = await dialog.Result;

            if (result is not null && !result.Canceled)
            {
                try
                {
                    var deleteResult = await _typesOfRealEstateService.DeleteTypesOfRealEstateAsync(typesOfRealEstateDto.HouseType);
                    if (deleteResult.IsSuccess)
                    {
                        _snackbar.Add("Real estate type has been deleted successfully.", Severity.Success);
                        _typesOfRealEstates.RemoveAll(R => R.HouseType == typesOfRealEstateDto.HouseType);
                        await LoadData();
                    }
                    else
                    {
                        var error = deleteResult.Errors?.FirstOrDefault();
                        _snackbar.Add(error is not null ? error.Message : "Failed to delete real estate type.", Severity.Error);
                    }
                }
                catch (Exception ex)
                {
                    _snackbar.Add($"An error occurred: {ex.Message}", Severity.Error);
                }
            }
        }

        private Func<TypesOfRealEstateClientDto, bool> _quickFilter => T =>
        {
            if (string.IsNullOrWhiteSpace(_searchString)) return true;
            if (T.HouseType.Contains(_searchString, StringComparison.OrdinalIgnoreCase)) return true;
            if (T.TypesName.Contains(_searchString, StringComparison.OrdinalIgnoreCase)) return true;
            if (T.TypesNote?.Contains(_searchString, StringComparison.OrdinalIgnoreCase) ?? false) return true;
            return false;
        };
    }
}
