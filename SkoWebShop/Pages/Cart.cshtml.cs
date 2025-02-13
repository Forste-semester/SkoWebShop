using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SkoWebShop.Models;
using SkoWebShop.Services;
using System.Collections.Generic;
using System.Diagnostics; // For Debugging

namespace SkoWebShop.Pages
{
    public class CartModel : PageModel
    {
        private readonly UserService _userService;
        private readonly ShoeService _shoeService;

        public Cart UserCart { get; set; } = new Cart();
        public List<Shoe> CartItems { get; set; } = new List<Shoe>();

        public CartModel(UserService userService, ShoeService shoeService)
        {
            _userService = userService;
            _shoeService = shoeService;
        }

        public void OnGet()
        {
            string email = Request.Cookies["userEmail"]; // Get user email from cookies

            if (string.IsNullOrEmpty(email))
            {
                Debug.WriteLine("No user email found in cookies.");
                return;
            }

            var user = _userService.GetUserById(email);

            if (user == null)
            {
                Debug.WriteLine($"No user found for email: {email}");
                return;
            }

            if (user.Cart == null)
            {
                Debug.WriteLine($"User {email} does not have a cart.");
                return;
            }

            // Assign User's Cart
            UserCart = user.Cart;

            // Ensure CartList is Not Null
            if (UserCart.CartList != null)
            {
                CartItems = UserCart.CartList;
                Debug.WriteLine($"User {email} has {CartItems.Count} items in the cart.");
            }
            else
            {
                Debug.WriteLine($"User {email} has an empty cart.");
            }
            Response.Cookies.Append("userCartTotal", user.Cart.TotalPrice().ToString(), new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddHours(24),
                Path = "/"
            });
        }

        public IActionResult OnPostRemove(int id)
        {
            string email = Request.Cookies["userEmail"];
            var user = _userService.GetUserById(email);

            if (user?.Cart != null)
            {
                user.Cart.CartList.RemoveAll(shoe => shoe.Id == id);
                Debug.WriteLine($"Removed item {id} from cart.");
            }

            return RedirectToPage();
        }

        public IActionResult OnPostCheckout()
        {
            string email = Request.Cookies["userEmail"];
            var user = _userService.GetUserById(email);
            if (user?.Cart != null)
            {
                // ✅ Process the checkout
                Debug.WriteLine($"Processing checkout for user {email} with {user.Cart.CartList.Count} items in the cart.");
                
            }
            return RedirectToPage();
        }
    }
}
