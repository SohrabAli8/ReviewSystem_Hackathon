using ReviewSystem.DTOs;

namespace ReviewSystem.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDto?> LoginAsync(LoginDto dto);

        Task<bool> RegisterAsync(RegisterDto dto);
    }
}