using ECom.Web.Models.Dto;

namespace ECom.Web.Services.IService
{
    public interface IAuthService
    {
        Task<ResponseDto> LoginAsync(LoginRequestDto loginRequestDto);
        Task<ResponseDto> RegisterAsync(RegisterationRequestDto registerationRequestDto);
        Task<ResponseDto> AssignRoleAsync(RegisterationRequestDto registerationRequestDto);
    }
}
