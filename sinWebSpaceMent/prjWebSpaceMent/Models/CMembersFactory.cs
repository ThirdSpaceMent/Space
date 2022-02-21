using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace prjWebSpaceMent.Models
{
    public class CMembersFactory
    {
        private List<ClassMembers> QueryBySQL(string SQL)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SPACEMENTEntities01"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(SQL, con);

            SqlDataReader reader = cmd.ExecuteReader();

            List<ClassMembers> list = new List<ClassMembers>();

            while (reader.Read())
            {
                ClassMembers x = new ClassMembers()
                {
                    mNumber = (int)reader["mNumber"],
                    mAccount = reader["mAccount"].ToString(),
                    mPassword = reader["mPassword"].ToString(),
                    mName = reader["mName"].ToString(),
                    mNickName = reader["mNickName"].ToString(),
                    mEmail = reader["mEmail"].ToString(),
                    mPhone = reader["mPhone"].ToString(),
                    mGender = reader["mGender"].ToString(),
                    mTWid = reader["mTWid"].ToString(),
                    mBirthday = Convert.ToDateTime(reader["mBirthday"]),
                    mPoint = Convert.ToInt32(reader["mPoint"]),
                    mCreated_at = Convert.ToDateTime(reader["mBirthday"]),
                    mUpdated_at = Convert.ToDateTime(reader["mBirthday"]),
                };
                list.Add(x);
            }
            reader.Close();
            con.Close();
            return list;
        }
        public ClassMembers QueryByfid(int id)
        {
            //查詢
            List<ClassMembers> list = QueryBySQL("SELECT * FROM Members WHERE mNumber=" + id);

            if (list.Count == 0)
                return null;
            return list[0];
        }
    }
}