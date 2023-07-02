using System;
using System.Collections;
using System.Data.Common;
using System.Windows.Forms;

namespace gostinicha
{
    public partial class Form3 : Form
    {
        private ArrayList array_room_type;
        private double perm;
        private int id;
        int old_numb_id;
        public Form3(ArrayList e)
        {
            InitializeComponent();
            id = Convert.ToInt32(e[0]);
            array_room_type = new ArrayList();
            DataBase dataBase = new DataBase();
            array_room_type = dataBase.GetRoomType();
            cm_room_type.DataSource = array_room_type;
            cm_room_type.DisplayMember = "type";
            foreach (DbDataRecord item in array_room_type)
                if (item["type"].ToString() == e[3].ToString())
                {
                    cm_room_type.SelectedItem = item;
                    room_price.Text = item["price"].ToString();
                }
            date_arr.Value = Convert.ToDateTime(e[5]);
            date_dep.Value = Convert.ToDateTime(e[6]);
            night.Text = (date_dep.Value - date_arr.Value).TotalDays.ToString();
            tb_fio.Text = (String)e[2];
            tb_des.Text = (String)e[8];
            HouseManeger houseManeger = new HouseManeger();
            ArrayList arr = new ArrayList();
            arr = houseManeger.GetClearNumb();
            ArrayList all_list = new ArrayList();
            all_list = houseManeger.GetListHouse();
            foreach (HouseManeger item in all_list)
                if (item.Room_number.ToString() == e[4].ToString())
                    arr.Insert(0, item);
            room_numb.DataSource = arr;
            room_numb.DisplayMember = "Room_number";
            old_numb_id = ((HouseManeger)room_numb.SelectedItem).ID;
            perm = (double)e[7];
            tb_perm.Text = perm.ToString();
            Rechet();
        }

        private void cm_room_type_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            DbDataRecord f = (DbDataRecord)combo.SelectedItem;
            foreach (DbDataRecord item in array_room_type)
            {
                if (item["type"].ToString().Trim('\r') == f["type"].ToString())
                {
                    cm_room_type.SelectedItem = item;
                    room_price.Text = item["price"].ToString();
                }
            }
        }
        private void Rechet()
        {
            if (night.Text == "0")
            {
                night.Text = "1";
            }

            double saleCh = -(Convert.ToInt32(room_price.Text) * Convert.ToInt32(night.Text) * Convert.ToDouble(perm));
            sale.Text = "Cкидака: " + saleCh;
            full_cost.Text = ((Convert.ToInt32(room_price.Text) * Convert.ToInt32(night.Text)) + saleCh).ToString();

        }
        private void num_pers_ValueChanged(object sender, EventArgs e)
        {
            Rechet();
            if (num_pers.Value > 1)
            {
                full_cost.Text = (Convert.ToInt32(full_cost.Text) + Convert.ToInt32(num_pers.Value * 550)).ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string type = cm_room_type.Text;
            perm = Convert.ToDouble(tb_perm.Text);
            string sql = "UPDATE public.reside " +
                $"SET \"FIO\" =\'{tb_fio.Text}\', " +
                $"room_type =\'{type}\', " +
                $"room_num ={room_numb.Text}, " +
                $"date_arr =\'{date_arr.Text}\', " +
                $"date_dep =\'{date_dep.Text}\', " +
                $"perm ={perm.ToString("f", System.Globalization.CultureInfo.GetCultureInfo("en-US"))}, " +
                $"\"desc\" =\'{tb_des.Text}\' " +
                $"WHERE id_iter = {id}";

            string sqlUR = $"UPDATE public.house_maneger " +
                $"SET status = \'Drity\', \"arr/dep/free\" = \'dep\', date_arr = null, date_dep = null " +
                $"WHERE id ={old_numb_id};";
            DataBase dataBase = new DataBase();
            dataBase.Update(sql);
            dataBase.Update(sqlUR);
            MessageBox.Show("Данные изменнены");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void tb_perm_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != ',' && !Char.IsControl(number))
            {
                e.Handled = true;
            }
            if (number == 13)
            {
                perm = Convert.ToDouble(tb_perm.Text);
                Rechet();
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string rn_id = ((HouseManeger)room_numb.SelectedItem).ID.ToString();

            string sql = $"DELETE from reside WHERE id_iter = {id}";
            string sqlUR = $"UPDATE public.house_maneger " +
                $"SET status = \'Dirty\', " +
                $"\"arr/dep/free\" = \'dep\', " +
                $"date_arr = null, " +
                $"date_dep = null " +
                $"WHERE id ={rn_id};";

            DataBase dataBase = new DataBase();
            dataBase.Update(sql);
            dataBase.Update(sqlUR);
            MessageBox.Show("Выселен!");
            this.Close();
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}