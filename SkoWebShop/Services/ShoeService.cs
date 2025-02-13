using SkoWebShop.Data;
using SkoWebShop.Models;
namespace SkoWebShop.Services
{
    public class ShoeService
    {
        private Dictionary<int, Shoe> _services;

        public ShoeService()
        {
            _services = ShoeData.GetAll;

        }


        public List<Shoe> GetAll()
        {
            return _services.Values.ToList();
        }

        public Shoe GetById(int id)
        {
            return _services[id];
        }


    }
}
