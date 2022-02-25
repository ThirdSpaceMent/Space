using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace prjWebSpaceMent.Models
{
    public class ClassSpaces
    {
        public int sNumber { get; set; }

        [DisplayName("場地名稱")]
        public string sName { get; set; }

        [DisplayName("活動類型")]
        public string sType { get; set; }

        [DisplayName("地址")]
        public string sAddr { get; set; }

        [DisplayName("連絡電話")]
        public string sPhone { get; set; }

        [DisplayName("樓層")]
        public string sFloor { get; set; }

        [DisplayName("場地高度")]
        public string sHeight { get; set; }

        [DisplayName("場地面積")]
        public string sArea { get; set; }

        [DisplayName("可容納人數")]
        public string sCapacity { get; set; }

        [DisplayName("費用")]
        public decimal sRent { get; set; }

        [DisplayName("費率")]
        public decimal sRate { get; set; }

        [DisplayName("場地簡介")]
        public string sIntro { get; set; }

        [DisplayName("營業時間")]
        public string sOpeningTime { get; set; }

        [DisplayName("場地安全")]
        public string sSecurity { get; set; }

        [DisplayName("交通特色")]
        public string sTraffic { get; set; }

        [DisplayName("建立時間")]
        public System.DateTime sCreated_at { get; set; }

        [DisplayName("更新時間")]
        public System.DateTime sUpdated_at { get; set; }

        public Nullable<int> FK_Space_to_Owner { get; set; }

        public string oAccount { get; set; }

        public Nullable<int> oPrice { get; set; }

        public string sTimeRange { get; set; }
    }
}