namespace BasicAuth
{
    public class Show
    {
        public void Tampil(List<User> tampil)
        {
            int i = 1;
            foreach (User user in tampil)
            {
                Console.WriteLine("========================");
                Console.WriteLine("ID: " + i);
                Console.WriteLine("Name: " + user.Fname + " " + user.Lname);
                Console.WriteLine("Username: " + user.uname);
                Console.WriteLine("Password: " + user.pass);
                Console.WriteLine("Role: " + user.role);
                Console.WriteLine("========================");
                i++;
            }
        }
        public void Tampil(List<Admin> tampil)
        {
            int i = 1;
            foreach (Admin user in tampil)
            {
                Console.WriteLine("========================");
                Console.WriteLine("ID: " + i);
                Console.WriteLine("Name: " + user.Fname + " " + user.Lname);
                Console.WriteLine("Username: " + user.uname);
                Console.WriteLine("Password: " + user.pass);
                Console.WriteLine("Role: " + user.role);
                Console.WriteLine("========================");
                i++;
            }
        }
        public void TampilSearch(List<User> tampil)
        {
            foreach (User user in tampil)
            {
                Console.WriteLine("========================");
                Console.WriteLine("Name: " + user.Fname + " " + user.Lname);
                Console.WriteLine("Username: " + user.uname);
                Console.WriteLine("Password: " + user.pass);
                Console.WriteLine("Role: " + user.role);
                Console.WriteLine("========================");
            }
        }
        public void TampilSearch(List<Admin> tampil)
        {
            foreach (Admin user in tampil)
            {
                Console.WriteLine("========================");
                Console.WriteLine("Name: " + user.Fname + " " + user.Lname);
                Console.WriteLine("Username: " + user.uname);
                Console.WriteLine("Password: " + user.pass);
                Console.WriteLine("Role: " + user.role);
                Console.WriteLine("========================");
            }
        }
        public void EditUser(List<User> editUser, User userEdit, int id)
        {
            editUser[id - 1].Fname = userEdit.Fname;
            editUser[id - 1].Lname = userEdit.Lname;
            editUser[id - 1].uname = userEdit.Fname.Substring(0, 2) + userEdit.Lname.Substring(0, 2);
            editUser[id - 1].pass = userEdit.pass;
            Console.WriteLine("Data sudah diperbarui");
        }
        public void EditUser(List<Admin> editUser, Admin userEdit, int id)
        {
            editUser[id - 1].Fname = userEdit.Fname;
            editUser[id - 1].Lname = userEdit.Lname;
            editUser[id - 1].uname = userEdit.Fname.Substring(0, 2) + userEdit.Lname.Substring(0, 2);
            editUser[id - 1].pass = userEdit.pass;
            Console.WriteLine("Data sudah diperbarui");
        }
        public void DeleteUser(List<User> deleteUser, int id)
        {
            if (id < 0 || id > deleteUser.Count)
            {
                Console.WriteLine("ID tidak ditemukan");
            }
            else
            {
                deleteUser.RemoveAt(id - 1);
                Console.WriteLine("Data sudah dihapus");
            }
        }
        public void DeleteUser(List<Admin> deleteUser, int id)
        {
            if (id < 0 || id > deleteUser.Count)
            {
                Console.WriteLine("ID tidak ditemukan");
            }
            else
            {
                deleteUser.RemoveAt(id - 1);
                Console.WriteLine("Data sudah dihapus");
            }
        }
        public string CreateUser(List<User> createUser, User userCreate)
        {
            createUser.Add(userCreate);
            string pesan = "User Success to Created!!!";
            return pesan;
        }

        public string CreateAdmin(List<Admin> createUser, Admin AdminCreate)
        {
            createUser.Add(AdminCreate);
            string pesan = "Admin Success to Created!!!";
            return pesan;
        }
    }
}
