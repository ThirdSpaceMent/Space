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
    
    public partial class Activities
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Activities()
        {
            this.Orders = new HashSet<Orders>();
        }
    
        public int aNumber { get; set; }
        public string aName { get; set; }
        public string aHeadCount { get; set; }
        public string aType { get; set; }
        public System.DateTime aSignUpTime { get; set; }
        public System.DateTime aHoldTime { get; set; }
        public decimal aFee { get; set; }
        public System.DateTime aCreated_at { get; set; }
        public System.DateTime aUpdated_at { get; set; }
        public Nullable<int> FK_Activity_to_Member { get; set; }
        public Nullable<int> FK_Activity_to_Space { get; set; }
    
        public virtual Members Members { get; set; }
        public virtual Spaces Spaces { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders> Orders { get; set; }
    }
}