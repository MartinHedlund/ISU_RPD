using System;
using System.Collections;
using System.Data.Common;

namespace gostinicha
{
    internal class HouseManeger
    {
        private ArrayList List;
        public int ID { get; set; }
        public int Room_number { get; set; }
        public string Status { get; set; }
        public string Arr_Dep_Free { get; set; }
        public string Date_arr { get; set; }
        public string Date_dep { get; set; }
        public ArrayList GetList { get => List; set => List = value; }

        public HouseManeger()
        {
        }

        public ArrayList GetListHouse()
        {
            DataBase db = new DataBase();
            List = new ArrayList();
            ArrayList array = new ArrayList();
            array = db.GetHouseManager();
            foreach (DbDataRecord item in array)
            {
                HouseManeger temp = new HouseManeger();

                temp.ID = Convert.ToInt32(item[0]);
                temp.Room_number = Convert.ToInt32(item[1]);
                temp.Status = item[2].ToString();
                temp.Arr_Dep_Free = item[3].ToString();
                if (item[4] is not DBNull)
                {
                    temp.Date_arr = Convert.ToString(item[4]);
                }
                else
                {
                    temp.Date_arr = "NoN";
                }

                if (item[5] is not DBNull)
                {
                    temp.Date_dep = Convert.ToString(item[5]);
                }
                else
                {
                    temp.Date_dep = "NoN";
                }

                GetList.Add(temp);
            }
            return GetList;
        }


        public ArrayList GetClearNumb()
        {
            ArrayList temp = GetListHouse();
            ArrayList res = new ArrayList();
            foreach (HouseManeger item in temp)
            {
                if (item.Status.Trim('\n') == "Clear" && (item.Arr_Dep_Free.Trim('\n') == "free" || item.Arr_Dep_Free.Trim('\n') == "dep"))
                {
                    res.Add(item);
                }
            }
            return res;
        }
        public string[] GetToString()
        {
            string[] str = new string[] { ID.ToString(), Room_number.ToString(), Arr_Dep_Free, Date_arr.ToString(), Date_dep.ToString() };
            return str;
        }
    }
}
