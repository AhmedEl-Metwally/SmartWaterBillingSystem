namespace SmartWaterBillingSystem.Client.Client.Pages.Subscribers
{
    public partial class DeleteSubscriber(ISubscriberService _subscriberService, ISnackbar _snackbar, IDialogService _dialogService)
    {
        [Parameter]
        public SubscriberClientDto subscriberClientDto { get; set; } = null!;
        [Parameter]
        public EventCallback<string> OnSubscriberDeleted { get; set; }

        private async Task OpenDeleteDialog()
        {
            var parameters = new DialogParameters<DeleteConfirmationDialog>
            {
                {D => D.ItemName, subscriberClientDto.SubscriberName }
            };

            var options = new DialogOptions
            {
                MaxWidth = MaxWidth.ExtraSmall,
                FullWidth = true,
                BackdropClick = true,
                NoHeader = true,
            };

            var dialog = await _dialogService.ShowAsync<DeleteConfirmationDialog>(string.Empty, parameters, options);
            var result = await dialog.Result;

            if (result is not null && !result.Canceled)
            {
                var deleteResult = await _subscriberService.DeleteSubscriberAsync(subscriberClientDto.PersonalIDNumber);
                if (deleteResult.IsSuccess)
                {
                    _snackbar.Add("Subscriber deleted successfully.", Severity.Success);
                    await OnSubscriberDeleted.InvokeAsync(subscriberClientDto.PersonalIDNumber);
                }
                else
                {
                    var error = deleteResult.Errors.FirstOrDefault();
                    _snackbar.Add(error?.Message ?? "Failed to delete subscriber.", Severity.Error);
                }
            }
        }
    }
}
