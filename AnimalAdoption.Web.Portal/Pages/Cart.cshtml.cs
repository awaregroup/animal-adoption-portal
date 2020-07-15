using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalAdoption.Common.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AnimalAdoption.Web.Portal
{
    public class CartModel : PageModel
    {
        private readonly CartService _cartLogic;

        [BindProperty]
        public Cart Cart { get; set; }

        [BindProperty]
        public IEnumerable<Animal> Animals { get; set; }
                
        public CartModel(AnimalService animalData, CartService cartLogic)
        {
            Animals = animalData.ListAnimals;
            _cartLogic = cartLogic;
        }

        public IActionResult OnPost(int id, int quantity)
        {
            var cartValue = Request.Cookies["z_name"] ?? Request.Cookies["z_cartId"];
            _cartLogic.SetAnimalQuantity(cartValue, id, quantity);
            return LocalRedirect("/cart");
        }

        public void OnGet()
        {
            var cartValue = Request.Cookies["z_name"] ?? Request.Cookies["z_cartId"];

            if(string.IsNullOrWhiteSpace(cartValue))
            {
                cartValue = Guid.NewGuid().ToString();
                var cookieOptions = new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(1)
                };
                Response.Cookies.Append("z_cartId", cartValue, cookieOptions);
            }

            Cart = _cartLogic.ListAnimals(cartValue);
        }
    }
}