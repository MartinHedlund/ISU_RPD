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
    public partial class Form1 : Form
    {
        static int fil = 0;
        static string name = "";
        static string adress = "";
        static string phone = "";
        Filial filil = new Filial(fil, name, adress, phone);
        public Form1()
        {
            InitializeComponent();
            labelAdress.Visible = false;
            labelName.Visible = false;
            labelNumber.Visible = false;
            labelPhone.Visible = false;
            textBoxAdress.Visible = false;
            textBoxName.Visible = false;
            textBoxNumber.Visible = false;
            textBoxPhone.Visible = false;
            buttonAddOk.Visible = false;
            labelNumDel.Visible = false;
            textBoxNumDel.Visible = false;
            buttonRemOk.Visible = false;
            Filial filil = new Filial(fil, name, adress, phone);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxFilial.Text = filil.Print();
           
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            labelAdress.Visible = true;
            labelName.Visible = true;
            labelNumber.Visible = true;
            labelPhone.Visible = true;
            textBoxAdress.Visible = true;
            textBoxName.Visible = true;
            textBoxNumber.Visible = true;
            textBoxPhone.Visible = true;
            buttonAddOk.Visible = true;
        }

        private void buttonAddOk_Click(object sender, EventArgs e)
        {
            filil.Add(Convert.ToInt32(textBoxNumber.Text), textBoxName.Text, textBoxAdress.Text, textBoxPhone.Text);
            labelAdress.Visible = false;
            labelName.Visible = false;
            labelNumber.Visible = false;
            labelPhone.Visible = false;
            textBoxAdress.Visible = false;
            textBoxName.Visible = false;
            textBoxNumber.Visible = false;
            textBoxPhone.Visible = false;
            buttonAddOk.Visible = false;
            textBoxFilial.Text = filil.Print();
        }

        private void buttonRemOk_Click(object sender, EventArgs e)
        {
            filil.Del(Convert.ToInt32(textBoxNumDel.Text));
            labelNumDel.Visible = false;
            textBoxNumDel.Visible = false;
            buttonRemOk.Visible = false;
            textBoxFilial.Text = filil.Print();

        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            labelNumDel.Visible = true;
            textBoxNumDel.Visible = true;
            buttonRemOk.Visible = true;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMenu fm = new FormMenu();
            fm.ShowDialog();
            this.Close();
        }
    }
}
