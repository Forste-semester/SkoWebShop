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
                    // ✅ Load user data into the form
                    NewUser = new User
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        StreetName = user.StreetName,
                        PostalCode = user.PostalCode,
                        City = user.City,
                        PhoneNumber = user.PhoneNumber,
                        Email = user.Email
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
                var user = _userService.GetUserByLogin(userEmail, userPassword);
                    // ✅ Update user details
                     user.FirstName = NewUser.FirstName;
                    user.LastName = NewUser.LastName;
                    user.StreetName = NewUser.StreetName;
                    user.PostalCode = NewUser.PostalCode;
                    user.City = NewUser.City;
                    user.PhoneNumber = NewUser.PhoneNumber;

                    // ✅ Save updated user in the database
                    _userService.UpdateUser(user);

                    // ✅ Update cookies so the UI displays the new data
                    Response.Cookies.Append("userFirstName", user.FirstName, new CookieOptions { Expires = DateTimeOffset.UtcNow.AddHours(24) });
                    Response.Cookies.Append("userLastName", user.LastName, new CookieOptions { Expires = DateTimeOffset.UtcNow.AddHours(24) });
                    Response.Cookies.Append("userStreetName", user.StreetName, new CookieOptions { Expires = DateTimeOffset.UtcNow.AddHours(24) });
                    Response.Cookies.Append("userPostalCode", user.PostalCode.ToString(), new CookieOptions { Expires = DateTimeOffset.UtcNow.AddHours(24) });
                    Response.Cookies.Append("userCity", user.City, new CookieOptions { Expires = DateTimeOffset.UtcNow.AddHours(24) });
                    Response.Cookies.Append("userPhoneNumber", user.PhoneNumber, new CookieOptions { Expires = DateTimeOffset.UtcNow.AddHours(24) });

                    Console.WriteLine("User edited");
                    // ✅ Redirect to stay on EditUser page and see the updated values
                    return RedirectToPage("/Login");
            }

            // ❌ If user is not found, return to login page
            return RedirectToPage("/Login");
        }

    }
}

