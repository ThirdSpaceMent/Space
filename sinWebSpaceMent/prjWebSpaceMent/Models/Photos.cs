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
    
    public partial class Photos
    {
        public int pNumber { get; set; }
        public string pUrl { get; set; }
        public System.DateTime pCreated_at { get; set; }
        public System.DateTime pUpdated_at { get; set; }
        public Nullable<int> FK_Photo_to_Member { get; set; }
        public Nullable<int> FK_Photo_to_Space { get; set; }
    
        public virtual Members Members { get; set; }
        public virtual Spaces Spaces { get; set; }
    }
}
