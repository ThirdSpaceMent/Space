using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjWebSpaceMent.ViewModels
{
    public class MyOrderViewModel
    {
        public int oNumber { get; set; }
        public string oStatus { get; set; }
        public string oScheduledTime { get; set; }
        public Nullable<decimal> oPayment { get; set; }
        public string oCreated_at { get; set; }
        public Nullable<int> FK_Order_to_Member_User { get; set; }
        public string oTimeRange { get; set; }
        public string mName { get; set; }
    }
}