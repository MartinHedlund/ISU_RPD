using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp8
{
    class Client
    {
        int idClient;
        string surName;
        string name;
        string patron;
        string adress;
        string phone;
        string inn;
        public static List<Client> cl = new List<Client>();

        public string SurName
        {
            get
            {
                return surName;
            }

        }
        public int IdClient
        {
            get
            {
                return idClient;
            }

        }
        public Client(int idClient, string surName, string name, string patron, string adress, string phone, string inn)
        {
            this.idClient = idClient;
            this.surName = surName;
            this.name = name;
            this.patron = patron;
            this.adress = adress;
            this.phone = phone;
            this.inn = inn;
            
        }     
        public void StrR()
        {
            StreamReader sr = new StreamReader("Client.txt");
            string st = sr.ReadToEnd();

            st = st.Replace("\r", "");
            string[] stm = st.Split('\n');
            for (int i = 0; i < stm.Length-1; i++)
            {
                string[] sb = stm[i].Split(' ');
                Client c = new Client(Convert.ToInt32(sb[0]), sb[1], sb[2], sb[3], sb[4], sb[5], sb[6]);
                cl.Add(c);
            }

            sr.Close();
        }

        public string Print()
        {
            string s = "";
            foreach (Client a in cl)
            {
               
                s += $"{a.idClient} { a.surName } {a.name} {a.patron} {a.adress} {a.phone} {a.inn}\r\n";
                Console.WriteLine(s);
                
            }
            return s;
        }
        public void Add(int idClient, string surName, string name, string patron, string adress, string phone, string inn)
        {
            string pathOUT = "CLient.txt";
            Client clien = new Client(idClient, surName, name, patron, adress, phone, inn);
            cl.Add(clien);
            string s = "";
            StreamWriter sw = new StreamWriter(pathOUT, false);
            foreach (Client a in cl)
            {
                s += $"{a.idClient} {a.surName } {a.name} {a.patron} {a.adress} {a.phone} {a.inn}\n";

            }
            sw.Write(s);
            sw.Close();


        }

        public void Del(int n)
        {
            foreach (Client a in cl)
            {
                if (Convert.ToInt32(a.idClient) == n)
                {
                    cl.Remove(a);
                    break;
                }

            }
            string s = "";
            StreamWriter sw = new StreamWriter("Client.txt", false);
            foreach (Client a in cl)
            {
                s += $"{a.idClient} {a.surName } {a.name} {a.patron} {a.adress} {a.phone} {a.inn}\n";

            }
            sw.Write(s);
            sw.Close();
        }
    }
}
