using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
             int number = 0;
             DateTime date = new DateTime(2023, 1, 1);
             
             int idFilial = 0;
             int idType = 0;
            
             int idClient = 0;
              string surName = "";
             string name = "";
             string patron = "";
             string adress = "";
             string phone = "";
             string inn = "";
             double sum = 0;
             double rate = 0;
             int idAgent = 0;
            Agent agent = new Agent(number, surName, name, patron, adress, phone, idFilial);
            Filial filial = new Filial(idFilial, name, adress, phone);
            Type type = new Type(idType, name, number);
            Client client = new Client(idClient, surName, name, patron, adress, phone, inn);
            Contract contract = new Contract(number, date, sum, rate, idFilial, idType, idAgent, idClient);
            Users users = new Users(number, name, patron);
            agent.StrR();
            filial.StrR();
            type.StrR();
            client.StrR();
            contract.StrR();
            users.StrR();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormAvtorizatsiya());
        }
    }
}
