namespace BasicAuth
{
    public class Admin
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string uname { get; set; }
        public string pass { get; set; }
        public string role { get; set; }
        public Admin() { }
        public Admin(string fname, string lname, string uname, string pass, string role)
        {
            this.Fname = fname;
            this.Lname = lname;
            this.uname = uname;
            this.pass = pass;
            this.role = role;
        }

        public Admin(string fname, string lname, string pass)
        {
            this.Fname = fname;
            this.Lname = lname;
            this.uname = fname.Substring(0, 2) + lname.Substring(0, 2);
            this.pass = pass;
            this.role = "Admin";
        }

    }
}
