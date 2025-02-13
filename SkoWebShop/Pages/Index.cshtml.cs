using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SkoWebShop.Models;
using SkoWebShop.Services;

namespace SkoWebShop.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ShoeService shoeService;
        public Shoe Shoe { get; set; }

        [BindProperty]
        public List<Shoe> shoes { get; set; }

        public IndexModel(ShoeService shoeService)
        {
            this.shoeService = shoeService;
        }




        public void OnGet()
        {
            shoes = shoeService.GetAll();
        }
    }
}