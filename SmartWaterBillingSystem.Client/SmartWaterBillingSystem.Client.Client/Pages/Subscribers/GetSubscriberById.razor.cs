namespace SmartWaterBillingSystem.Client.Client.Pages.Subscribers
{
    public partial class GetSubscriberById(ISubscriberService _subscriberService, ISnackbar _snackbar)
    {
        [Parameter]
        public string SearchId { get; set; } = string.Empty;
        [Parameter]
        public EventCallback<SubscriberClientDto> OnSubscriberFound { get; set; }
        private bool _isSearching;

        private async Task GetSubscriberByIdAsync()
        {
            if (string.IsNullOrWhiteSpace(SearchId))
            {
                _snackbar.Add("Please enter a valid ID.", Severity.Success);
                return;
            }

            _isSearching = true;
            var result = await _subscriberService.GetSubscriberByIdAsync(SearchId.Trim());
            _isSearching = false;

            if (result.IsSuccess && result.Value is not null)
            {
                _snackbar.Add($"Subscriber with ID {SearchId} found.", Severity.Success);
                await OnSubscriberFound.InvokeAsync(result.Value);
            }
            else
            {
                var error = result.Errors.FirstOrDefault();
                _snackbar.Add(error?.Message ?? "An error occurred while searching for the subscriber.", Severity.Error);
            }
        }

        private async Task OnKeyDownHandler(KeyboardEventArgs e)
        {
            if (e.Key == "Enter")
                await GetSubscriberByIdAsync();
        }
    }
}