using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DoAn3_Vietravel.Models
{
    public class DataConnection
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        string strconn = ConfigurationManager.ConnectionStrings["str_DoAn3_connect"].ConnectionString;

        public DataConnection()
        {
            cn = new SqlConnection(strconn);
        }

        public DataTable LayDuLieu(string query)
        {
            da = new SqlDataAdapter(query, cn);
            dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void GhiDuLieu(string query)
        {
            cn.Open();
            cmd = new SqlCommand(query, cn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cn.Close();
        }
    }
}
