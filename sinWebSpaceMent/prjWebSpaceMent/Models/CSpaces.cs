using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace prjWebSpaceMent.Models
{
    public class CSpaces
    {

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

        //public System.DateTime sCreated_at { get; set; }

        //public System.DateTime sUpdated_at { get; set; }

        //public Nullable<int> FK_Space_to_Owner { get; set; }
    }
}