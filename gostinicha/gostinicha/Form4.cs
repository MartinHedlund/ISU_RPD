using System;
using System.Collections;
using System.Data.Common;
using System.Windows.Forms;

namespace gostinicha
{
    public partial class Form4 : Form
    {
        private ArrayList array_room_type;
        private ArrayList array;
        private double perm;
        public Form4()
        {
            InitializeComponent();
            array_room_type = new ArrayList();
            DataBase dataBase = new DataBase();
            array_room_type = dataBase.GetRoomType();
            cm_room_type.DataSource = array_room_type;
            cm_room_type.DisplayMember = "type";
            HouseManeger houseManeger = new HouseManeger();
            array = houseManeger.GetClearNumb();
            array.Insert(0, new HouseManeger());
            room_numb.DataSource = array;
            room_numb.DisplayMember = "Room_number";
            night.Text = Convert.ToString(Math.Round((date_dep.Value - date_arr.Value).TotalDays));
            if (Convert.ToInt32(night.Text) <= 0)
            {
                night.Text = "1";
            }

            Rechet();
        }

        private void cm_room_type_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            DbDataRecord f = (DbDataRecord)combo.SelectedItem;
            foreach (DbDataRecord item in array_room_type)
            {
                if (item["type"].ToString() == f["type"].ToString())
                {
                    cm_room_type.SelectedItem = item;
                    room_price.Text = item["price"].ToString();
                }
            }
            Rechet();
        }
        private void Rechet()
        {
            if (night.Text == "0")
            {
                night.Text = "1";
            }

            night.Text = Convert.ToString(Math.Round((date_dep.Value - date_arr.Value).TotalDays));
            double saleCh = -(Convert.ToInt32(room_price.Text) * Convert.ToInt32(night.Text) * Convert.ToDouble(perm));
            sale.Text = "Cкидака: " + saleCh;
            full_cost.Text = ((Convert.ToInt32(room_price.Text) * Convert.ToInt32(night.Text) + saleCh).ToString());
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string rn_id;
            if (room_numb.Text == "")
            {
                room_numb.Text = "null";
                rn_id = "null";
            }
            else
                rn_id = ((HouseManeger)room_numb.SelectedItem).ID.ToString();
            string sql = "INSERT INTO public.arravils (\"FIO\", room_type, room_num, date_arr, date_dep, perm, \"desc\") " +
                $"VALUES(\'{tb_fio.Text}\', " +
                $"\'{cm_room_type.Text}\', " +
                $"{room_numb.Text}, " +
                $"\'{date_arr.Text}\', " +
                $"\'{date_dep.Text}\', " +
                $"{perm.ToString("f", System.Globalization.CultureInfo.GetCultureInfo("en-US"))}, " +
                $"\'{tb_des.Text}\'); ";
            string sqlUR = $"UPDATE public.house_maneger " +
                $"SET status = \'Clear\', " +
                $"\"arr/dep/free\" = \'arr\', " +
                $"date_arr = \'{date_arr.Text}\', " +
                $"date_dep = \'{date_dep.Text}\' " +
                $"WHERE id ={rn_id};";
            DataBase data = new DataBase();
            data.Update(sql);
            data.Update(sqlUR);
            MessageBox.Show("Бронь создана!");
            this.Close();
            Form1 form1 = new Form1();
            form1.Show();
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

        private void date_dep_ValueChanged(object sender, EventArgs e)
        {
            Rechet();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }
    }
}
