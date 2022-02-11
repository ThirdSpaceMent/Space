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

        public void create(CSpaces p)
        {
            // 新增功能insert

            string SQL = "INSERT INTO Spaces(";
            SQL += "sName,";
            SQL += "sType,";
            SQL += "sAddr,";
            SQL += "sPhone,";
            SQL += "sFloor,";
            SQL += "sHeight,";
            SQL += "sArea,";
            SQL += "sCapacity,";
            SQL += "sRent,";
            SQL += "sRate,";
            SQL += "sIntro,";
            SQL += "sOpeningTime,";
            SQL += "sSecurity,";
            SQL += "sTraffic";

            SQL += ")VALUES(";

            SQL += "'" + p.sName + "',";
            SQL += "'" + p.sType + "',";
            SQL += "'" + p.sAddr + "',";
            SQL += "'" + p.sPhone + "',";
            SQL += "'" + p.sFloor + "',";
            SQL += "'" + p.sHeight + "',";
            SQL += "'" + p.sArea + "',";
            SQL += "'" + p.sCapacity + "',";
            SQL += "'" + p.sRent + "',";
            SQL += "'" + p.sRate + "',";
            SQL += "'" + p.sIntro + "',";
            SQL += "'" + p.sOpeningTime + "',";
            SQL += "'" + p.sSecurity + "',";
            SQL += "'" + p.sTraffic + "')";

            executedSQL(SQL);
        }
    }
}