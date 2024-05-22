namespace Entities
{
    public abstract class User
    {
        #region fields
        private string _Username;
        private string _Password;
        private bool _Authorized;
        private string _Email;
        private string _Name;
        private string _Lastname;
        private string _Address;
        private string _PhoneNumber;
        private DateTime _BirthDate;
        #endregion

        #region properties
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Authorized { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        #endregion


        #region constructors
        public User(string username, 
            string password, 
            string email,
            string name, 
            string lastname, 
            string address,
            string phonenumber,
            DateTime birthdate
            ) { 
            _Username = username;
            _Password = password;
            _Email = email;
            _Name = name;
            _Lastname = lastname;
            _Address = address;
            _PhoneNumber    = phonenumber;
            _BirthDate = birthdate;
            _Authorized = true;
        }
        #endregion

        public string getDescription() {
            string description = "";
            description += _Name+" ";
            description += _Lastname+" ";
            description += _Username+" ";
            description += _Email+" ";

            return description;
        }
    }
}
