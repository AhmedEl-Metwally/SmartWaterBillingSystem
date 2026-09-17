namespace SmartWaterBillingSystem.Client.Client.Pages.Subscribers
{
    public partial class CreateSubscriber(IDialogService _dialogService)
    {
        [Parameter]
        public EventCallback<SubscriberClientDto> OnSubscriberCreated { get; set; }

        private async Task OpenCreateDialog()
        {
            var options = new DialogOptions { MaxWidth = MaxWidth.Small, FullWidth = true, BackdropClick = true };
            var dialog = await _dialogService.ShowAsync<SubscriberCreateDialog>("Add Subscriber" , options);
            var result = await dialog.Result;

            if(result is not null && !result.Canceled && result.Data is SubscriberClientDto subscriberClientDto)
                await OnSubscriberCreated.InvokeAsync(subscriberClientDto);
        }
    }
}
