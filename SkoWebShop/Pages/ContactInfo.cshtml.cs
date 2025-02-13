using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SkoWebShop.Pages.Models;
using SkoWebShop.Pages.Services;

namespace SkoWebShop.Pages
{
    public class ContactInfoModel : PageModel
    {

        private UserService _userService;

        [BindProperty]

        public User NewUser { get; set; }

        public ContactInfoModel(UserService userService)
        {

            this._userService = userService;

        }

        public void OnGet()
        {
            // Read the user info from cookies and set it to the NewUser model
            NewUser = new User
            {
                FirstName = Request.Cookies["userFirstName"],
                LastName = Request.Cookies["userLastName"],
                StreetName = Request.Cookies["userStreetName"],
                PostalCode = int.TryParse(Request.Cookies["userPostalCode"], out var postalCode) ? postalCode : 0,
                City = Request.Cookies["userCity"],
                Email = Request.Cookies["userEmail"],
                CreditCardName = Request.Cookies["userCreditCardName"],

                // Safely parse CreditCardNumber from cookie as long
                CreditCardNumber = long.TryParse(Request.Cookies["userCreditCardNumber"], out var creditCardNumber) ? creditCardNumber : 0,

                // Parse DateOfExpire (it might be stored as a string in the cookie)
                DateOfExpire = DateTime.TryParse(Request.Cookies["userDateOfExpire"], out var expireDate) ? expireDate : DateTime.MinValue,

                // Parse CCV (it is stored as a string, so it is parsed as an integer)
                CCV = int.TryParse(Request.Cookies["userCCV"], out var ccv) ? ccv : 0,

                // You can also set CardType here based on saved cookie if it's available.
                CardType = Request.Cookies["userCardType"]
            };
        }

        // You can also add OnPost method to handle form submissions
    

        public IActionResult OnPost()
        {

            _userService.AddUser(NewUser);


            return RedirectToPage("Index");
        }
    }
}
