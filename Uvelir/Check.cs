using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uvelir
{
    class Check : Prodaji
    {     
        private static readonly string path = "Otchet.txt";
        public void ByIzdel(Izdeliya by_izdeliya, Prodaji ot)
        {
            Console.WriteLine(new string('-', 100));
            Console.WriteLine("Вы выбрали для покупки: ");
            by_izdeliya.GetInfo();
            if (PostClient)
            {
                string str = $"Покупатель: {ot.FAM}\n" +
                  $"Изделие: {by_izdeliya.Name}\n" +
                  $"Дата: {DateTime.Now}" +
                  $"\nИтог: {by_izdeliya.FullCost * 0.85:#,#.000 Р}\n" +
                  $"Скидка составила: {by_izdeliya.FullCost - by_izdeliya.FullCost * 0.85:#,#.000 Р}";
                Console.WriteLine(new string('-', 100));
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("{0,25}", "Чек вашей покупки: ");

                Console.WriteLine(new string('=', 40));
                Console.WriteLine("Скидка постоянного клиента 15%");
                Console.WriteLine('\n' + str);
                Console.WriteLine(new string('=', 40));
                Otchet(str);
                Console.ForegroundColor = ConsoleColor.White;

            }
            else
            {
                string str = $"Покупатель: {ot.FAM}\n" +
                  $"Дата: {DateTime.Now}\n" +
                  $"Изделие: {by_izdeliya.Name}\n" +
                  $"Итог: {by_izdeliya.FullCost:#,#.000 Р}\n";
                Console.WriteLine(new string('-', 100));
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("{0,25}", "Чек вашей покупки: ");
                Console.WriteLine(new string('=', 40));
                Console.WriteLine('\n' + str);
                Console.WriteLine(new string('=', 40));
                Otchet(str);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void ByMaterial(Material by_material, Prodaji ot)
        {         
            Console.WriteLine(new string('-', 100));
            Console.WriteLine("Вы выбрали для покупки: ");
            by_material.GetInfo();

            if (PostClient)
            {
                string str = $"Покупатель: {ot.FAM}\n" +
                  $"Материалы: {by_material.Name}\n" +
                  $"Дата: {DateTime.Now}" +
                  $"\nИтог: {by_material.Cost * 0.85:#,#.000 Р}\n" +
                  $"Скидка составила: {by_material.Cost - by_material.Cost * 0.85:#,#.000 Р}";
                Console.WriteLine(new string('-', 100));
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("{0,25}", "Чек вашей покупки: ");

                Console.WriteLine(new string('=', 40));
                Console.WriteLine("Скидка постоянного клиента 15%");
                Console.WriteLine('\n' + str);
                Console.WriteLine(new string('=', 40));
                Otchet(str);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else 
            {         
                string str = $"Покупатель: {ot.FAM}\n" +
                  $"Дата: {DateTime.Now}\n" +
                  $"Материалы: {by_material.Name}\n" +
                  $"Итог: {by_material.Cost:#,#.000 Р}\n";
                Console.WriteLine(new string('-', 100));
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("{0,25}", "Чек вашей покупки: ");
                Console.WriteLine(new string('=', 40));
                Console.WriteLine('\n' + str);
                Console.WriteLine(new string('=', 40));
                Otchet(str);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void ByRemont(int rem, Prodaji ot)
        {
            if (PostClient)
            {
                string str = $"Покупатель: {ot.FAM}\n" +
                  $"Дата: {DateTime.Now}" +
                  $"\nИтог: {rem * 0.85:#,#.000 Р}";
                Console.WriteLine(new string('-', 100));
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("{0,25}", "Чек вашей покупки: ");

                Console.WriteLine(new string('=', 40));
                Console.WriteLine("Скидка постоянного клиента 15%");
                Console.WriteLine('\n' + str);
                Console.WriteLine(new string('=', 40));
                Otchet(str);
                Console.ForegroundColor = ConsoleColor.White;

            }
            else
            {
                string str = $"Покупатель: {ot.FAM}\n" +
                  $"Дата: {DateTime.Now}" +
                  $"\nИтог: {rem:#,#.000 Р}";
                Console.WriteLine(new string('-', 100));
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("{0,25}", "Чек вашей покупки: ");
                Console.WriteLine(new string('=', 40));
                Console.WriteLine('\n' + str);
                Console.WriteLine(new string('=', 40));
                Otchet(str);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private void Otchet(string str)
        {
            StreamWriter sw = new StreamWriter(path, true);

            sw.WriteLine(str);
            sw.Close();
        }
    }
}
