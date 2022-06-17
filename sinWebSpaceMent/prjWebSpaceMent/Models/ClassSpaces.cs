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

        public bool sOpeningDays1 { get; set; }
        public bool sOpeningDays2 { get; set; }
        public bool sOpeningDays3 { get; set; }
        public bool sOpeningDays4 { get; set; }
        public bool sOpeningDays5 { get; set; }
        public bool sOpeningDays6 { get; set; }
        public bool sOpeningDays7 { get; set; }

        [DisplayName("營業開始時間")]
        public TimeSpan sOpeningTime1 { get; set; }

        [DisplayName("營業結束時間")]
        public TimeSpan sClosingTime1 { get; set; }
        public TimeSpan sOpeningTime2 { get; set; }
        public TimeSpan sClosingTime2 { get; set; }
        public TimeSpan sOpeningTime3 { get; set; }
        public TimeSpan sClosingTime3 { get; set; }

        [DisplayName("場地安全")]
        public string sSecurity { get; set; }

        [DisplayName("交通特色")]
        public string sTraffic { get; set; }

        [DisplayName("建立時間")]
        public System.DateTime sCreatedat { get; set; }

        [DisplayName("更新時間")]
        public System.DateTime sUpdatedat { get; set; }

        public Nullable<int> sFKtoMember { get; set; }

        [DisplayName("場地照片(主圖)")]
        public string sPhoto1 { get; set; }
        [DisplayName("場地照片(附圖1)")]
        public string sPhoto2 { get; set; }
        [DisplayName("場地照片(附圖2)")]
        public string sPhoto3 { get; set; }
        public decimal RatingAVG { get; set; }
    }
}