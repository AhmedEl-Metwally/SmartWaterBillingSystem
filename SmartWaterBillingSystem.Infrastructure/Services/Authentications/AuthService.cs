namespace SmartWaterBillingSystem.Infrastructure.Services.Authentications
{
    public class AuthService(UserManager<IdentityUser> _userManager) : IAuthService
    {
        public async Task<Result<string>> RegisterAsync(RegisterDto registerDto)
        {
            var user = new IdentityUser { UserName = registerDto.UserName, Email = registerDto.Email };
            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded)
                return Result<string>.Success("User registered successfully.");

            var errors = result.Errors.Select(E => new ErrorDetails
            (
                E.Code,
         E.Description,
           ErrorType.ValidationError
            )).ToList();

            return Result<string>.Failure(errors);
        }

        public async Task<Result<object>> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user is null)
                return Result<object>.Failure("UserNotFound", "User not found.", ErrorType.NotFound);

            var passwordValid = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!passwordValid)
                return Result<object>.Failure("InvalidPassword", "Invalid password.", ErrorType.Unauthorized);

            return Result<object>.Success(new { user.Id, user.UserName });
        }
    }
}
