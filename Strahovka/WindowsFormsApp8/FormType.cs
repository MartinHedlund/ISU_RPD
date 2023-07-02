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
    public partial class FormType : Form
    {
        static int idType=0;
        static string name="";
        static int percent = 0;
        Type type = new Type(idType, name,percent);
        public FormType()
        {
           

            InitializeComponent();
            labelIdType.Visible = false;
            labelNameType.Visible = false;
            labelPercent.Visible = false;
            textBoxPercent.Visible = false;
            buttonOkRem.Visible = false;
            buttonOkAdd.Visible = false;
            textBoxId.Visible = false;
            textBoxName.Visible = false;
        }

        private void FormType_Load(object sender, EventArgs e)
        {
           
            textBoxInfo.Text = type.Print();
            
        }

        private void buttonAddType_Click(object sender, EventArgs e)
        {
            labelIdType.Visible = true;
            labelNameType.Visible = true;
            buttonOkAdd.Visible = true;
            textBoxId.Visible = true;
            textBoxName.Visible = true;
            labelPercent.Visible = true;
            textBoxPercent.Visible = true;
        }

        private void buttonOkAdd_Click(object sender, EventArgs e)
        {
            type.Add(Convert.ToInt32(textBoxId.Text), textBoxName.Text, Convert.ToInt32(textBoxPercent.Text));
            labelIdType.Visible = false;
            labelNameType.Visible = false;
            buttonOkAdd.Visible = false;
            textBoxId.Visible = false;
            textBoxName.Visible = false;
            labelPercent.Visible = false;
            textBoxPercent.Visible = false;
            textBoxInfo.Text = type.Print();
        }

        private void buttonRemType_Click(object sender, EventArgs e)
        {
            labelIdType.Visible = true;         
            textBoxId.Visible = true;
            buttonOkRem.Visible = true;
        }

        private void buttonOkRem_Click(object sender, EventArgs e)
        {
            type.Del(Convert.ToInt32(textBoxId.Text));
            labelIdType.Visible = false;
            textBoxId.Visible = false;
            buttonOkRem.Visible = false;
            textBoxInfo.Text = type.Print();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            textBoxInfo.Text="";
            FormMenu fm = new FormMenu();
            fm.ShowDialog();
            this.Close();
            
        }
    }
}
