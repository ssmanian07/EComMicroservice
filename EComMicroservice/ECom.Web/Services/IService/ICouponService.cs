using ECom.Web.Models.Dto;

namespace ECom.Web.Services.IService
{
    public interface ICouponService
    {
        Task<ResponseDto> GetCouponAsync(string couponCode);
        Task<ResponseDto> GetCouponByIdAsync(int id);
        Task<ResponseDto> GetAllCouponAsync();
        Task<ResponseDto> CreateCouponAsync(CouponDto couponDto);
        Task<ResponseDto> UpdateCouponAsync(CouponDto couponDto);
        Task<ResponseDto> DeleteCouponAsync(int id);
    }
}
