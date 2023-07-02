using System;
using System.IO;
using System.Collections.Generic;


namespace Uvelir
{
    class Material
    {
        public string Name { get; set; }
        public double Cost { get; set; }

        private static Material[] jewelry;
        

        public Material()
        {
            Name = "";
            Cost = 0;
        }
        public static Material[] InitArr(string mater)
        {
            int i = 0;
            
            int k = Program.Count(mater);
            jewelry = new Material[k];
              Material[] temp = new Material[k];
            for (int j = 0; j < k; ++j)
            {
                temp[j] = new Material();
                jewelry[j] = new Material();
            }
            StreamReader sr = new StreamReader(mater);
            while (!sr.EndOfStream)
            {
                string[] str = sr.ReadLine().Split('\t');
                temp[i].Name = str[0];
                temp[i].Cost = Convert.ToDouble(str[1]);
                jewelry[i].Name = str[0];
                jewelry[i].Cost = Convert.ToDouble(str[1]);
                i++;
            }

            return temp;
        }

        public void GetInfo()
        {
            Console.Write($"\nНазвание: {Name}\n" +
                $"Цена: {Cost:#,#.000 Р}\n");
        }

        public void Start(Prodaji ot, Material[] material)
        {
            Check pod = new Check();
            int id_mat;

            try
            {
                Console.WriteLine("Введите количество материалов: ");
                int kolmat = Convert.ToInt32(Console.ReadLine());
                for (int i = 1; i <= kolmat; i++)
                {
                    Console.Write("Введите id материала: ");
                    id_mat = Convert.ToInt32(Console.ReadLine());
                    Console.Write("\n");
                    pod.ByMaterial(material[id_mat],ot);
                }               
                }
            catch (Exception ex)
            {
                 Console.WriteLine(ex.Message);
            }

        }
        public void Print()
        {
            Console.Write($" {Name,-26}  {Cost}р \n");
        }
    }
}