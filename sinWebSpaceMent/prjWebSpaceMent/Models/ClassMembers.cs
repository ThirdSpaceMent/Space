using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace prjWebSpaceMent.Models
{
    public class ClassMembers
    {
        [DisplayName("會員編號")]
        public int mNumber { get; set; }
        [Required]
        [DisplayName("帳號")]
        public string mAccount { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "請輸入至少6位數密碼")]
        [DataType(DataType.Password)]
        [DisplayName("密碼")]
        public string mPassword { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "請輸入完整姓名")]
        [DisplayName("姓名")]
        public string mName { get; set; }
        [DisplayName("暱稱")]
        public string mNickName { get; set; }
        [Required]
        [EmailAddress]
        [DisplayName("電子信箱")]
        public string mEmail { get; set; }
        [Phone]
        [DisplayName("聯絡電話")]
        public string mPhone { get; set; }
        [DisplayName("性別")]
        public string mGender { get; set; }
        [DisplayName("身分證字號")]
        public string mTWid { get; set; }
        [Required]
        [DisplayName("出生年月日")]
        public System.DateTime mBirthday { get; set; }
        [DisplayName("點數")]
        public int mPoint { get; set; }
        [DisplayName("建立時間")]
        public System.DateTime mCreated_at { get; set; }
        [DisplayName("更新時間")]
        public System.DateTime mUpdated_at { get; set; }
    }
}