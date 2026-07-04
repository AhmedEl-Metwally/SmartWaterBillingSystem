namespace SmartWaterBillingSystem.Client.Client.Pages.Authentications
{
    public partial class Register(IAuthClientService _authService, ISnackbar _snackbar, NavigationManager _navigationManager)
    {

        private RegisterAccountForm _registerAccount { get; set; } = new();
        private bool _processing = false;
        private string _serverError = "";
        private EditContext _editContext = default!;
        protected override void OnInitialized()
        {
            _editContext = new EditContext(_registerAccount);
            _editContext.OnValidationStateChanged += (sender, eventArgs) => StateHasChanged();
        }

        private bool ShouldShowSummary() => !string.IsNullOrEmpty(_serverError) || _editContext.GetValidationMessages().Any();

        public class RegisterAccountForm
        {
            [Required(ErrorMessage = "Username is required.")]
            [StringLength(8, ErrorMessage = "Name length can't be more than 8.")]
            public string Username { get; set; } = string.Empty;

            public AuthBaseForm AuthBaseForms { get; set; } = new();


            public string TargetPassword => AuthBaseForms?.Password ?? string.Empty;



            [Required(ErrorMessage = "Password required")]
            [Compare(nameof(TargetPassword), ErrorMessage = "The two passwords do not match.")]
            public string ConfirmPassword { get; set; } = string.Empty;

        }

        private async Task OnValidSubmit(EditContext context)
        {
            _processing = true;
            _serverError = "";

            try
            {
                var registerDto = new RegisterClientDto(_registerAccount.Username, _registerAccount.AuthBaseForms.Email, _registerAccount.AuthBaseForms.Password);
                var result = await _authService.RegisterAsync(registerDto);

                if (result is null)
                {
                    _snackbar.Add("Account created successfully", Severity.Success);
                    _navigationManager.NavigateTo("/Login", forceLoad: false, replace: true);
                }
                else
                {
                    _serverError = result;
                    _snackbar.Add(result, Severity.Error);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Register Exception]: {ex.Message}");
                _serverError = "An unexpected network or server error occurred.";
                _snackbar.Add(_serverError, Severity.Error);
            }
            finally
            {
                _processing = false;
            }

        }
    }
}

