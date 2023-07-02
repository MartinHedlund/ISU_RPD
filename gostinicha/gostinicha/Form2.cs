using System;
using System.Collections;
using System.Data.Common;
using System.Windows.Forms;

namespace gostinicha
{
    public partial class Form2 : Form
    {
        private double permistion;
        private int id;
        public Form2(ArrayList e)
        {
            Client client = new Client(e);
            InitializeComponent();
            DataBase dataBase = new DataBase();
            id = client.ID;
            fio.Text = client.FIO;
            room_type.Text = client.Room_type;
            date_arr.Text = client.Date_arr.ToShortDateString();
            date_dep.Text = client.Date_dep.ToShortDateString();
            night.Text = (client.Date_dep - client.Date_arr).TotalDays.ToString();
            HouseManeger houseManeger = new HouseManeger();
            ArrayList arr = new ArrayList();
            arr = houseManeger.GetClearNumb();
            ArrayList all_list = new ArrayList();
            all_list = houseManeger.GetListHouse();
            foreach (HouseManeger item in all_list)
            {
                if (item.Room_number.ToString() == e[3].ToString())
                {
                    arr.Insert(0, item);
                }
            }

            room_numb.DataSource = arr;
            room_numb.DisplayMember = "Room_number";
            string sql = $"SELECT price FROM public.room_type where type = '{room_type.Text}';";
            ArrayList priceDB = dataBase.Select(sql);
            foreach (DbDataRecord item in priceDB)
            {
                room_price.Text = item["price"].ToString();
            }

            lb_des.Text = client.Desc == null ? " " : client.Desc;
            permistion = client.Per;
            Rechet();
        }

        private void Rechet()
        {
            if (night.Text == "0")
            {
                night.Text = "1";
            }

            double saleCh = -(Convert.ToInt32(room_price.Text) * Convert.ToInt32(night.Text) * Convert.ToDouble(permistion));
            sale.Text = "Cкидака: " + saleCh;
            full_cost.Text = ((Convert.ToInt32(room_price.Text) * Convert.ToInt32(night.Text)) + saleCh).ToString();

        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
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
            string rn = room_numb.GetItemText(room_numb.SelectedValue);
            string rn_id = ((HouseManeger)room_numb.SelectedItem).ID.ToString();
            string des = lb_des.Text == null ? null : "null";
            string sql = $"INSERT INTO public.reside (id, \"FIO\", room_type, room_num, date_arr, date_dep, perm, \"desc\") " +
                $"VALUES({id}, \'{fio.Text}\', " +
                $"\'{room_type.Text}\', {rn}, " +
                $"\'{date_arr.Text}\', " +
                $"\'{date_dep.Text}\', " +
                $"{permistion.ToString("f", System.Globalization.CultureInfo.GetCultureInfo("en-US"))}, " +
                $"\'{lb_des.Text}\');";
            string sqlD = $"DELETE FROM public.arravils WHERE id = {id}; ";
            string sqlUR = $"UPDATE public.house_maneger " +
                $"SET status = \'Dirty\', " +
                $"\"arr/dep/free\" = \'arr\', " +
                $"date_arr = \'{date_arr.Text}\'," +
                $" date_dep = \'{date_dep.Text}\'" +
                $" WHERE id ={rn_id};";

            DataBase dataBase = new DataBase();
            dataBase.Update(sql);
            dataBase.Update(sqlD);
            dataBase.Update(sqlUR);
            MessageBox.Show("Заселен!");
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
           
        }
    }
}
