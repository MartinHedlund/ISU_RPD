using System;
using System.Collections;

namespace gostinicha
{
    internal class Reside
    {
        public int ID_iter { get; set; }
        public int ID { get; set; }
        public string FIO { get; set; }
        public string Room_type { get; set; }
        public int Room_number { get; set; }
        public DateTime Date_arr { get; set; }
        public DateTime Date_dep { get; set; }
        public double Per { get; set; }
        public string Desc { get; set; }
        public Reside(ArrayList e)
        {
            ID_iter = Convert.ToInt32(e[0]);
            ID = Convert.ToInt32(e[1]);
            FIO = e[2].ToString();
            Room_type = e[3].ToString();
            try
            {
                Room_number = Convert.ToInt32(e[4]);
            }
            catch (Exception)
            {
                Room_number = 0;
            }
            Per = Convert.ToDouble(e[5]);
            Date_arr = Convert.ToDateTime(e[6]);
            Date_dep = Convert.ToDateTime(e[7]);
            Desc = e[8].ToString() == "" ? null : e[8].ToString();
        }
    }
}
