using Npgsql;
using System;
using System.Collections;
using System.Data.Common;

public class DataBase
{
    private NpgsqlConnection conn;
    private NpgsqlCommand sqlcmd;
    public DataBase()
    {

        String connectionString = "Server=localhost;Port=5432;User ID=postgres;Password=123;Database=gostinicha;";
        conn = new NpgsqlConnection(connectionString);
        conn.Open();
        sqlcmd = new NpgsqlCommand(" ", conn);
        conn.Close();
    }
    public ArrayList Select(string sql)
    {
        conn.Open();
        sqlcmd = new NpgsqlCommand(sql, conn);
        NpgsqlDataReader dataReader = sqlcmd.ExecuteReader();
        ArrayList list = new ArrayList();

        foreach (DbDataRecord item in dataReader)
        {
            list.Add(item);
        }
        conn.Close();
        return list;

    }

    public void Update(string sql)
    {
        conn.Open();
        sqlcmd = new NpgsqlCommand(sql, conn);
        int res = sqlcmd.ExecuteNonQuery();
        conn.Close();
    }

    public ArrayList GetHouseManager()
    {
        conn.Open();
        string sql = "SELECT * FROM public.house_maneger ORDER BY id ASC";
        sqlcmd = new NpgsqlCommand(sql, conn);
        NpgsqlDataReader dataReader = sqlcmd.ExecuteReader();
        ArrayList list = new ArrayList();
        foreach (DbDataRecord item in dataReader)
        {
            list.Add(item);
        }

        conn.Close();
        return list;
    }
    public ArrayList GetRoomType()
    {
        conn.Open();
        string sql = $"SELECT * FROM public.room_type ORDER BY id ASC; ";
        sqlcmd = new NpgsqlCommand(sql, conn);
        NpgsqlDataReader dataReader = sqlcmd.ExecuteReader();
        ArrayList list = new ArrayList();
        foreach (DbDataRecord item in dataReader)
        {
            list.Add(item);
        }

        conn.Close();
        return list;
    }
}
