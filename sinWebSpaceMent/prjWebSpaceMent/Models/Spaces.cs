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
    
        public int sNumber { get; set; }
        public string sName { get; set; }
        public string sType { get; set; }
        public string sAddr { get; set; }
        public string sPhone { get; set; }
        public string sFloor { get; set; }
        public string sHeight { get; set; }
        public string sArea { get; set; }
        public string sCapacity { get; set; }
        public decimal sRent { get; set; }
        public decimal sRate { get; set; }
        public string sIntro { get; set; }
        public string sOpeningTime { get; set; }
        public string sSecurity { get; set; }
        public string sTraffic { get; set; }
        public System.DateTime sCreated_at { get; set; }
        public System.DateTime sUpdated_at { get; set; }
        public Nullable<int> FK_Space_to_Owner { get; set; }
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
