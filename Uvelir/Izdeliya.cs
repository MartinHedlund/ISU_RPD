using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uvelir
{
     class Izdeliya
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public double Gramm { get; set; }
        private double Cost { get; set; }

        public Material[] materials;
        public double FullCost  // считается полная цена материала*граммы изделия + цена изделия
        {
            get
            {
                double full = 0;
                foreach (var cost in materials)
                    full += cost.Cost * (Gramm / materials.Length);
                full += Cost;
                return full;
            }
        }

        public Izdeliya()
        {
            Name = "";
            Type = "";
            Gramm = 0;
            Cost = 0;
        }
        public static Izdeliya[] Init(string inputFile, string inputMat)
        {
            Material[] arr = Material.InitArr(inputMat);
            Izdeliya[] izdeliyas = new Izdeliya[Program.Count(inputFile)];//количество изделий
            StreamReader streamReader = new StreamReader(inputFile);
            int izd = 0; // счетчик изделий;
            while (!streamReader.EndOfStream)
            {
                string[] str = streamReader.ReadLine().Replace('\t', '-').Split('-');

                izdeliyas[izd] = new Izdeliya
                {
                    Name = str[0],
                    Type = str[1]
                }; // иницализация
                int t = str[2].Split(';').Length;// получаем число материалов
                var coll = str[2].Split(';');
                izdeliyas[izd].materials = new Material[t];
                for (int i = 0; i < coll.Length; i++)
                {
                    izdeliyas[izd].materials[i] = new Material(); // инициализируем
                    for (int j = 0; j < arr.Length; j++)
                    {
                        if (coll[i].ToLower() == arr[j].Name.ToLower())
                        {
                            izdeliyas[izd].materials[i].Name = arr[j].Name;
                            izdeliyas[izd].materials[i].Cost = arr[j].Cost;
                        }
                    }
                }
                izdeliyas[izd].Gramm = Convert.ToDouble(str[3]);
                izdeliyas[izd].Cost = Convert.ToDouble(str[4]);

                izd++; // добавляем новое изделие
            }
            streamReader.Close();
            return izdeliyas;
        }
        public void GetInfo()
        {
            int j = materials.Length;
            string str = "";
            for (int i = 0; i < j; i++)
            {
                str += materials[i].Name;
                str += ", ";
            }
            str = str.TrimEnd(',', ' ');
            Console.Write($"\nНазвание: {Name}\n" +
                $"Тип: {Type}\n" +
                $"Материал: {str}\n" +
                $"Вес: {Gramm}\n" +
                $"Цена: {FullCost:#,#.000 Р}\n");
        }

        public void Start(Prodaji ot, Izdeliya[] izdeliya)
        {
            Check pod = new Check();

                try
                {
                    Console.Write("Введите id изделия которое хотите приобрести: ");
                    int id_iz = Convert.ToInt32(Console.ReadLine());
                    Console.Write("\n");
                    pod.ByIzdel(izdeliya[id_iz],ot);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
        }

        public void Print()
        {
            int j = materials.Length;
            string str = "";
            for (int i = 0; i < j; i++)
            {
                str += materials[i].Name;
                str += ", ";
            }
            str = str.TrimEnd(',', ' ');
            Console.Write($" {Name,-16}\t{Type,-12}\t{str,-24}\t{Gramm,-12}\t{FullCost:#,#.000 Р}\n");
        }
    }
}