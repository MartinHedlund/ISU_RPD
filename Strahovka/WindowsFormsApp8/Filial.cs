using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp8
{
    class Filial
    {
        int idFil;
        string name;
        string adress;
        string phone;

        public string Name
        {
            get
            {
                return name;   
            }

        }
        public int IdFil
        {
            get
            {
                return idFil;    
            }
           
        }

        public static List<Filial> fl = new List<Filial>();
        public Filial(int idFil, string name, string adress, string phone)
        {
           
            this.idFil = idFil;
            this.name = name;
            this.adress = adress;
            this.phone = phone;

        }


        public void StrR()
        {
            StreamReader sr = new StreamReader("Filial.txt");
            string st = sr.ReadToEnd();

            st = st.Replace("\r", "");
            
            string[] stm = st.Split('\n');
            for (int i = 0; i < stm.Length-1; i++)
            {
                string[] sb = stm[i].Split(' ');
                Filial f = new Filial(Convert.ToInt32(sb[0]), sb[1], sb[2], sb[3]);
                fl.Add(f);
            }

            sr.Close();
        }

        public string Print()
        {
            string s = "";
            foreach (Filial a in fl)
            {
                s += $"{ a.idFil } {a.name} {a.adress} {a.phone}\r\n";
                
            }
           
            return s;
        }
        public void Add(int idFil, string name, string adress, string phone)
        {
            string pathOUT = "Filial.txt";
            Filial f = new Filial(idFil, name, adress, phone);
            fl.Add(f);
            string s = "";
            StreamWriter sw = new StreamWriter(pathOUT, false);
            foreach (Filial a in fl)
            {
                s+= $"{ a.idFil } {a.name} {a.adress} {a.phone}\n";

            }
            sw.Write(s);
            sw.Close();


        }

        public void Del(int n)
        {
            foreach (Filial a in fl)
            {
                if (Convert.ToInt32(a.idFil) == n)
                {
                    fl.Remove(a);
                    break;
                }

            }
            string s = "";
            StreamWriter sw = new StreamWriter("Filial.txt", false);
            foreach (Filial a in fl)
            {
                s += $"{ a.idFil } {a.name} {a.adress} {a.phone}\n";

            }
            sw.Write(s);
            sw.Close();
        }


    }
}
