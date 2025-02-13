using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SkoWebShop.Models;
using SkoWebShop.Services;
using System;

namespace SkoWebShop.Pages
{
    public class LoginModel : PageModel
    {

        private UserService _userService;

        [BindProperty]

        public User NewUser { get; set; }

       

        public LoginModel(UserService userService)
        {

            this._userService = userService;

        }
        public void OnGet()
        {
          

        }

        public IActionResult OnPost(string action)
        {
            if (action == "login")
            {
                var user = _userService.GetUserByLogin(NewUser.Email, NewUser.Password);
                if (user != null)
                {
                    // User successfully logged in
                    user.IsLoggedIn = true;
                    Console.WriteLine($"{user.Email} Logged in");

                    // Store user information in cookies
                    Response.Cookies.Append("isLoggedIn", "true", new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddHours(24),
                        Path = "/"
                    });                    
                    Response.Cookies.Append("userFirstName", user.FirstName, new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddHours(24),
                        Path = "/"
                    });
                    Response.Cookies.Append("userLastName", user.LastName, new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddHours(24),
                        Path = "/"
                    });
                    Response.Cookies.Append("userStreetName", user.StreetName, new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddHours(24),
                        Path = "/"
                    });
                    Response.Cookies.Append("userPostalCode", user.PostalCode.ToString(), new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddHours(24),
                        Path = "/"
                    });
                    Response.Cookies.Append("userCity", user.City, new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddHours(24),
                        Path = "/"
                    });
                    Response.Cookies.Append("userEmail", user.Email, new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddHours(24),
                        Path = "/"
                    });
                    Response.Cookies.Append("userPassword", user.Password, new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddHours(24),
                        Path = "/"
                    });
                    Response.Cookies.Append("userPhoneNumber", user.PhoneNumber, new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddHours(24),
                        Path = "/"
                    });
                    Response.Cookies.Append("userCreditCardName", user.CreditCardName, new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddHours(24),
                        Path = "/"
                    });
                    Response.Cookies.Append("userCreditCardNumber", user.CreditCardNumber.ToString(), new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddHours(24),
                        Path = "/"
                    });
                    Response.Cookies.Append("userDateOfExpire", user.DateOfExpire.ToString("yyyy-MM-dd"), new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddHours(24),
                        Path = "/"
                    });
                    Response.Cookies.Append("userCCV", user.CCV.ToString(), new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddHours(24),
                        Path = "/"
                    });
                    Response.Cookies.Append("newsLetterSubscribed", user.NewsLetter.ToString(), new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddHours(24),
                        Path = "/"
                    });


                    // Redirect to the logged-in page or dashboard
                    return RedirectToPage("/Index");
                }
            }
            else if (action == "create")
            {
                // Logic for creating a new user
                _userService.AddUser(NewUser);
                Console.WriteLine($"{NewUser.Email} created");
                return RedirectToPage("/Login");
            }

            // Return the page if something went wrong
            return Page();
        }

        public IActionResult OnPostSubscribeToNewsletter()
        {
            // Update the NewsLetter subscription status to true
            Response.Cookies.Append("newsLetterSubscribed", "true", new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddHours(24),  // Set expiration date to 24 hours
                Path = "/"  // Set path to ensure it’s accessible across the site
            });

            // Redirect to the current page to refresh the UI
            return RedirectToPage();
        }

        public IActionResult OnPostUnsubscribeFromNewsletter()
        {
            // Remove the newsletter subscribed cookie
            Response.Cookies.Delete("newsLetterSubscribed");

            // Optionally, add logic to handle the unsubscribe process (e.g., removing from the newsletter database)
            return RedirectToPage();
        }

        public IActionResult OnPostLogout()
        {
            // Clear cookies
            Response.Cookies.Delete("isLoggedIn");
            Response.Cookies.Delete("userFirstName");
            Response.Cookies.Delete("userLastName");
            Response.Cookies.Delete("userStreetName");
            Response.Cookies.Delete("userPostalCode");
            Response.Cookies.Delete("userCity");
            Response.Cookies.Delete("userEmail");
            Response.Cookies.Delete("userPhoneNumber");
            Response.Cookies.Delete("userCreditCardName");
            Response.Cookies.Delete("userCreditCardNumber");
            Response.Cookies.Delete("userDateOfExpire");
            Response.Cookies.Delete("userCCV");
            Response.Cookies.Delete("newsLetterSubscribed");

            Console.WriteLine("User Logged out");

            // Redirect to the login page or home page
            return RedirectToPage("/Login");
        }

    }
}
