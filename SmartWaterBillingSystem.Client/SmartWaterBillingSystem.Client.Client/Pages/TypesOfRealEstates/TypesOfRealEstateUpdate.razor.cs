namespace SmartWaterBillingSystem.Client.Client.Pages.TypesOfRealEstates
{
    public partial class TypesOfRealEstateUpdate(ISnackbar _snackbar, ITypesOfRealEstateService _typesOfRealEstateService)
    {
        [CascadingParameter]
        private IMudDialogInstance MudDialog { get; set; } = null!;
        [Parameter]
        public TypesOfRealEstateClientDto? EditedTypesOfRealEstateDto { get; set; }

        private MudForm? _form;
        private bool _isValid;
        private bool _isSaving;
        private TempDialogModel _tempDialogModel = new();
        private bool IsEditMode => EditedTypesOfRealEstateDto != null;

        protected override void OnInitialized()
        {
            if (IsEditMode && EditedTypesOfRealEstateDto is not null)
            {
                _tempDialogModel = new TempDialogModel
                {
                    HouseType = EditedTypesOfRealEstateDto.HouseType,
                    TypesName = EditedTypesOfRealEstateDto.TypesName,
                    TypesNote = EditedTypesOfRealEstateDto.TypesNote
                };
            }
            else
                _tempDialogModel = new TempDialogModel();
        }

        private async Task Submit()
        {
            if (_form is null)
                return;

            await _form.ValidateAsync();
            if (!_form.IsValid)
                return;

            _isSaving = true;
            if (IsEditMode)
            {
                var updateDto = new UpdateTypesOfRealEstateClientDto(_tempDialogModel.HouseType, _tempDialogModel.TypesName, _tempDialogModel.TypesNote);
                var result = await _typesOfRealEstateService.UpdateTypesOfRealEstateAsync(_tempDialogModel.HouseType, updateDto);
                HandleResponse(result, "Types of Real Estate updated successfully.");
            }
            else
            {
                var createDto = new CreateTypesOfRealEstateClientDto(_tempDialogModel.HouseType, _tempDialogModel.TypesName, _tempDialogModel.TypesNote);
                var result = await _typesOfRealEstateService.CreateTypesOfRealEstateAsync(createDto);
                HandleResponse(result, "Types of Real Estate created successfully.");
            }
        }

        private void HandleResponse<T>(Result<T> result, string successMessage)
        {
            _isSaving = false;
            if (result.IsSuccess)
            {
                _snackbar.Add(successMessage, Severity.Success);
                MudDialog.Close(DialogResult.Ok(true));
            }
            else
            {
                var errorMessage = result.Errors?.FirstOrDefault();
                _snackbar.Add(errorMessage is not null ? errorMessage.Message : "An error occurred.", Severity.Error);
            }
        }

        private void Cancel() => MudDialog.Cancel();

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender && _form is not null)
            {
                if (IsEditMode)
                    await _form.ValidateAsync();
                else
                    await _form.ResetValidationAsync();
                StateHasChanged();
            }
        }

        private class TempDialogModel
        {
            public string HouseType { get; set; } = string.Empty;
            public string TypesName { get; set; } = string.Empty;
            public string TypesNote { get; set; } = string.Empty;

        }
    }
}
