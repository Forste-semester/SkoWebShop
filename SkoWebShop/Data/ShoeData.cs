using SkoWebShop.Models;

namespace SkoWebShop.Data
{
    public static class ShoeData
    {


        private static readonly Dictionary<int, Shoe> shoes = new Dictionary<int, Shoe>()
        {
            {1, new Shoe("Jordan",45,"")},
            {2, new Shoe("Sneaker", 42,"") },
            {3, new Shoe("Croc", 38,"") }

        };

        public static Dictionary<int, Shoe> GetAll {  get { return shoes; } }


    }
}
