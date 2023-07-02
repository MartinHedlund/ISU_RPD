using System;
using System.Data.OleDb;
using System.Windows;

namespace Kursach
{
    internal class SQLRequest
    {
        public static string connection = @"Provider=Microsoft.Jet.OLEDB.4.0; 
        Data Source=E:\Труды Рабочей Видры\Уник\Второй курс\1 семак\МСППО(ППО)\Курсач\Kursach\Kursach\DateBaseServer.mdb"; // путь к базе данных

        private OleDbConnection connect;
        public SQLRequest()
        {
            connect = new OleDbConnection(connection); // подключаемся к базе данных
        }
        public OleDbDataReader Select(string selectSQL) // функция подключения к базе данных и обработка запросов
        {
            connect.Open(); // открываем базу данных

            OleDbCommand cmd = new OleDbCommand(selectSQL, connect); // создаём запрос
            OleDbDataReader reader = cmd.ExecuteReader(); // получаем данные
            return reader; // возвращаем
        }
        public void Update(string updateSQL)
        {
            connect.Open(); // открываем базу данных
            OleDbCommand cmd = new OleDbCommand(updateSQL, connect);
            cmd.ExecuteNonQuery();
            connect.Close();
        }
        public void Insert(string insertSQL)
        {
            try
            {
                connect.Open(); // открываем базу данных
                OleDbCommand cmd = new OleDbCommand(insertSQL, connect);
                cmd.ExecuteNonQuery();
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Insert");
                connect.Close();
            }
        }
        public void Delete(string deleteSQL)
        {
            try
            {
                connect.Open(); // открываем базу данных
                OleDbCommand cmd = new OleDbCommand(deleteSQL, connect);
                cmd.ExecuteNonQuery();
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Delete");
                connect.Close();
            }
        }

        public void Close()
        {
            connect.Close();
        }

    }
}
