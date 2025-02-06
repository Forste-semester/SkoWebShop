using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SkoWebShop.Models;
using SkoWebShop.Services;

namespace SkoWebShop.Pages
{
    public class ProductModel : PageModel
    {
        public Shoe Product { get; set; } // Change Dictionary<int, Shoe> to a single Shoe object
        private readonly ShoeService _shoeService; // Use dependency injection for the service

        public ProductModel(ShoeService shoeService)
        {
            _shoeService = shoeService;
        }

        public void OnGet(int id)
        {
            Product = _shoeService.GetById(id); // Fetch the shoe using the provided ID
        }
    }
}
