﻿using ECom.Web.Models.Dto;

namespace ECom.Web.Services.IService
{
    public interface IBaseService
    {
        Task<ResponseDto?> SendAsync(RequestDto requestDto, bool withBearer = true);
    }
}
