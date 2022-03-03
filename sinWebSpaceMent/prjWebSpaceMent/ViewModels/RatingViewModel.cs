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
        public DateTime rCreated_at { get; set; }
        public DateTime rUpdated_at { get; set; }
        public int FK_Rate_to_Space { get; set; }
        public Nullable<int> FK_Rate_to_Order { get; set; }
        public int FK_Rate_to_Member { get; set; }
    }
}