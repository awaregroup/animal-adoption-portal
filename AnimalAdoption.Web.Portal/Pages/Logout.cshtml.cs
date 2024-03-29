﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AnimalAdoption.Web.Portal
{
	public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {            
            Response.Cookies.Delete("z_name");
            return Redirect("/");
        }
    }
}