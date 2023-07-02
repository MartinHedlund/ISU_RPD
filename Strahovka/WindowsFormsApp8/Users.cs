using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp8
{
    class Users
    {
         int idUser;
         string loginUser;
         string passwordUser;

        public string LoginUser
        {
            get
            {
                return loginUser;
            }
        }
        public string PasswordUser
        {
            get
            {
                return passwordUser;
            }
        }
        public static List<Users> users = new List<Users>();

        public Users (int idUser,string loginUser,string passwordUser)
        {
            this.idUser = idUser;
            this.loginUser = loginUser;
            this.passwordUser = passwordUser;
        }

        public void StrR()
        {
            StreamReader sr = new StreamReader("Users.txt");
            string st = sr.ReadToEnd();

            st = st.Replace("\r", "");
            string[] stm = st.Split('\n');
            for (int i = 0; i < stm.Length - 1; i++)
            {
                string[] sb = stm[i].Split(' ');
                Users u = new Users(Convert.ToInt32(sb[0]), sb[1], sb[2] );
                users.Add(u);
            }

            sr.Close();
        }
    }
}
