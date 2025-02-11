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
            Console.WriteLine($"{user.FirstName} has been added");
        } 

        public void PrintAllUsers ()
        {
            
            foreach (User user in users) {

                Console.WriteLine($"{user.ToString}");

            }


        }
        public User GetUserById(string email)
        {
            foreach (var user in users)
            {
                if(user.Email == email) return user;
            }
            return null;
        }
        public User GetUserByLogin(string email, string password)
        {
            foreach (var user in users)
            {
                if (user.Email == email && user.Password == password) return user;
            }
            return null;
        }
    }
}
