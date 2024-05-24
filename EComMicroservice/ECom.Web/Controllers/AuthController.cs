using ECom.Web.Models.Dto;
using ECom.Web.Services.IService;
using ECom.Web.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace ECom.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginRequestDto requestDto = new LoginRequestDto();
            return View(requestDto);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDto requestDto)
        {
            ResponseDto responseDto = await _authService.LoginAsync(requestDto);
            if (responseDto != null && responseDto.IsSuccess)
            {
                LoginResponseDto loginResponseDto = JsonConvert.DeserializeObject<LoginResponseDto>(Convert.ToString(responseDto.Result));
                TempData["success"] = "Logged in Successfully";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["error"] = responseDto.Message;
                return View(requestDto);
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            var roleList = new List<SelectListItem>()
            {
                new SelectListItem() {Text=SD.RoleAdmin,Value=SD.RoleAdmin},
                new SelectListItem() {Text=SD.RoleCustomer,Value=SD.RoleCustomer}
            };
            ViewBag.RoleList = roleList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterationRequestDto requestDto)
        {
            ResponseDto result = await _authService.RegisterAsync(requestDto);
            ResponseDto assingRole;

            if (result != null && result.IsSuccess)
            {
                if (string.IsNullOrEmpty(requestDto.Role))
                {
                    requestDto.Role = SD.RoleCustomer;
                }
                assingRole = await _authService.AssignRoleAsync(requestDto);
                if (assingRole != null && assingRole.IsSuccess)
                {
                    TempData["success"] = "Registration Successful";
                    return RedirectToAction(nameof(Login));
                }
            }
            else
            {
                TempData["error"] = result.Message;
            }

            var roleList = new List<SelectListItem>()
            {
                new SelectListItem{Text=SD.RoleAdmin,Value=SD.RoleAdmin},
                new SelectListItem{Text=SD.RoleCustomer,Value=SD.RoleCustomer},
            };

            ViewBag.RoleList = roleList;
            return View(requestDto);
        }
    }
}
