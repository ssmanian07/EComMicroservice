﻿using ECom.Web.Models.Dto;
using ECom.Web.Services.IService;
using ECom.Web.Utility;

namespace ECom.Web.Services
{
    public class AuthService : IAuthService
    {
        private readonly IBaseService _baseService;

        public AuthService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto> AssignRoleAsync(RegisterationRequestDto registerationRequestDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = registerationRequestDto,
                Url = SD.AuthAPIBase + "/api/auth/assignRole"
            });



        }

        public async Task<ResponseDto> LoginAsync(LoginRequestDto loginRequestDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = loginRequestDto,
                Url = SD.AuthAPIBase + "/api/auth/login"
            });
        }

        public async Task<ResponseDto> RegisterAsync(RegisterationRequestDto registerationRequestDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = registerationRequestDto,
                Url = SD.AuthAPIBase + "/api/auth/register"
            });
        }
    }
}
