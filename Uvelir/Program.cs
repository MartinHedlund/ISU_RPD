using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uvelir
{
    class Program
    {
        public static int Count(string mater)
        {
            int i = 0;
            StreamReader streamReader = new StreamReader(mater);
            while (!streamReader.EndOfStream)
            {
                streamReader.ReadLine();
                i++;
            }
            streamReader.Close();
            return i;
        }
        static void Main()
        {
            string fileIZ = "inputIzdeliya.txt";
            string fileMA = "Materials.txt";
            string Db = "DbClient.txt";

            Izdeliya[] izdeliya = Izdeliya.Init(fileIZ, fileMA); //массив изделий
            Material[] materials = Material.InitArr(fileMA); //массив материалов
            Izdeliya izd = new Izdeliya();
            Material matT = new Material();
            Prodaji pod = new Prodaji();
            Check ch = new Check();
            //приветствие 
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("{0,70}","Добро пожаловать в Ювелирную мастерскую!");
            // введите ваш id постоянного клиента или зарегистрируйтесь
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nВведите ваше id из клиентской базы или же зарегистрируйтесь (для добавления введите: '-1') : ");
            string ot = Console.ReadLine();
           
            int id = Convert.ToInt32(ot);
            if (id == -1) pod.NewClient(Db); //если ввел "-1", то регистрация
            else pod.InitClient(Db, id);  //если ввел id, то находим клиента по id

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Выберите действие, нажав на 1, 2 или 3:" +
                "\n 1 - Купить готовое украшение из наличия" +
                "\n 2 - Купить материалы" +
                "\n 3 - Ремонт украшения");
            int x;
            string a = Console.ReadLine();
            if (!Int32.TryParse(a, out x))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Некорректный ввод! Попробуйте заново!");
            }
            else
            {
                switch (x)
                {
                    case 1:
                        Console.WriteLine("{0,70}","НАЛИЧИЕ");
                        Console.WriteLine(new string('-', 100));
                        Console.WriteLine("   Название изделия\tТип\t\t\tМатериал\t\tВес,гр.\t\tЦена");
                        Console.WriteLine(new string('-', 100));

                        int ind = 0;
                        foreach (var it in izdeliya) //вывод готовых изделий
                        {
                            Console.Write(ind++);
                            it.Print();
                        }
                        Console.WriteLine(new string('-', 100));
                        if (ot != "y")
                            izd.Start(pod, izdeliya); //выбор готового изделия, которое хотим приобрести
                        break; 
                    case 2: //создаем новое украшение
                        Console.WriteLine("{0,70}", "СОЗДАНИЕ НОВОГО УКРАШЕНИЯ");
                        Console.WriteLine("Материалы: ");
                        Console.WriteLine(new string('-', 100));
                        Console.WriteLine("   Название материала\t\tЦена");
                        Console.WriteLine(new string('-', 100));
                        int mat1 = 0;
                        foreach (var it in materials)
                        {
                            Console.Write(mat1++);
                            it.Print();
                        }
                        Console.WriteLine(new string('-', 100));
                        //вывод всех материалов
                        matT.Start(pod, materials);
                        break;
                    case 3: 
                        Console.WriteLine("{0,70}", "РЕМОНТ ИЗДЕЛИЯ");
                        Console.WriteLine("Украшение из нашей мастерской? " +
                            "\n Введите 1, если ДА " +
                            "\n Введите 0, если НЕТ");
                        string  b = Console.ReadLine();
                        if (b == "1")
                        {
                            Console.WriteLine("Ремонт нашего изделия равен 1000р без скидки");
                            int rem1 = 1000;
                            ch.ByRemont(rem1, pod);

                        }
                        else
                        {
                            Console.WriteLine("Ремонт чужого изделия равен 1500р без скидки");
                            int rem2 = 1500;
                            ch.ByRemont(rem2, pod);
                        }
                        break;         
                }
            }  

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("{0,70}", "До новых встреч!");
            Console.ForegroundColor = ConsoleColor.White;

            Console.ReadKey();
        }    
    }
}
