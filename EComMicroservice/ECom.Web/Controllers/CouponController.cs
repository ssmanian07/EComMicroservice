﻿using ECom.Web.Models.Dto;
using ECom.Web.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECom.Web.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;

        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        public async Task<IActionResult> CouponIndex()
        {
            List<CouponDto> list = new();

            ResponseDto? response = await _couponService.GetAllCouponAsync();


            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<CouponDto>>(value: Convert.ToString(response.Result));
            }
            else
            {
                TempData["Error"] = response?.Message;
            }

            return View(list);
        }

        public async Task<IActionResult> CouponCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CouponCreate(CouponDto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _couponService.CreateCouponAsync(model);


                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Coupon Created Successfully";
                    return RedirectToAction(nameof(CouponIndex));
                }
                else
                {
                    TempData["Error"] = response?.Message;
                }
            }
            return View(model);
        }

        public async Task<ActionResult> CouponDelete(int couponId)
        {
            ResponseDto? response = await _couponService.GetCouponByIdAsync(couponId);


            if (response != null && response.IsSuccess)
            {
                var model = JsonConvert.DeserializeObject<CouponDto>(value: Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["Error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> CouponDelete(CouponDto model)
        {
            ResponseDto? response = await _couponService.DeleteCouponAsync(model.CouponId);


            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Coupon Deleted Successfully";
                return RedirectToAction(nameof(CouponIndex));
            }
            else
            {
                TempData["Error"] = response?.Message;
            }

            return View(model);
        }
    }
}
