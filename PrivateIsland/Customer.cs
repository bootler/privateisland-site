
namespace PrivateIsland
{
    public class Customer
    {
        public int ID { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public Customer(int id, string fn, string ln, string dob, string email, string phone)
        {
            ID = id;
            FirstName = fn;
            LastName = ln;
            DateOfBirth = dob;
            Email = email;
            Phone = phone;

        }

        public Customer(string fn, string ln, string dob, string email, string phone)
        {
            FirstName = fn;
            LastName = ln;
            DateOfBirth = dob;
            Email = email;
            Phone = phone;
        }
    }
}