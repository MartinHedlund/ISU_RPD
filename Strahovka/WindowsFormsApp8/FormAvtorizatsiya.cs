using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class FormAvtorizatsiya : Form
    {
        public FormAvtorizatsiya()
        {
            InitializeComponent();
        }

        private void buttonVhod_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxLogin.Text) || string.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show("Введите логин и пароль!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
                var user = Users.users.FirstOrDefault(u => u.LoginUser == textBoxLogin.Text && u.PasswordUser == textBoxPassword.Text);
                if (user == null)
                {
                    MessageBox.Show("Пользователь с такими данными не найден!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
               
                 this.Hide();
                 FormMenu fm = new FormMenu();
                 //fm.Owner = this;

                 fm.ShowDialog();
                 this.Close();

        }
    }
}
