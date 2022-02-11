using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace prjWebSpaceMent.Models
{
    public class CSpacesFactory
    {
        private static void executedSQL(string SQL)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SPACEMENTEntities01"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(SQL, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        internal void delete(int sNumber)
        {
            // 刪除功能
            string SQL = "DELETE FROM Spaces WHERE sNumber=" + sNumber.ToString();
            executedSQL(SQL);
        }
    }
}