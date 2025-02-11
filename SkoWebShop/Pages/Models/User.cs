namespace SkoWebShop.Pages.Models
{
    public class User
    {

      
        

        public User()
        {
            FirstName = "Test";
            LastName = "";
            StreetName = "";
            PostalCode = 0;
            City = "";
            Email = "";
            PhoneNumber = "";
            CardType = "";
            CreditCardName = "";
            CreditCardNumber = 0;
            DateOfExpire = new DateTime();
            this.CCV = 0;
            Password = "";
            IsLoggedIn = false;
        }

        public User(string firstName, string lastName, string streetName, int postalCode, string city, string email, string phoneNumber,string creditCardName, int creditCardNumber, int cardExpirationMonth, int cardExpirationYear, int CCV)
        {

            FirstName = firstName;
            LastName = lastName;
            StreetName = streetName;
            PostalCode = postalCode;
            City = city;
            Email = email;
            PhoneNumber = phoneNumber;
            CardType = "";
            CreditCardName = creditCardName;
            CreditCardNumber = creditCardNumber;
            DateOfExpire = new DateTime(cardExpirationYear, cardExpirationMonth, 1);
            this.CCV = CCV;
            Password = "";
            IsLoggedIn = false;

        }

        public string CardType { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string StreetName { get; set; }

        public int PostalCode { get; set; }

        public string City { get; set; }

        public string CreditCardName { get; set; }

        public int CreditCardNumber { get; set; }

        public DateTime DateOfExpire { get; set; }

        public int CCV { get; set; }
        public string Password { get; set; }

        public bool IsLoggedIn { get; set; }



        public override string ToString()
        {
            return
                $"----------- Customer Details ----------------\n" +
                $"Name: {FirstName} {LastName}\n" +
                   $"Address: {StreetName}, {City}, {PostalCode}\n" +
                   $"Contact: {Email}, {PhoneNumber}\n" +
                   $"Card Type: {CardType} - Credit Card: {CreditCardName} - {CreditCardNumber}\n" +
                   $"Expires: {DateOfExpire:MM/yyyy} | CCV: {CCV}\n" +
                   "----------- Customer Details ----------------";
        }

    }
}
