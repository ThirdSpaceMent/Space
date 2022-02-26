using prjWebSpaceMent.ViewModels;
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

        public void update(ClassSpaces p)
        {
            // 修改場地的存檔
            string SQL = "UPDATE Spaces SET ";

            SQL += "sName='" + p.sName + "',";
            SQL += "sType='" + p.sType + "',";
            SQL += "sAddr='" + p.sAddr + "',";
            SQL += "sPhone='" + p.sPhone + "',";
            SQL += "sFloor='" + p.sFloor + "',";
            SQL += "sHeight='" + p.sHeight + "',";
            SQL += "sArea='" + p.sArea + "',";
            SQL += "sCapacity='" + p.sCapacity + "',";
            SQL += "sRent='" + p.sRent + "',";
            //SQL += "sRate='" + p.sRate + "',";
            SQL += "sIntro='" + p.sIntro + "',";
            SQL += "sOpeningTime='" + p.sOpeningTime + "',";
            SQL += "sSecurity='" + p.sSecurity + "',";
            SQL += "sTraffic='" + p.sTraffic + "',";
            SQL += "sPhoto='" + p.sPhoto + "',";
            SQL += "sUpdated_at=getDate() ";
            SQL += "WHERE sNumber=" + p.sNumber;

            executedSQL(SQL);
        }

        internal void delete(int sNumber)
        {
            // 刪除功能DELETE
            string SQL = "DELETE FROM Spaces WHERE sNumber=" + sNumber.ToString();
            executedSQL(SQL);
        }
        public void create(ClassSpaces p)
        {
            // 新增功能INSERT

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
            //SQL += "sRate,";
            SQL += "sIntro,";
            SQL += "sOpeningTime,";
            SQL += "sSecurity,";
            SQL += "sTraffic,";
            SQL += "sPhoto,";
            //SQL += "FK_Space_to_Owner,";
            SQL += "FK_Space_to_Owner ";
            //SQL += "oAccount ";

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
            //SQL += "'" + p.sRate + "',";
            SQL += "'" + p.sIntro + "',";
            SQL += "'" + p.sOpeningTime + "',";
            SQL += "'" + p.sSecurity + "',";
            SQL += "'" + p.sTraffic + "',";
            SQL += "'" + p.sPhoto + "',";
            //SQL += "'" + p.FK_Space_to_Owner + "',";
            SQL += "'" + p.FK_Space_to_Owner + "')";
            //SQL += "'" + p.oAccount + "')";
            executedSQL(SQL);

            //將oAccount更新為跟sNumber同步
            //string SQL2 = "UPDATE Spaces SET oAccount= sNumber;";
            //executedSQL(SQL2);
        }
        public void edit(int? id)
        {
            string SQL = "SELECT * FROM Spaces WHERE sNumber=" + id;

            executedSQL(SQL);
        }

        private List<ClassSpaces> QueryBySQL(string SQL)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SPACEMENTEntities01"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(SQL, con);

            SqlDataReader reader = cmd.ExecuteReader();

            List<ClassSpaces> list = new List<ClassSpaces>();

            while (reader.Read())
            {
                ClassSpaces x = new ClassSpaces()
                {
                    sNumber = (int)reader["sNumber"],
                    sName = reader["sName"].ToString(),
                    sType = reader["sType"].ToString(),
                    sAddr = reader["sAddr"].ToString(),
                    sPhone = reader["sPhone"].ToString(),
                    sFloor = reader["sFloor"].ToString(),
                    sHeight = reader["sHeight"].ToString(),
                    sArea = reader["sArea"].ToString(),
                    sCapacity = reader["sCapacity"].ToString(),
                    sRent = Convert.ToDecimal(reader["sRent"]),
                    //sRate = Convert.ToDecimal(reader["sRate"]),
                    sIntro = reader["sIntro"].ToString(),
                    sOpeningTime = reader["sOpeningTime"].ToString(),
                    sSecurity = reader["sSecurity"].ToString(),
                    sTraffic = reader["sTraffic"].ToString(),
                };
                list.Add(x);
            }
            reader.Close();
            con.Close();
            return list;
        }
        public ClassSpaces QueryByfid(int id)
        {
            //查詢
            List<ClassSpaces> list = QueryBySQL("SELECT * FROM Spaces WHERE sNumber=" + id);

            if (list.Count == 0)
                return null;
            return list[0];
        }
        
        // 查詢 列出所有
        internal List<ClassSpaces> QueryAll(string city, string type, int number)
        {       
            string SQL = "SELECT * FROM Spaces WHERE 1=1 ";

            // 如果city有值,加上此判斷
            if (city != null && city != "")
            {
                SQL += " AND sAddr LIKE '%" + city + "%'";
            }

            // 如果type有值,加上此判斷
            if (type != null && type != "")
            {
                SQL += " AND sType LIKE '%" + type + "%'";
            }

            // 如果登入者有值,過濾掉自己的場地
            if (number != 0)
            {
                SQL += " AND FK_Space_to_Owner<>'" + number + "' ";
            }

            return QueryBySQL(SQL);
        }
        
        //關鍵字查詢
        internal List<ClassSpaces> QueryByKeyword(string keyword, string city, string type, int number)
        {           
            string SQL = "SELECT * FROM Spaces WHERE sName LIKE '%" + keyword + "%'";
            SQL += "OR sType LIKE '%" + keyword + "%'";
            SQL += "OR sAddr LIKE '%" + keyword + "%'";
            SQL += "OR sPhone LIKE '%" + keyword + "%'";
            SQL += "OR sFloor LIKE '%" + keyword + "%'";
            SQL += "OR sHeight LIKE '%" + keyword + "%'";
            SQL += "OR sArea LIKE '%" + keyword + "%'";
            SQL += "OR sCapacity LIKE '%" + keyword + "%'";
            SQL += "OR sRent LIKE '%" + keyword + "%'";
            //SQL += "OR sRate LIKE '%" + keyword + "%'";
            SQL += "OR sIntro LIKE '%" + keyword + "%'";
            SQL += "OR sOpeningTime LIKE '%" + keyword + "%'";
            SQL += "OR sSecurity LIKE '%" + keyword + "%'";
            SQL += "OR sTraffic LIKE '%" + keyword + "%'";

            // 如果有選城市下拉選單的值,一起呈現
            if (city != null && city != "")
            {
                SQL += " OR sAddr LIKE '%" + city + "%'";
            }

            // 如果有選活動類型下拉選單的值,一起呈現
            if (type != null && type != "")
            {
                SQL += " OR sType LIKE '%" + type + "%'";
            }

            // 如果登入者有值,過濾掉自己的場地
            if (number != 0)
            {
                SQL += " AND FK_Space_to_Owner<>'" + number + "' ";
            }

            return QueryBySQL(SQL);
        }
        
        // 篩選出目前登入者的所有場地
        internal object search_myorder(int mNumber)
        {
            
            // 訂單的FK_Order_to_Member_User需對應會員的mNumber > 找出會員中文名字

            string SQL = "SELECT oNumber,oStatus,convert(nvarchar,oScheduledTime,111) as oScheduledTime,oTimeRange,oPayment,oCreated_at,FK_Order_to_Member_User,mName FROM Orders JOIN Members ON Members.mNumber = Orders.FK_Order_to_Member_User WHERE Orders.FK_Order_to_Member_Owner =" + mNumber;
            SQL += " ORDER BY oScheduledTime";

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SPACEMENTEntities01"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(SQL, con);

            SqlDataReader reader = cmd.ExecuteReader();

            List<MyOrderViewModel> list = new List<MyOrderViewModel>();

            while (reader.Read())
            {
                MyOrderViewModel MyOrder = new MyOrderViewModel()
                {
                    oNumber = (int)reader["oNumber"],
                    oStatus = reader["oStatus"].ToString(),
                    oScheduledTime = reader["oScheduledTime"].ToString(),
                    oPayment = Convert.ToDecimal(reader["oPayment"]),
                    oCreated_at = reader["oCreated_at"].ToString(),
                    FK_Order_to_Member_User = (int)reader["FK_Order_to_Member_User"],
                    oTimeRange = reader["oTimeRange"].ToString(),
                    mName = reader["mName"].ToString(),
                };
                list.Add(MyOrder);
            }
            reader.Close();
            con.Close();
            return list;
        }
    }
}