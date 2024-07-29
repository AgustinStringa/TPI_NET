namespace Entities
{
    public interface IUser
    {

        #region properties
        public int Id { get; set; }
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

    }
}
