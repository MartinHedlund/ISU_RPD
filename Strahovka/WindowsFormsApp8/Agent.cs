using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp8
{
    class Agent
    {
        int idAgent;
        string surName;
        string name;
        string patron;
        string adress;
        string phone;
        int idFilial;
        int oklad = 20000;
        public static List<Agent> ag = new List<Agent>();
        public string SurName
        {
            get
            {
                return surName;
            }
            
        }
        public int IdAgent
        {
            get
            {
                return idAgent;
            }
           
        }

        public Agent(int idAgent, string surName, string name, string patron, string adress, string phone, int idFilial)
        {
            this.idAgent = idAgent;
            this.surName = surName;
            this.name = name;
            this.patron = patron;
            this.adress = adress;
            this.phone = phone;
            this.idFilial = idFilial;
            
        }

  
        public void StrR()
        {
            StreamReader sr = new StreamReader("Agent.txt");
            string st = sr.ReadToEnd();

            st = st.Replace("\r", "");
            string[] stm = st.Split('\n');
            for (int i = 0; i < stm.Length-1; i++)
            {
                string[] sb = stm[i].Split(' ');
                Agent a = new Agent(Convert.ToInt32(sb[0]), sb[1], sb[2], sb[3], sb[4], sb[5], Convert.ToInt32(sb[6]));
                ag.Add(a);
            }

            sr.Close();
        }

        public string Print()
        {
            string s = "";
            foreach (Agent a in ag)
            {
                Filial f = Filial.fl.FirstOrDefault(l => l.IdFil ==a.idFilial);
                s += $" {a.idAgent} { a.surName } {a.name} {a.patron} {a.adress} {a.phone} {f.Name}\r\n";
                Console.WriteLine(s);
                
            }
            return s;

        }
        public void Add(int idAgent, string surName, string name, string patron, string adress, string phone, int idFilial)
        {
            string pathOUT = "Agent.txt";
            Agent agen = new Agent(idAgent, surName, name, patron, adress, phone, idFilial);
            ag.Add(agen);
            string s = "";
            StreamWriter sw = new StreamWriter(pathOUT, false);
            foreach (Agent a in ag)
            {
                s += $"{a.idAgent} {a.surName } {a.name} {a.patron} {a.adress} {a.phone} {a.idFilial}\n";

            }
            sw.Write(s);
            sw.Close();


        }

        public void Del(int n)
        {
            foreach (Agent a in ag)
            {
                if (Convert.ToInt32(a.idAgent) == n)
                {
                    ag.Remove(a);
                    break;
                }

            }
            string s = "";
            StreamWriter sw = new StreamWriter("Agent.txt", false);
            foreach (Agent a in ag)
            {
                s += $"{a.idAgent} {a.surName} {a.name} {a.patron} {a.adress} {a.phone} {a.idFilial}\n";

            }
            sw.Write(s);
            sw.Close();
        }

        public string Salary()
        {
            string s = "";

            var c = from contr in Contract.contr
                    from type in Type.ty
                    let per = type.Percent
                    where contr.IdType == type.IdType
                    select new
                    {
                        contr.IdAgent,
                        contr.Sum,
                        contr.Rate,
                        contr.Date,
                        V = per
                    };


            var l = from agent in ag
                    from contr in c

                    let salary = oklad
                    where agent.idAgent == contr.IdAgent
                    where contr.Date.Month != DateTime.Now.Month
                    select new { agent.idAgent, agent.surName, agent.name, S = salary };

            var t = from agent in ag
                    from contr in c

                    let salary = contr.Sum * contr.Rate * contr.V * 0.01 + oklad
                    where agent.idAgent == contr.IdAgent
                    where contr.Date.Month == DateTime.Now.Month
                    select new { agent.idAgent, agent.surName, agent.name, S = salary };
            l = l.Distinct();
            foreach (var k in l)
            {

                s += $" {k.idAgent} { k.surName} {k.name} {k.S}\r\n";
            }

            foreach (var k in t)
            {

                s += $" {k.idAgent} { k.surName} {k.name} {k.S}\r\n";
            }

            return s;

        }
    }
}