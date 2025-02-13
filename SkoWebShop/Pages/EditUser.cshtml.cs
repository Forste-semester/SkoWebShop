using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using SkoWebShop.Pages.Models;
using SkoWebShop.Pages.Services;
using System.Reflection.Metadata.Ecma335;

namespace SkoWebShop.Pages
{
    public class EditUserModel : PageModel
    {


        private UserService _userService;

        [BindProperty]
        public User NewUser { get; set; }

        public List<User> Users { get; set; }

        public EditUserModel(UserService userService)
        {

            this._userService = userService;

        }
        public void OnGet()
        {
            string userEmail = Request.Cookies["userEmail"];

            if (!string.IsNullOrEmpty(userEmail))
            {
                var user = _userService.GetUserById(userEmail);
                if (user != null)
                {
                    // ✅ Load user data into the form (including contact and payment information)
                    NewUser = new User
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        StreetName = user.StreetName,
                        PostalCode = user.PostalCode,
                        City = user.City,
                        PhoneNumber = user.PhoneNumber,
                        Email = user.Email,

                        // Load payment-related information from the user
                        CardType = user.CardType,                // Example: "Dankort", "Visa", etc.
                        CreditCardName = user.CreditCardName,    // Example: "John Doe"
                        CreditCardNumber = user.CreditCardNumber, // Example: "1234 5678 9876 5432"
                        DateOfExpire = user.DateOfExpire,        // Example: "2025-12"
                        CCV = user.CCV                           // Example: "123"
                    };
                }
            }
        }



        public IActionResult OnPost()
        {
            string userEmail = Request.Cookies["userEmail"];
            string userPassword = Request.Cookies["userPassword"]; // ⚠ Avoid storing passwords in cookies!

            Console.WriteLine(userEmail);
            Console.WriteLine(userPassword);

            if (!string.IsNullOrEmpty(userEmail) && !string.IsNullOrEmpty(userPassword))
            {
                // ✅ Get the user by email and password
                var user = _userService.GetUserByLogin(userEmail, userPassword);

                // ✅ Update user details from the form
                user.FirstName = NewUser.FirstName;
                user.LastName = NewUser.LastName;
                user.StreetName = NewUser.StreetName;
                user.PostalCode = NewUser.PostalCode;
                user.City = NewUser.City;
                user.PhoneNumber = NewUser.PhoneNumber;

                // ✅ Update payment information from the form
                user.CardType = NewUser.CardType;
                user.CreditCardName = NewUser.CreditCardName;
                user.CreditCardNumber = NewUser.CreditCardNumber;  // You may want to encrypt this field before saving to DB
                user.DateOfExpire = NewUser.DateOfExpire;
                user.CCV = NewUser.CCV;

                

                // ✅ Update cookies so the UI displays the new data
                Response.Cookies.Append("userFirstName", user.FirstName, new CookieOptions { Expires = DateTimeOffset.UtcNow.AddHours(24) });
                Response.Cookies.Append("userLastName", user.LastName, new CookieOptions { Expires = DateTimeOffset.UtcNow.AddHours(24) });
                Response.Cookies.Append("userStreetName", user.StreetName, new CookieOptions { Expires = DateTimeOffset.UtcNow.AddHours(24) });
                Response.Cookies.Append("userPostalCode", user.PostalCode.ToString(), new CookieOptions { Expires = DateTimeOffset.UtcNow.AddHours(24) });
                Response.Cookies.Append("userCity", user.City, new CookieOptions { Expires = DateTimeOffset.UtcNow.AddHours(24) });
                Response.Cookies.Append("userPhoneNumber", user.PhoneNumber, new CookieOptions { Expires = DateTimeOffset.UtcNow.AddHours(24) });

                // Update payment-related cookies (you might want to avoid storing sensitive payment info in cookies)
                Response.Cookies.Append("userCardType", user.CardType, new CookieOptions { Expires = DateTimeOffset.UtcNow.AddHours(24) });
                Response.Cookies.Append("userCreditCardName", user.CreditCardName, new CookieOptions { Expires = DateTimeOffset.UtcNow.AddHours(24) });
                Response.Cookies.Append("userCreditCardNumber", user.CreditCardNumber.ToString(), new CookieOptions { Expires = DateTimeOffset.UtcNow.AddHours(24) });
                Response.Cookies.Append("userDateOfExpire", user.DateOfExpire.ToString("yyyy-MM"), new CookieOptions { Expires = DateTimeOffset.UtcNow.AddHours(24) });
                Response.Cookies.Append("userCCV", user.CCV.ToString(), new CookieOptions { Expires = DateTimeOffset.UtcNow.AddHours(24) });

                Console.WriteLine("User edited");

                // ✅ Redirect to stay on EditUser page and see the updated values
                return RedirectToPage("/Login");
            }

            // ❌ If user is not found, return to login page
            return RedirectToPage("/Login");
        }


    }
}

