using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace mytask.Models
{
    public class callcenter
    {
        
        public static DataTable sp_get_calllogsbyuserid(string user)
        {


            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString))
            using (var cmd = new SqlCommand("sp_get_calllogsbyuserid", con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@userid", SqlDbType.VarChar).Value = user;
                da.Fill(table);
            }



           

            return table;
        }
        public static DataTable sp_get_calllogsbyadmin()
        {


            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString))
            using (var cmd = new SqlCommand("sp_get_calllogsbyadmin", con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
               
                da.Fill(table);
            }





            return table;
        }
    }
}