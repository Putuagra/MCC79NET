namespace BasicAuth.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public User() { }
        public User(string fname, string lname, string pass)
        {
            this.FirstName = fname;
            this.LastName = lname;
            this.Username = fname.Substring(0, 2) + lname.Substring(0, 2);
            this.Password = pass;
            this.Role = "User";
        }

    }
}
