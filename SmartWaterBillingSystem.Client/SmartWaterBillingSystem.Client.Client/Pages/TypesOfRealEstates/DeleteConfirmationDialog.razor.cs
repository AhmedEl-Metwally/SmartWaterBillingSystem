namespace SmartWaterBillingSystem.Client.Client.Pages.TypesOfRealEstates
{
    public partial class DeleteConfirmationDialog
    {
        [CascadingParameter] 
        private IMudDialogInstance MudDialog { get; set; } = null!;

        [Parameter] 
        public string ItemName { get; set; } = string.Empty;

        private void Confirm() => MudDialog.Close(DialogResult.Ok(true));
        private void Cancel() => MudDialog.Cancel();
    }
}
