using SkoWebShop.Data;

namespace SkoWebShop.Models
{
    public class Shoe
    {

        private static int NextId = 1;

        public Shoe()
        {
            Name = "";
            Size = 0;
            Type = ShoeType.Default;
            Price = 0;
            Id = NextId++;
            Image = "";
        }

        public Shoe(string name, double size, ShoeType type, double price, string image)
        {
            Price = price;
            Name = name;
            Size = size;
            Type = type;
            Id = NextId++;
            Image = "https://www.purebrandsuk.com/images/crocs-classic-lined-black-black-ux3-203591-060-unisex-shoes-clogs-p2789-12757_medium.jpg";
        }

        public string Image { get; set; }

        public double Price { get; set; }
        public int Id { get; }
        public ShoeType Type { get; set; }
        public string Src { get; set; } 
        public string Name {  get; set; }
        public double Size { get; set; }

        
    }
}
