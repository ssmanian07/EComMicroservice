using ECom.Services.AuthAPI.Models.Dto;
using ECom.Services.AuthAPI.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace ECom.Services.AuthAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthAPIController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ResponseDto _responseDto;

        public AuthAPIController(IAuthService authService)
        {
            _authService = authService;
            _responseDto = new ResponseDto();
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterationRequestDto registerationRequestDto)
        {
            var errorMessage = await _authService.Register(registerationRequestDto);

            if (!String.IsNullOrEmpty(errorMessage))
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = errorMessage;
                return BadRequest(_responseDto);
            }

            return Ok(_responseDto);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var loginResponse = await _authService.Login(loginRequestDto);
            if (loginResponse.User == null)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = "Username or password is incorrect";
                return BadRequest(_responseDto);
            }
            _responseDto.Result = loginResponse;
            return Ok(_responseDto);
        }

        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole([FromBody] RegisterationRequestDto registerationRequestDto)
        {
            var assignRoleSucessful = await _authService.AssignRole(registerationRequestDto.Email, registerationRequestDto.Role.ToUpper());
            if (!assignRoleSucessful)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = "Error Encountered";
                return BadRequest(_responseDto);
            }
            return Ok(_responseDto);
        }

    }
}
