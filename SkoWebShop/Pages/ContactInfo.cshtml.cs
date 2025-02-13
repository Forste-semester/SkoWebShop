using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SkoWebShop.Models;
using SkoWebShop.Services;
using System.Diagnostics;

namespace SkoWebShop.Pages
{
    public class ContactInfoModel : PageModel
    {

        private readonly UserService _userService;
        private readonly ShoeService _shoeService;

        public Cart UserCart { get; set; } = new Cart();
        public List<Shoe> CartItems { get; set; } = new List<Shoe>();
        public User NewUser { get; set; }

        public ContactInfoModel(UserService userService, ShoeService shoeService)
        {
            _userService = userService;
            _shoeService = shoeService;
        }

        public void OnGet()
        {
            // Read the user info from cookies and set it to the NewUser model
            string email = Request.Cookies["userEmail"];
            var user = _userService.GetUserById(email);

            
        
            user.FirstName = Request.Cookies["userFirstName"];
            user.LastName = Request.Cookies["userLastName"];
            user.StreetName = Request.Cookies["userStreetName"];
            user.PostalCode = int.TryParse(Request.Cookies["userPostalCode"], out var postalCode) ? postalCode : 0;
            user.City = Request.Cookies["userCity"];
            user.Email = Request.Cookies["userEmail"];
            user.CreditCardName = Request.Cookies["userCreditCardName"];
            user.Cart.Total = Request.Cookies["userCartTotal"];
            


            // Safely parse CreditCardNumber from cookie as long
            user.CreditCardNumber = long.TryParse(Request.Cookies["userCreditCardNumber"], out var creditCardNumber) ? creditCardNumber : 0;

            // Parse DateOfExpire (it might be stored as a string in the cookie)
            user.DateOfExpire = DateTime.TryParse(Request.Cookies["userDateOfExpire"], out var expireDate) ? expireDate : DateTime.MinValue;

            // Parse CCV (it is stored as a string, so it is parsed as an integer)
            user.CCV = int.TryParse(Request.Cookies["userCCV"], out var ccv) ? ccv : 0;

            // You can also set CardType here based on saved cookie if it's available.
            user.CardType = Request.Cookies["userCardType"];

        }

        // You can also add OnPost method to handle form submissions




        public IActionResult OnPostConfirm()
        {
            string email = Request.Cookies["userEmail"];
            var user = _userService.GetUserById(email);
            if (user?.Cart != null)
            {
                // ✅ Process the checkout
                Debug.WriteLine($"Processing checkout for user {email} with {user.Cart.CartList.Count} items in the cart.");

            }
            // Clear the cart
            user.Cart.CartList.Clear();
            return RedirectToPage("Index");
        }
    }
}
