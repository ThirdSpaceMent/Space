using prjWebSpaceMent.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace prjWebSpaceMent.ViewModels
{
    public class FavoriteViewModel
    {
        public int sNumber { get; set; }
        [DisplayName("場地名稱")]
        public string sName { get; set; }
        [DisplayName("地址")]
        public string sAddr { get; set; }
        [DisplayName("費用")]
        public decimal sRent { get; set; }
        [DisplayName("場地簡介")]
        public string sIntro { get; set; }
        public int fFKtoMember { get; set; }
        public int fFKtoSpace { get; set; }
        public Nullable<DateTime> fCreatedat { get; set; }
    }
}