using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows;
using System.Windows.Controls;

namespace Kursach
{
    public partial class MainWindow : Window
    {
        // поля
        public double cost_of_day = 0;
        private static readonly SQLRequest request = new SQLRequest();
        private int IDperson;
        private PersonModel person = new PersonModel();
        private WorkViewModel workView = new WorkViewModel();
        private PersonViewModel PersonV = new PersonViewModel();
        public List<PersonModel> People { get; set; }
        public List<UchetModel> Works { get; set; }
        // Методы
        public MainWindow()
        {
            InitializeComponent();
            dataUpdate();
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            request.Close();
            Close();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.Show();
            Close();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dataUpdate();
        }
      
        /// Вспомогательные Методы
        public void dataUpdate()
        {

            Works = new List<UchetModel>(workView.GetAllWork());

            ComDiscr.ItemsSource = Works;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            dataUpdate();
        }

        private void Backe_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string i = numberP.Text;
            string qwery = $"SELECT Uchet.id, Nomenklatura.Name_Nom, Person.FIO, Uchet.Kol_vo " +
                $"FROM Person INNER JOIN(Nomenklatura INNER JOIN Uchet ON Nomenklatura.id_izdel = Uchet.Name_Nom) ON Person.p_id = Uchet.Otvetst " +
                $"WHERE(((Uchet.id_partii) = {i}))";
            SQLRequest request = new SQLRequest();
            OleDbDataReader reader = request.Select(qwery);
            List<UchetModel> output = new List<UchetModel>();
            while (reader.Read())
            {
                UchetModel work = new UchetModel();
                work.Id_work = Convert.ToInt32(reader.GetValue(0));
                work.Name = Convert.ToString(reader.GetValue(1));
                work.Otvetst = Convert.ToString(reader.GetValue(2));
                work.Kol_vo = Convert.ToInt32(reader.GetValue(3));
                output.Add(work);
            }
            reader.Close();
            request.Close();
            TableGrid.ItemsSource = output;

        }
    }
}
