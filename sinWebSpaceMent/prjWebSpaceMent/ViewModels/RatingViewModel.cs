using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace prjWebSpaceMent.ViewModels
{
    public class RatingViewModel
    {
        public int sNumber { get; set; }
        [DisplayName("場地名稱")]
        public string sName { get; set; }
        public int rNumber { get; set; }
        [DisplayName("評分")]
        public decimal rRate { get; set; }
        [DisplayName("評論")]
        public string rComment { get; set; }
        public Nullable<DateTime> rCreatedat { get; set; }
        public DateTime rUpdated_at { get; set; }
        public int rFKtoSpace { get; set; }
        public Nullable<int> rFKtoOrder { get; set; }
        public int rFKtoMember { get; set; }
    }
}