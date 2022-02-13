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
    using System.ComponentModel.DataAnnotations;

    public partial class Members
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Members()
        {
            this.Activities = new HashSet<Activities>();
            this.Comments = new HashSet<Comments>();
            this.Favorites = new HashSet<Favorites>();
            this.Orders = new HashSet<Orders>();
            this.Orders1 = new HashSet<Orders>();
            this.Photos = new HashSet<Photos>();
            this.Rates = new HashSet<Rates>();
            this.Spaces = new HashSet<Spaces>();
        }

        [DisplayName("會員編號")]
        public int mNumber { get; set; }
        [Required]
        [DisplayName("帳號")]
        public string mAccount { get; set; }
        [Required]
        [MinLength(6,ErrorMessage ="請輸入至少6位數密碼")]
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
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activities> Activities { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comments> Comments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Favorites> Favorites { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders> Orders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders> Orders1 { get; set; }
        public virtual Owners Owners { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Photos> Photos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rates> Rates { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Spaces> Spaces { get; set; }
    }
}
