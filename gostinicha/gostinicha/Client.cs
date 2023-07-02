using System;
using System.Collections;

namespace gostinicha
{
    internal class Client
    {
        public int ID { get; set; }
        public string FIO { get; set; }
        public string Room_type { get; set; }
        public int Room_number { get; set; }
        public DateTime Date_arr { get; set; }
        public DateTime Date_dep { get; set; }
        public double Per { get; set; }
        public string Desc { get; set; }

        public Client(ArrayList e)
        {
            ID = Convert.ToInt32(e[0]);
            FIO = e[1].ToString();
            Room_type = e[2].ToString();
            try
            {
                Room_number = Convert.ToInt32(e[3]);
            }
            catch (Exception)
            {
                Room_number = 0;
            }
            Per = Convert.ToDouble(e[6]);
            Date_arr = Convert.ToDateTime(e[4]);
            Date_dep = Convert.ToDateTime(e[5]);
            Desc = e[7].ToString() == "" ? null : e[7].ToString();
        }
    }
}
