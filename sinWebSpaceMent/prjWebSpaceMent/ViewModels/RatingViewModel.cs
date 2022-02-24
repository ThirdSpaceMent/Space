using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjWebSpaceMent.ViewModels
{
    public class RatingViewModel
    {
        public int rNumber { get; set; }
        public decimal rRate { get; set; }
        public string rComment { get; set; }
        public DateTime rCreated_at { get; set; }
        public int FK_Rate_to_Space { get; set; }
        public Nullable<int> FK_Rate_to_Order { get; set; }
        public int FK_Rate_to_Member { get; set; }
    }
}