//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace prjWebSpaceMent.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Configuration;
    using System.Data.SqlClient;

    public partial class Spaces
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Spaces()
        {
            this.Activities = new HashSet<Activities>();
            this.Favorites = new HashSet<Favorites>();
            this.Orders = new HashSet<Orders>();
            this.Photos = new HashSet<Photos>();
            this.Rates = new HashSet<Rates>();
            this.SubSpaces = new HashSet<SubSpaces>();
        }
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
            SQL += "sRate='" + p.sRate + "',";
            SQL += "sIntro='" + p.sIntro + "',";
            SQL += "sOpeningTime='" + p.sOpeningTime + "',";
            SQL += "sSecurity='" + p.sSecurity + "',";
            SQL += "sTraffic='" + p.sTraffic + "',";
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
        public void create(Spaces p)
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
                    sRate = Convert.ToDecimal(reader["sRate"]),
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

        internal List<ClassSpaces> QueryAll(string city, string type)
        {
            // 查詢 列出所有

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

            return QueryBySQL(SQL);
        }

        internal List<ClassSpaces> QueryByKeyword(string keyword, string city, string type)
        {
            //關鍵字查詢

            string SQL = "SELECT * FROM Spaces WHERE sName LIKE '%" + keyword + "%'";
            SQL += "OR sType LIKE '%" + keyword + "%'";
            SQL += "OR sAddr LIKE '%" + keyword + "%'";
            SQL += "OR sPhone LIKE '%" + keyword + "%'";
            SQL += "OR sFloor LIKE '%" + keyword + "%'";
            SQL += "OR sHeight LIKE '%" + keyword + "%'";
            SQL += "OR sArea LIKE '%" + keyword + "%'";
            SQL += "OR sCapacity LIKE '%" + keyword + "%'";
            SQL += "OR sRent LIKE '%" + keyword + "%'";
            SQL += "OR sRate LIKE '%" + keyword + "%'";
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

            return QueryBySQL(SQL);
        }

        public int sNumber { get; set; }

        [DisplayName("場地名稱")]
        public string sName { get; set; }

        [DisplayName("活動類型")]
        public string sType { get; set; }

        [DisplayName("地址")]
        public string sAddr { get; set; }

        [DisplayName("連絡電話")]
        public string sPhone { get; set; }

        [DisplayName("樓層")]
        public string sFloor { get; set; }

        [DisplayName("場地高度")]
        public string sHeight { get; set; }

        [DisplayName("場地面積")]
        public string sArea { get; set; }

        [DisplayName("可容納人數")]
        public string sCapacity { get; set; }

        [DisplayName("費用")]
        public decimal sRent { get; set; }

        [DisplayName("費率")]
        public decimal sRate { get; set; }

        [DisplayName("場地簡介")]
        public string sIntro { get; set; }

        [DisplayName("營業時間")]
        public string sOpeningTime { get; set; }

        [DisplayName("場地安全")]
        public string sSecurity { get; set; }

        [DisplayName("交通特色")]
        public string sTraffic { get; set; }

        [DisplayName("建立時間")]
        public System.DateTime sCreated_at { get; set; }

        [DisplayName("更新時間")]
        public System.DateTime sUpdated_at { get; set; }
        public Nullable<int> FK_Space_to_Owner { get; set; }
        public string oAccount { get; set; }
        public Nullable<int> oPrice { get; set; }
        public string sTimeRange { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activities> Activities { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Favorites> Favorites { get; set; }
        public virtual Members Members { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders> Orders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Photos> Photos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rates> Rates { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SubSpaces> SubSpaces { get; set; }
    }
}
