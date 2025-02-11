namespace SkoWebShop.Models
{
    public class Shoe
    {

        private static int NextId = 1;

        public Shoe()
        {
            Name = "";
            Size = 0;
            Type = "";
            Id = NextId++;  
        }

        public Shoe(string name, double size, string type)
        {
            Name = name;
            Size = size;
            Type = type;
            Id = NextId++;
        }

        public int Id { get; }
        public string Type { get; set; }
        public string Src { get; set; } 
        public string Name {  get; set; }
        public double Size { get; set; }


    }
}
