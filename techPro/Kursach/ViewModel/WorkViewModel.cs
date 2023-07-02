using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace Kursach
{
    internal class WorkViewModel
    {
        public List<UchetModel> GetAllWork()
        {
            List<UchetModel> output = new List<UchetModel>();
            SQLRequest request = new SQLRequest();
            string qwery = "SELECT WorkProblem.* " +
                "FROM[WorkProblem];";
            OleDbDataReader reader = request.Select(qwery);
            while (reader.Read())
            {
                UchetModel work = new UchetModel();
                work.Id_work = Convert.ToInt32(reader.GetValue(0));
                work.Discription = Convert.ToString(reader.GetValue(1));
                output.Add(work);
            }
            reader.Close();
            request.Close();
            return output;
        }
    }
}
