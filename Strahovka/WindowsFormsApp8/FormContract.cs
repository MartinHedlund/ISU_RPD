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
    public partial class FormContract : Form
    {
        static int number = 0;
        static DateTime date = new DateTime(2020, 1, 1);
        static double sum = 0;
        static double rate = 0;
        static int idFilial = 0;
        static int idType = 0;
        static int idAgent = 0;
        static int idClient = 0;
        
        Contract contr = new Contract(number, date, sum, rate, idFilial, idType, idAgent, idClient);
       public void Visib(bool f)
        {
            
            labelDate.Visible = f;
            labelSum.Visible = f;
            labelRate.Visible = f;
            labelIdFilial.Visible = f;
            labelIdType.Visible = f;
            labelIdClient.Visible = f;
            labelIdAgent.Visible = f;
            textBoxNumber.Visible = f;
            textBoxDate.Visible = f;
            textBoxSum.Visible = f;
            textBoxRate.Visible = f;
            textBoxIdType.Visible = f;
            textBoxIdFilial.Visible = f;
            textBoxidClient.Visible = f;
            textBoxIdAgent.Visible = f;
            buttonOkAdd.Visible = f;
           
        }
        public FormContract()
        {
  
            InitializeComponent();
            textBoxNumber.Visible = false;
            labelIdContr.Visible = false;
            buttonOkRem.Visible = false;
            Visib(false);
        }

        private void FormContract_Load(object sender, EventArgs e)
        {


            textBoxInfo.Text=contr.Print();
        }

        private void buttonAddContract_Click(object sender, EventArgs e)
        {
           Visib(true);
            textBoxNumber.Visible = true;
            labelIdContr.Visible = true;

        }

        private void buttonOkAdd_Click(object sender, EventArgs e)
        {
            contr.Add(Convert.ToInt32(textBoxNumber.Text), Convert.ToDateTime(textBoxDate.Text), Convert.ToDouble(textBoxSum.Text), Convert.ToDouble(textBoxRate.Text), Convert.ToInt32(textBoxIdFilial.Text), Convert.ToInt32(textBoxIdType.Text), Convert.ToInt32(textBoxIdAgent.Text), Convert.ToInt32(textBoxidClient.Text));
            Visib(false);
            textBoxNumber.Visible = false;
            labelIdContr.Visible = false;
            textBoxInfo.Text = contr.Print();
        }

        private void buttonRemoveContract_Click(object sender, EventArgs e)
        {
            labelIdContr.Visible = true;
            textBoxNumber.Visible = true;
            buttonOkRem.Visible = true; 

        }

        private void buttonOkRem_Click(object sender, EventArgs e)
        {
            contr.Del(Convert.ToInt32(textBoxNumber.Text));
            labelIdContr.Visible = false;
            textBoxNumber.Visible = false;
            buttonOkRem.Visible = false;
            textBoxInfo.Text = contr.Print();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMenu fm = new FormMenu();
            fm.ShowDialog();
            this.Close();
            
        }

        private void buttonVyruch_Click(object sender, EventArgs e)
        {
            string a = "Выручка за этот месяц составила:" + contr.StrSum().ToString();
            textBoxInfo.Text += a;
        }

        private void buttonMonth_Click(object sender, EventArgs e)
        {
           textBoxInfo.Text= contr.Print(Convert.ToInt32(textBoxMonth.Text));

        }
    }
}
