using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ReviewSystem.Data;
using ReviewSystem.DTOs;
using ReviewSystem.Interfaces;
using ReviewSystem.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ReviewSystem.Services
{
    public class AuthService : IAuthService
    {
        private readonly EcommerceDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(EcommerceDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<AuthResponseDto?> LoginAsync(LoginDto dto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == dto.Email);

            if (user == null)
                return null;

            // ⚠ For MVP only (plain text comparison)
            if (user.PasswordHash != dto.Password)
                return null;

            var token = GenerateJwtToken(user);

            return new AuthResponseDto
            {
                Token = token,
                Role = user.Role
            };
        }

        public async Task<bool> RegisterAsync(RegisterDto dto)
        {
            var exists = await _context.Users
                .AnyAsync(u => u.Email == dto.Email);

            if (exists) return false;

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = dto.Password, // hash later
                Role = "User"
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return true;
        }

        private string GenerateJwtToken(User user)
        {
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("MySuperSecretKey12345678901234567890"));

            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}