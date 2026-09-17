namespace SmartWaterBillingSystem.Client.Client.Pages.Subscribers
{
    public partial class SubscriberCreateDialog(ISubscriberService _subscriberService, ISnackbar _snackbar)
    {
        [CascadingParameter]
        private IMudDialogInstance MudDialog  { get; set; } = null!;
        private MudForm? _form;
        private bool _isValid;
        private bool _isSaving;

        private string _subscriberId = string.Empty;
        private string _name = string.Empty;
        private string _governorate = string.Empty;
        private string _area = string.Empty;
        private string _phone = string.Empty;
        private string _note = string.Empty;

        private async Task Submit()
        {
            if (_form is null)   return;
            await _form.ValidateAsync();
            if (!_form.IsValid) return;

            _isSaving = true;
            var createSubscriberDto = new CreateSubscriberClientDto(_subscriberId, _name, _governorate, _area, _phone, _note);
            var result = await _subscriberService.CreateSubscriberAsync(createSubscriberDto);
            _isSaving = false;

            if (result.IsSuccess)
            {
                _snackbar.Add("Subscriber created successfully.", Severity.Success);
                var createSubscriber = new SubscriberClientDto(_subscriberId, _name, _phone, _area);
                MudDialog.Close(DialogResult.Ok(createSubscriber));
            }
            else 
            {
                var error = result.Errors.FirstOrDefault();
                _snackbar.Add(error?.Message ?? "An error occurred while creating the subscriber.", Severity.Error);
            }
        }

        private void Cancel() => MudDialog.Cancel();
    }
}
