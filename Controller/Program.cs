// See https://aka.ms/new-console-template for more information
using SkoWebShop.Pages.Models;
using SkoWebShop.Pages.Services;

Console.WriteLine("Hello, World!");

UserService userservice = new UserService();

User user = new User("fname", "lname", "street name", 4180, "Sorø", "madshammer@hotmail.com", "32323232", "creditcardname", 9999999, 10, 2027, 333 );

User user2 = new User("fname2", "lname", "street name", 4180, "Sorø", "madshammer@hotmail.com", "32323232", "creditcardname", 9999999, 10, 2027, 333);

userservice.AddUser(user);
userservice.AddUser(user2);

 userservice.PrintAllUsers();



