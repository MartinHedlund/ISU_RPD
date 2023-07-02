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
    public partial class FormClient : Form
    {
        static int idClient=0;
        static string surName ="";
        static string name = "";
        static string patron = "";
        static string adress = "";
        static string phone = "";
        static string inn = "";
        Client client = new Client(idClient,surName,name,patron,adress,phone,inn);

        void VisibAdd(bool f)
        {
            labelSurName.Visible = f;
            labelName.Visible = f;
            labelPatron.Visible = f;
            labelAdress.Visible = f;
            labelPhone.Visible = f;
            labelInn.Visible = f;
            textBoxSuraName.Visible = f;
            textBoxName.Visible = f;
            textBoxPatron.Visible = f;
            textBoxAdress.Visible = f;
            textBoxPhone.Visible = f;
            textBoxInn.Visible = f;
            buttonOkAdd.Visible = f;
            labelIdCl.Visible = f;
            textBoxIdClient.Visible = f;
            
        }
        void VisibDel(bool f)
        {
            buttonOkDel.Visible = f;
            labelIdCl.Visible = f;
            textBoxIdClient.Visible = f;

        }
        public FormClient()
        {
            
            InitializeComponent();
            VisibAdd(false);
            VisibDel(false);
        }

        private void FormClient_Load(object sender, EventArgs e)
        {
            
            textBoxInfo.Text = client.Print();
        }

        private void buttonAddClient_Click(object sender, EventArgs e)
        {
            VisibAdd(true);
           
        }

        private void buttonOkDel_Click(object sender, EventArgs e)
        {
            client.Del(Convert.ToInt32(textBoxIdClient.Text));
            VisibDel(false);
            textBoxInfo.Text = client.Print();
        }

        private void buttonDelClient_Click(object sender, EventArgs e)
        {
            VisibDel(true);
        }

        private void buttonOkAdd_Click(object sender, EventArgs e)
        {
            client.Add(Convert.ToInt32(textBoxIdClient.Text), textBoxSuraName.Text, textBoxName.Text, textBoxPatron.Text, textBoxAdress.Text, textBoxPhone.Text, textBoxInn.Text);
            VisibAdd(false);
            
            textBoxInfo.Text = client.Print();
          
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
