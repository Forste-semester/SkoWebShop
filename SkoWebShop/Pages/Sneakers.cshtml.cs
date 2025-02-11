using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SkoWebShop.Models;
using SkoWebShop.Services;

namespace SkoWebShop.Pages
{
    public class SneakersModel : PageModel
    {
        private readonly ShoeService shoeService;


        [BindProperty]
        public List<Shoe> shoes { get; set; }

        public SneakersModel(ShoeService shoeService)
        {
            this.shoeService = shoeService;
        }




        public void OnGet()
        {
            shoes = shoeService.GetAll();

        }

        public IActionResult OnPost()
        {

            return RedirectToPage();
        }

    }
}
