namespace BasicAuth.Models
{
    public class Admin
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public Admin() { }
        public Admin(string fname, string lname, string uname, string pass, string role)
        {
            this.FirstName = fname;
            this.LastName = lname;
            this.UserName = uname;
            this.Password = pass;
            this.Role = role;
        }

        public Admin(string fname, string lname, string pass)
        {
            this.FirstName = fname;
            this.LastName = lname;
            this.UserName = fname.Substring(0, 2) + lname.Substring(0, 2);
            this.Password = pass;
            Role = "Admin";
        }

    }
}
