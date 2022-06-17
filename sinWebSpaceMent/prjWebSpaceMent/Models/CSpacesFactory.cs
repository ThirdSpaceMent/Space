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
        SPACEMENTDB db = new SPACEMENTDB();
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
            //string SQL = "UPDATE Spaces SET ";

            //SQL += "sName='" + p.sName + "',";
            //SQL += "sType='" + p.sType + "',";
            //SQL += "sAddr='" + p.sAddr + "',";
            //SQL += "sPhone='" + p.sPhone + "',";
            //SQL += "sFloor='" + p.sFloor + "',";
            //SQL += "sHeight='" + p.sHeight + "',";
            //SQL += "sArea='" + p.sArea + "',";
            //SQL += "sCapacity='" + p.sCapacity + "',";
            //SQL += "sRent='" + p.sRent + "',";
            //SQL += "sRate='" + p.sRate + "',";
            //SQL += "sIntro='" + p.sIntro + "',";
            //SQL += "sSecurity='" + p.sSecurity + "',";
            //SQL += "sTraffic='" + p.sTraffic + "',";
            //SQL += "sUpdatedat=getDate() ";
            //SQL += "WHERE sNumber=" + p.sNumber;

            //executedSQL(SQL);
            //----------------以上為ADO.NET---------------

            Spaces saving = db.Spaces.FirstOrDefault(m => m.sNumber == p.sNumber);
                                    
            saving.sName = p.sName;
            saving.sType = p.sType;
            saving.sAddr = p.sAddr;
            saving.sPhone = p.sPhone;
            saving.sFloor = p.sFloor;
            saving.sHeight = p.sHeight;
            saving.sArea = p.sArea;
            saving.sCapacity = p.sCapacity;
            saving.sRent = p.sRent;
            saving.sRate = p.sRate;
            saving.sIntro = p.sIntro;
            saving.sOpeningDays1 = p.sOpeningDays1;
            saving.sOpeningDays2 = p.sOpeningDays2;
            saving.sOpeningDays3 = p.sOpeningDays3;
            saving.sOpeningDays4 = p.sOpeningDays4;
            saving.sOpeningDays5 = p.sOpeningDays5;
            saving.sOpeningDays6 = p.sOpeningDays6;
            saving.sOpeningDays7 = p.sOpeningDays7;
            saving.sOpeningTime1 = p.sOpeningTime1;
            saving.sOpeningTime2 = p.sOpeningTime2;
            saving.sOpeningTime3 = p.sOpeningTime3;
            saving.sClosingTime1 = p.sClosingTime1;
            saving.sClosingTime2 = p.sClosingTime2;
            saving.sClosingTime3 = p.sClosingTime3;
            saving.sSecurity = p.sSecurity;
            saving.sTraffic = p.sTraffic;
            saving.sPhoto1 = p.sPhoto1;
            saving.sPhoto2 = p.sPhoto2;
            saving.sPhoto3 = p.sPhoto3;

            db.SaveChanges();
        }

        //internal void delete(int sNumber)
        //{
        //    // 刪除功能DELETE
        //    string SQL = "DELETE FROM Spaces WHERE sNumber=" + sNumber.ToString();
        //    executedSQL(SQL);
        //}
        internal void delete(int sNumber)
        {
            // 刪除功能DELETE

            // rates
            string SQL03 = "DELETE FROM Rates WHERE rFKtoSpace=" + sNumber.ToString();
            executedSQL(SQL03);

            // 追蹤
            string SQL02 = "DELETE FROM Favorites WHERE fFKtoSpace=" + sNumber.ToString();
            executedSQL(SQL02);

            // 訂單
            string SQL01 = "DELETE FROM Orders WHERE oFKtoSpace=" + sNumber.ToString();
            executedSQL(SQL01);

            // 場地
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
            //SQL += "sOpeningTime1,";
            SQL += "sSecurity,";
            SQL += "sTraffic,";
            SQL += "sPhoto,";
            SQL += "sPhoto_First,";
            SQL += "sPhoto_Second,";
            //SQL += "FK_Space_to_Owner,";
            SQL += "sFKtoMember ";
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
            SQL += "'" + p.sOpeningTime1 + "',";
            SQL += "'" + p.sSecurity + "',";
            SQL += "'" + p.sTraffic + "',";
            SQL += "'" + p.sPhoto1 + "',";
            SQL += "'" + p.sPhoto2 + "',";
            SQL += "'" + p.sPhoto3 + "',";
            //SQL += "'" + p.FK_Space_to_Owner + "',";
            SQL += "'" + p.sFKtoMember + "')";
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
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SPACEMENTLDB"].ConnectionString);
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
                    //sOpeningTime1 = reader["sOpeningTime"].ToString(),
                    sSecurity = reader["sSecurity"].ToString(),
                    sTraffic = reader["sTraffic"].ToString(),
                    sPhoto1 = reader["sPhoto1"].ToString(),
                    sPhoto2 = reader["sPhoto2"].ToString(),
                    sPhoto3 = reader["sPhoto3"].ToString(),
                };
                if (reader["RatingAVG"] != DBNull.Value) 
                {
                    x.RatingAVG = (decimal)reader["RatingAVG"]; 
                }
                else
                {
                    x.RatingAVG = 0;
                }
                list.Add(x);
            }
            reader.Close();
            con.Close();
            return list;
        }
        public ClassSpaces QueryByfid(int id)
        {
            //查詢
            //List<ClassSpaces> list = QueryBySQL("SELECT * FROM Spaces WHERE sNumber=" + id);
            List<ClassSpaces> list = QueryBySQL("SELECT * FROM Spaces FULL JOIN (SELECT rFKtoSpace, AVG(rRate) AS RatingAVG " +
                "FROM Rates GROUP BY rFKtoSpace) AS AVGR ON Spaces.sNumber = AVGR.rFKtoSpace WHERE sNumber=" + id);
            if (list.Count == 0)
                return null;
            return list[0];
        }
        
        // 查詢 列出所有
        internal List<ClassSpaces> QueryAll(string city, string type, int number)
        {       
            string SQL = "SELECT * FROM Spaces FULL JOIN (SELECT rFKtoSpace, AVG(rRate) AS RatingAVG " +
                "FROM Rates GROUP BY rFKtoSpace) AS AVGR ON Spaces.sNumber = AVGR.rFKtoSpace WHERE 1=1";
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
                SQL += " AND sFKtoMember<>'" + number + "' ";
            }

            return QueryBySQL(SQL);
        }

        //關鍵字查詢
        internal List<ClassSpaces> QueryByKeyword(string keyword, string city, string type, int number)
        {
            string SQL = "SELECT * FROM Spaces WHERE 1=1 ";

            //if (number != 0) // 如果登入者有值,過濾掉自己的場地
            //{
            //    SQL += " AND sFKtoMember<>'" + number + "' ";
            //}
            SQL += " AND (";  // 且裡面有關鍵字
            SQL += " sName LIKE '%" + keyword + "%'";
            SQL += "OR sType LIKE '%" + keyword + "%'";
            SQL += "OR sAddr LIKE '%" + keyword + "%'";
            //SQL += "OR sPhone LIKE '%" + keyword + "%'";
            SQL += "OR sFloor LIKE '%" + keyword + "%'";
            SQL += "OR sHeight LIKE '%" + keyword + "%'";
            SQL += "OR sArea LIKE '%" + keyword + "%'";
            SQL += "OR sCapacity LIKE '%" + keyword + "%'";
            SQL += "OR sRent LIKE '%" + keyword + "%'";
            //SQL += "OR sRate LIKE '%" + keyword + "%'";
            SQL += "OR sIntro LIKE '%" + keyword + "%'";
            //SQL += "OR sOpeningTime LIKE '%" + keyword + "%'";
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

            SQL += " ) ";

            return QueryBySQL(SQL);
        }

        // 篩選出目前登入者的所有場地
        internal object search_myorder(int mNumber)
        {

            // 訂單的FK_Order_to_Member_User需對應會員的mNumber > 找出會員中文名字

            string SQL = "SELECT oNumber,oStatus,convert(nvarchar,oScheduledTime,111) as oScheduledTime,oTimeRange,oPayment,oCreated_at,FK_Order_to_Member_User,mName,mPhone FROM Orders JOIN Members ON Members.mNumber = Orders.FK_Order_to_Member_User WHERE Orders.FK_Order_to_Member_Owner =" + mNumber;
            SQL += " ORDER BY oScheduledTime";

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SPACEMENTLDB"].ConnectionString);
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
                    mPhone = reader["mPhone"].ToString()
                };
                list.Add(MyOrder);
            }
            reader.Close();
            con.Close();
            return list;
        }
        public string check_name(string sname)
        {
            string s = "";
            int tc = 0;
            // 新增功能INSERT
            string sql = "select count(*) as tc  FROM Spaces where sName='" + sname + "' ";
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SPACEMENTLDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                tc = Convert.ToInt32(reader["tc"]);
            }
            if (tc > 0)
            {
                s = "已經有相同場所名稱";
                return s;
            }
            return s;
        }
    }
}