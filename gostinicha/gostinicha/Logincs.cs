using System;
using System.Windows.Forms;

namespace gostinicha
{
    public partial class Logincs : Form
    {
        public Logincs()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (login.Text.Trim() == "admin" && pass.Text.Trim() == "admin")
            {
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
                login.Text = "";
                pass.Text = "";
            }
        }
    }
}
