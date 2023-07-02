using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp8
{
    class Contract
    {
         int number;
         DateTime date;
         double sum;
         double rate;
        int idFilial;
         int idType;
         int idAgent;
        int idClient;
        public int Percent { get; set; }
        public int IdType
        {
            get
            {
                return idType;
            }

        }
        public int IdAgent
        {
            get
            {
                return idAgent;
            }
        }
        public double Sum
        {
            get
            {
                return sum;
            }
        }
        public double Rate
        {
            get
            {
                return rate;
            }
        }
        public DateTime Date
        {
            get
            {
                return date;
            }
        }


        public static List<Contract> contr = new List<Contract>();
        public Contract(int number, DateTime date, double sum, double rate, int idFilial, int idType, int idAgent, int idClient)
        {
           
            this.number = number;
            this.date = date;
            this.sum = sum;
            this.rate = rate;
            this.idFilial = idFilial;
            this.idType = idType;
            this.idAgent = idAgent;
            this.idClient = idClient;
        }

        public void StrR()
        {
            StreamReader sr = new StreamReader("Contract.txt");
            string st = sr.ReadToEnd();

            st = st.Replace("\r", "");
            string[] stm = st.Split('\n');

            for (int i = 0; i < stm.Length-1; i++)
            {
                string[] sb = stm[i].Split(' ');
                Contract c = new Contract(Convert.ToInt32(sb[0]), Convert.ToDateTime(sb[1]), Convert.ToDouble(sb[2]), Convert.ToDouble(sb[3]), Convert.ToInt32(sb[4]), Convert.ToInt32(sb[5]), Convert.ToInt32(sb[6]), Convert.ToInt32(sb[7]));
                contr.Add(c);
            }

            sr.Close();
        }

        public string Print()
        {
            string s = "";
            foreach (Contract a in contr)
            {
                Filial f = Filial.fl.FirstOrDefault(l => l.IdFil == a.idFilial);
                Agent ag = Agent.ag.FirstOrDefault(l => l.IdAgent == a.idAgent);
                Type t = Type.ty.FirstOrDefault(l => l.IdType == a.idType);
                Client c = Client.cl.FirstOrDefault(l => l.IdClient == a.idClient);
                s += $"{ a.number } {a.date.ToShortDateString()} {a.sum} {a.rate} {f.Name} {t.Name} {ag.SurName} {c.SurName}\r\n";
                Console.WriteLine(s);
                
            }
            return s;
        }
        public void Add(int number, DateTime date, double sum, double rate, int filial, int type, int idAgent, int idClient)
        {
            string pathOUT = "Contract.txt";
            Contract c = new Contract(number, date, sum, rate, filial, type, idAgent, idClient);
            contr.Add(c);
            string s = "";
            StreamWriter sw = new StreamWriter(pathOUT, false);
            foreach (Contract a in contr)
            {
                s += $"{ a.number } {a.date.ToShortDateString()} {a.sum} {a.rate} {a.idFilial} {a.idType} {a.idAgent} {a.idClient}\n";

            }
            sw.Write(s);
            sw.Close();

        }

        public void Del(int n)
        {
            foreach (Contract a in contr)
            {
                if (a.number == n)
                {
                    contr.Remove(a);
                    break;
                }

            }
            string s = "";
            StreamWriter sw = new StreamWriter("Contract.txt", false);
            foreach (Contract a in contr)
            {
                s += $"{ a.number } {a.date.ToShortDateString()} {a.sum} {a.rate} {a.idFilial} {a.idType} {a.idAgent} {a.idClient}\n";

            }
            sw.Write(s);
            sw.Close();
        }

        public double StrSum()
        {
            double s = 0;
            foreach (Contract a in contr)
            {
                if (a.date.Month == DateTime.Now.Month)
                {
                    s += a.sum;
                }
            }

            return s;
        }

        public string Print(int mon)
        {
            string s = "";
            foreach (Contract a in contr)
            {
                Filial f = Filial.fl.FirstOrDefault(l => l.IdFil == a.idFilial);
                Agent ag = Agent.ag.FirstOrDefault(l => l.IdAgent == a.idAgent);
                Type t = Type.ty.FirstOrDefault(l => l.IdType == a.idType);
                Client c = Client.cl.FirstOrDefault(l => l.IdClient == a.idClient);
                if (a.date.Month == mon)
                {
                    s += $"{ a.number } {a.date.ToShortDateString()} {a.sum} {a.rate} {f.Name} {t.Name} {ag.SurName} {c.SurName}\r\n";
                }

            }
            return s;
        }

    }
}
