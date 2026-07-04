namespace SmartWaterBillingSystem.Client.Client.Pages.Authentications
{
    public partial class AuthBaseForm
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "The email format is incorrect.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password required")]
        [StringLength(30, ErrorMessage = "The password should be between 8 and 30 characters long.", MinimumLength = 8)]
        public string Password { get; set; } = string.Empty;
    }
}
