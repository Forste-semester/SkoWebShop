using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SkoWebShop.Models;
using SkoWebShop.Services;
using System.Collections.Generic;
using System.Diagnostics;

namespace SkoWebShop.Pages
{
    public class SneakersModel : PageModel
    {
        private readonly ShoeService _shoeService;
        private readonly UserService _userService;


        [BindProperty]
        public List<Shoe> Shoes { get; set; }

        public SneakersModel(ShoeService shoeService, UserService userService)
        {
            _shoeService = shoeService;
            _userService = userService;
        }

        public void OnGet()
        {
            Shoes = _shoeService.GetAll();
        }

        public IActionResult OnPostAddToCart(int shoeId)
        {
            string email = Request.Cookies["userEmail"];
            var user = _userService.GetUserById(email);
            var shoe = _shoeService.GetById(shoeId);

            if (user != null && shoe != null)
            {
                user.Cart.AddToCart(shoe);
                Debug.WriteLine($"Added {shoe.Name} to user {email}'s cart.");
            }
            else
            {
                Debug.WriteLine($"Error: User or shoe not found. User: {email}, ShoeId: {shoeId}");
            }

            return RedirectToPage("/Sneakers");
        }
    }
}
