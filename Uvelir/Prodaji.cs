using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uvelir
{
    class Prodaji
    {
        public int ID { get; set; }
        public int KOL { get; set; }
        public string FIO { get; set; }
        public string FAM { get; set; }
        public bool PostClient { get; set; }

        static readonly List<Prodaji> pr = new List<Prodaji>(); //списки для объектов Prodaji
        
        public void StrFile(string Db)
        {
            StreamReader rd = new StreamReader(Db);         

            string st = rd.ReadToEnd();

            st = st.Replace("\r", "");

            string[] stm = st.Split('\n');
            for (int i = 0; i < stm.Length - 1; i++)
            {
                string[] sb = stm[i].Split(' ');
                //добавление нового элемента в список
                pr.Add(new Prodaji() { ID = Convert.ToInt32(sb[0]), FIO = sb[1], KOL = Convert.ToInt32(sb[2]) });
            }
            rd.Close();
        }

        public void InitClient(string Db, int id)
        {
            StrFile(Db);

            foreach (Prodaji p in pr)
            {
                if (p.ID == id)
                {
                    Console.WriteLine("Добро пожаловать, " + p.FIO + "!");
                    if (p.KOL >= 3) 
                        PostClient = true;
                    p.KOL++;
                    FAM = p.FIO;
                }
            }
           
            string s = "";
            StreamWriter sw = new StreamWriter(Db, false);
            foreach (Prodaji a in pr)
            {
                s += $"{ a.ID } {a.FIO} {a.KOL}\n";

            }
            sw.Write(s);
            sw.Close();
        }
        public  void NewClient(string Db) //регистрация нового клиента
        {
            StrFile(Db);
            Prodaji prod = pr.Last();

            Console.WriteLine("{0,70}","РЕГИСТРАЦИЯ");
            int new_id=prod.ID+1; // добавляем в конец списка с новым ид + 1
            Console.Write("Ваше ФИО: ");
            string fio = Console.ReadLine();
            int new_kol = 1;
            pr.Add(new Prodaji() { ID = new_id, FIO = fio, KOL = new_kol });
            string s = "";
            StreamWriter sw = new StreamWriter(Db, false);
            foreach (Prodaji a in pr)
            {
                s += $"{ a.ID } {a.FIO} {a.KOL}\n";

            }
            sw.Write(s);
            sw.Close();
        }

        public void ReWriteClient(string db) 
        {
            StreamReader sr = new StreamReader(db);
            string client = "";
            while (!sr.EndOfStream)
            {
                string vs = sr.ReadLine();
                if (vs.Contains(FIO))
                    client += $"{ID}\t{FIO}\t{KOL}\r\n";
                else client += $"{vs}\r\n";
            }
            sr.Close();
            client.TrimEnd();
            StreamWriter sw = new StreamWriter(db);

            sw.Write(client);

            sw.Close();
        }
    }
}
