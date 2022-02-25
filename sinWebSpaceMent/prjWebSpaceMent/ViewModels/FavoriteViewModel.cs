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
        public int FK_Favorite_to_Member { get; set; }
        public int FK_Favorite_to_Space { get; set; }
        public Nullable<DateTime> fCreated_at { get; set; }
    }
}