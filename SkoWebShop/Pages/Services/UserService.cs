using SkoWebShop.Pages.Models;

namespace SkoWebShop.Pages.Services
{
    public class UserService
    {
        private List<User> users = new List<User>();

        public UserService() { 
        
          
        }


        public void AddUser(User user)
        {
            users.Add(user);
            Console.WriteLine($"{user} has been added");
        } 

        public void PrintAllUsers ()
        {
            
            foreach (User user in users) {

                Console.WriteLine($"{user.ToString}");

            }


        }
    }
}
