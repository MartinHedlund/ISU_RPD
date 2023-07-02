using System;
using System.Collections;
using System.Windows.Forms;

namespace gostinicha
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
            dataGridView1.Width = this.Width - 250;
            dataGridView2.Width = this.Width - 250;
            dataGridView2.Hide();
            dataGridView3.Hide();
            DataBase dataBase = new DataBase();
            string sql = "SELECT * FROM public.arravils ORDER BY id ASC";
            ArrayList res = dataBase.Select(sql);
            dataGridView1.DataSource = res;
        }


        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var f = dataGridView1.Rows[e.RowIndex];
            DataGridViewCellCollection g = f.Cells; // получааю объект строки таблицы
            ArrayList array = new ArrayList();

            foreach (DataGridViewTextBoxCell item in g)
            {
                array.Add(item.Value);
            }

            Form2 form = new Form2(array);
            this.Hide();
            form.Show();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {

            dataGridView1.Width = this.Width - 250;
            dataGridView2.Width = this.Width - 250;
            dataGridView3.Width = this.Width - 250;
        }

        private void btt_arr_Click(object sender, EventArgs e)
        {
            dataGridView2.Hide();
            dataGridView3.Hide();
            dataGridView1.Show();
            DataBase dataBase = new DataBase();
            string sql = "SELECT * FROM public.arravils ORDER BY id ASC";
            ArrayList res = dataBase.Select(sql);
            dataGridView1.DataSource = res;
        }

        private void btt_HM_Click(object sender, EventArgs e)
        {
            dataGridView1.Hide();
            dataGridView2.Show();
            dataGridView3.Hide();
            dataGridView2.Rows.Clear();
            HouseManeger houseManeger = new HouseManeger();
            var g = houseManeger.GetListHouse();
            DataGridViewComboBoxColumn h = (DataGridViewComboBoxColumn)dataGridView2.Columns[2];
            foreach (HouseManeger item in g)
            {
                string[] arr = item.GetToString();

                dataGridView2.Rows.Add(arr[0], arr[1], h.ValueMember = item.Status, arr[2], arr[3], arr[4]);
            }

        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow temp = dataGridView2.Rows[e.RowIndex];
            DataGridViewCellCollection data = temp.Cells;
            var id = data["ID"].Value;
            var status = data["Status"].Value;
            string sql = $"UPDATE public.house_maneger SET status='{status}' WHERE id = {id};";
            DataBase db = new DataBase();
            db.Update(sql);
        }

        private void btt_reside_Click(object sender, EventArgs e)
        {
            dataGridView1.Hide();
            dataGridView2.Hide();
            dataGridView3.Show();
            DataBase dataBase = new DataBase();
            string sql = "SELECT * FROM public.reside ORDER BY id_iter ASC";
            ArrayList res = dataBase.Select(sql);
            dataGridView3.DataSource = res;

        }

        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var f = dataGridView3.Rows[e.RowIndex];
            DataGridViewCellCollection g = f.Cells; // получааю объект строки таблицы
            ArrayList array = new ArrayList();

            foreach (DataGridViewTextBoxCell item in g)
            {
                array.Add(item.Value);
            }

            Form3 form = new Form3(array);
            this.Hide();
            form.Show();
        }

        private void WalkIn_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            this.Hide();
            form4.Show();
        }
    }
}
