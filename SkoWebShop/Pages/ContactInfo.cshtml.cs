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

        }

        public IActionResult OnPost()
        {

            _userService.AddUser(NewUser);


            return RedirectToPage("Index");
        }
    }
}
