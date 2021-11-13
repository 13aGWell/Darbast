using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace Hesabdari_Darbast
{
  public  class DataBase
    {
        private SqlCommand cmd;
        private SqlConnection con;
        private SqlDataAdapter da;
        private DataTable dt;

        public void DoCommand(string sql)
        {
            con = new SqlConnection();

            con.ConnectionString = "Data source=EN2\\SQL2019;initial catalog=Hesabdaridb;integrated security=true";

            cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable MySelect(string sql)
        {
            con = new SqlConnection();
            con.ConnectionString = "Data source=EN2\\SQL2019;initial catalog=Hesabdaridb;integrated security=true";
            cmd = new SqlCommand();
            cmd.Connection = con;
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            con.Open();
            cmd.CommandText = sql;
            da.Fill(dt);
            con.Close();
            return dt;
        }
    }
}
