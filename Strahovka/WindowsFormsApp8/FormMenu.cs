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
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void buttonFilial_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
            this.Close();
        }

        private void buttonContract_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormContract fc = new FormContract();
            fc.ShowDialog();
            this.Close();
        }

        private void buttonType_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormType ft = new FormType();
            ft.ShowDialog();
            this.Close();
        }

        private void buttonAgent_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormAgent fa = new FormAgent();
            fa.ShowDialog();
            this.Close();
        }

        private void buttonClient_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormClient fcl = new FormClient();
            fcl.ShowDialog();
            this.Close();
        }
    }
}
