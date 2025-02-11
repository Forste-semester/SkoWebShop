using Microsoft.VisualBasic;
using SkoWebShop.Pages.Models;

namespace SkoWebShop.Pages.Services
{
    public class UserService
    {
        private List<User> users = new List<User>();

        public UserService() 
        { 
        
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



        public void UpdateUser(User updatedUser)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Email == updatedUser.Email) // Find user by email
                {
                    // ✅ Update user properties
                    users[i].FirstName = updatedUser.FirstName;
                    users[i].LastName = updatedUser.LastName;
                    users[i].StreetName = updatedUser.StreetName;
                    users[i].PostalCode = updatedUser.PostalCode;
                    users[i].City = updatedUser.City;
                    users[i].PhoneNumber = updatedUser.PhoneNumber;

                    Console.WriteLine($"User {updatedUser.Email} updated successfully.");
                    return;
                }
            }
            Console.WriteLine("User not found!");
        }

    }
}
