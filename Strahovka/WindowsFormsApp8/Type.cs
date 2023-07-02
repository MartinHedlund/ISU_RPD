using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp8
{
    class Type
    {
        int idType;
        string name;
        int percent;

        public string Name
        {
            get
            {
                return name;
            }
            
        }
        public int IdType
        {
            get
            {
                return idType;
            }

        }
        public int Percent
        {
            get
            {
                return percent;
            }

        }

        public static List<Type> ty = new List<Type>();
        public Type(int idType, string name,int percent)
        {
            this.idType = idType;
            this.name = name;
            this.percent = percent;
            
        }

        public void StrR()
        {
            string pathIN = "Type.txt";
            StreamReader sr = new StreamReader(pathIN);
            string st = sr.ReadToEnd();

            st = st.Replace("\r", "");
            string[] stm = st.Split('\n');
            int k = 0;
            for (int i = 0; i < stm.Length-1; i++)
            {
                string[] sb = stm[i].Split(' ');
                Type t = new Type(Convert.ToInt32(sb[0]), sb[1], Convert.ToInt32(sb[2]));
                ty.Add(t);
            }

            sr.Close();
        }

        public string Print()
        {
            string s = "";
            foreach (Type a in ty)
            {
                s += $"{ a.idType } {a.name} {a.percent}\r\n ";
                Console.WriteLine(s);
                
            }
            return s;
        }
        public void Add(int idType, string name,int percent)
        {
            string pathOUT = "Type.txt";
            Type t = new Type(idType, name,percent);
            ty.Add(t);
            string s = "";
            StreamWriter sw = new StreamWriter(pathOUT, false);
            foreach (Type a in ty)
            {
                s += $"{ a.idType } {a.name} {a.percent}\n";

            }
            sw.Write(s);
            sw.Close();


        }

        public void Del(int n)
        {
            foreach (Type a in ty)
            {
                if (a.idType == n)
                {
                    ty.Remove(a);
                    break;
                }

            }
            string s = "";
            StreamWriter sw = new StreamWriter("Type.txt", false);
            foreach (Type a in ty)
            {
                s += $"{ a.idType } {a.name} {a.percent}\n";

            }
            sw.Write(s);
            sw.Close();
        }


    }
}