namespace BasicAuth
{
    public class User
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string uname { get; set; }
        public string pass { get; set; }
        public string role { get; set; }
        public User() { }
        public User(string fname, string lname, string pass)
        {
            this.Fname = fname;
            this.Lname = lname;
            this.uname = fname.Substring(0, 2) + lname.Substring(0, 2);
            this.pass = pass;
            this.role = "User";
        }

    }
}
