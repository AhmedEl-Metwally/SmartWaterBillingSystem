namespace SmartWaterBillingSystem.Client.Client.Pages.Authentications
{
    public partial class Login(IAuthClientService _authService, ISnackbar _snackbar, NavigationManager _navigationManager)
    {
        private LoginAccountForm _LoginAccount { get; set; } = new();
        private EditContext _editContext = default!;
        private bool _processing = false;
        private string _serverError = "";

        protected override void OnInitialized()
        {
            _editContext = new EditContext(_LoginAccount);
            _editContext.OnValidationStateChanged += (sender, eventArgs) => StateHasChanged();
        }

        public class LoginAccountForm
        {
            public AuthBaseForm AuthBaseForms { get; set; } = new();
        }

        private async Task OnValidSubmit(EditContext context)
        {
            _processing = true;
            _serverError = "";

            try
            {
                var loginDto = new LoginClientDto(_LoginAccount.AuthBaseForms.Email, _LoginAccount.AuthBaseForms.Password);
                var result = await _authService.LoginAsync(loginDto);

                if (result is null)
                {
                    _snackbar.Add("Logged in successfully.", Severity.Success);
                    _navigationManager.NavigateTo("/TypesOfRealEstate", forceLoad: false, replace: true);
                }
                else
                {
                    _serverError = result;
                    _snackbar.Add(result, Severity.Error);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Login Exception]: {ex.Message}");
                _serverError = "An unexpected error occurred during login.";
                _snackbar.Add(_serverError, Severity.Error);
            }
            finally
            {
                _processing = false;
            }
        }
    }
}
