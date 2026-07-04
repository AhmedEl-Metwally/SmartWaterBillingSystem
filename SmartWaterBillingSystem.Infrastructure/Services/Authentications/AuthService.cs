namespace SmartWaterBillingSystem.Infrastructure.Services.Authentications
{
    public class AuthService(UserManager<IdentityUser> _userManager, IOptions<JwtSettings> _jwtSettings) : IAuthService
    {
        private readonly JwtSettings jwtSettings = _jwtSettings.Value;
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

        public async Task<Result<string>> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user is null)
                return Result<string>.Failure("UserNotFound", "User not found.", ErrorType.NotFound);

            var passwordValid = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!passwordValid)
                return Result<string>.Failure("InvalidPassword", "Invalid password.", ErrorType.Unauthorized);

            var generateToken = GenerateJwtToken(user);

            return Result<string>.Success(generateToken);
        }

        private string GenerateJwtToken(IdentityUser user)
        {
            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, user.Id),
                new(JwtRegisteredClaimNames.Email, user.Email!),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(ClaimTypes.NameIdentifier, user.Id),
                new(ClaimTypes.Name, user.UserName!)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(jwtSettings.ExpiryMinutes),
                SigningCredentials = creds,
                Issuer = jwtSettings.Issuer,
                Audience = jwtSettings.Audience
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(securityToken);
        }
    }
}
