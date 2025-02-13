using SkoWebShop.Models;
using System.Collections.Generic;
using System.Text;

namespace SkoWebShop
{
    public class Cart
    {
        public Cart()
        {
            CartList = new List<Shoe>();
        }

        public List<Shoe> CartList { get; set; }
        public string Total { get; set; }

        public double TotalPrice()
        {
            double totalPrice = 0;
            foreach (Shoe shoe in CartList)
            {
                totalPrice += shoe.Price;
            }
            return totalPrice;
        }

        public void AddToCart(Shoe shoe)
        {
            CartList.Add(shoe);
        }

        public void RemoveFromCart(int id)
        {
            CartList.RemoveAll(s => s.Id == id);
        }

        public string CartListToString()
        {
            if (CartList != null && CartList.Count > 0)
            {
                StringBuilder cartString = new StringBuilder();

                foreach (var shoe in CartList)
                {
                    cartString.AppendLine($"Shoe: {shoe.Name}, Price: {shoe.Price:C}");
                }

                return cartString.ToString();
            }
            return "Your cart is empty.";
        }
    }
}
