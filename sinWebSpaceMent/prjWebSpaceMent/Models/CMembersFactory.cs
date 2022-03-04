using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
        public string check_code(string mAccount, string email)
        {
            string s = "";
            int tc = 0;
            string sql = "select count(*) as tc from Members where mAccount='" + mAccount + "' and mEmail='" + email + "' ";
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SPACEMENTEntities01"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataReader reader = cmd.ExecuteReader();

            List<ClassMembers> list = new List<ClassMembers>();

            while (reader.Read())
            {
                tc = Convert.ToInt32(reader["tc"]);//sql查詢的筆數結果
            }

            if (tc == 0)//若找無比對資料，代表在Members資料庫中沒有該"帳號+信箱"的資料
            {
                s = "帳號或電子郵件錯誤";
                return s;
            }
            else
            {
                //若有則發送郵件
                //掛上雲端後localhost:44386改成SPACES網址
                string title = "Spaces們 驗證通知";
                string body = @" 此為系統發出的驗證通知信件，請點擊以下連結進行重設密碼<br/>
                                 <a href='https://www.spacesment.com/Home/ResetPwd?mAccount=" + mAccount + @"'>按此前往重設密碼</a>
                                 <br/><br/>";
                send_mail(email, "", title, body, "", "", "", "");
                //s = "已將驗證網址傳送至信箱: " + email;
            }
            return s;
        }

        public string Set_Code(string mAccount, string mPassword1, string mPassword2)
        {
            string s = "";
            // 更新密碼
            string sql = "update Members set mPassword='" + mPassword1 + "' where mAccount='" + mAccount + "' ";
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SPACEMENTEntities01"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();

            return s;
        }

        public static string send_mail(string mailto, string mailcc, string subject, string body, string att_file1, string att_file2, string att_file3, string att_file4)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 25);//google的smtp(通常port是25；這個可以google)
                NetworkCredential basicCredential = new NetworkCredential("spacesmentno.3@gmail.com", "P@ssw0rd-iii"); //發Mail的帳號及密碼
                MailMessage message = new MailMessage();
                MailAddress fromAddress = new MailAddress("spacesmentno.3@gmail.com");//發Mail的帳號
                smtpClient.EnableSsl = true;
                if (mailto == "")
                {
                    //throw new Exception("EMAIL不得為空白!");
                    return "";
                }
                if (mailto.IndexOf("@") == -1)
                {
                    //throw new Exception("EMAIL不正確!;" + mailto);
                    return "";
                }

                smtpClient.EnableSsl = true;
                smtpClient.Credentials = basicCredential;

                message.From = fromAddress;
                message.Subject = subject;
                //Set IsBodyHtml to true means you can send HTML email.
                message.IsBodyHtml = true;
                message.Body = body;
                message.To.Add(mailto);

                if (mailcc != "")
                {
                    message.CC.Add(mailcc);
                }

                if (att_file1 != "")
                {
                    message.Attachments.Add(new System.Net.Mail.Attachment(att_file1));
                }
                if (att_file2 != "")
                {
                    message.Attachments.Add(new System.Net.Mail.Attachment(att_file2));
                }
                if (att_file3 != "")
                {
                    message.Attachments.Add(new System.Net.Mail.Attachment(att_file3));
                }
                if (att_file4 != "")
                {
                    message.Attachments.Add(new System.Net.Mail.Attachment(att_file4));
                }
                smtpClient.Send(message);
                message.Dispose();
                smtpClient.Dispose();
                return "";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}