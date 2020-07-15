using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AnimalAdoption.Common.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace AnimalAdoption.Web.Identity.Pages
{
    public class LoginModel : PageModel
    {
        private IOptions<Configuration> _configuration;
        private LoginService _loginService;

        public LoginModel(LoginService loginService, IOptions<Configuration> configuration)
        {
            _configuration = configuration;
            _loginService = loginService;
            LogonIds = _loginService.GetLoginIds();
        }
        public string[] LogonIds { get; set; }

        [BindProperty(SupportsGet = true)]
        public string RedirectUrl { get; set; }

        [Required]
        [BindProperty]
        public string AvatarId { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [BindProperty]
        public string Password { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (string.IsNullOrWhiteSpace(AvatarId))
            {
                return Redirect("/error");
            }

            if (string.IsNullOrWhiteSpace(RedirectUrl))
            {
                RedirectUrl = "/";
            }

            if(Password != _configuration.Value.GlobalPassword)
            {
                ViewData.ModelState.AddModelError("Password", "Password does not match! (default 'password')");
                return Page();
            }

            var name = _loginService.GetLoginUserFromId(AvatarId);

            if (string.IsNullOrEmpty(name))
            {
                return Redirect("/error");
            }

            
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(1)
            };
            Response.Cookies.Append("z_name", name, cookieOptions);
            return LocalRedirect($"{RedirectUrl}");
        }
    }
}