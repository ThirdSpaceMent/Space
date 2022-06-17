﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace prjWebSpaceMent.Models.SPACEMENT
{

    public partial class Rates : XPLiteObject
    {
        int frNumber;
        [Key(true)]
        public int rNumber
        {
            get { return frNumber; }
            set { SetPropertyValue<int>(nameof(rNumber), ref frNumber, value); }
        }
        decimal frRate;
        public decimal rRate
        {
            get { return frRate; }
            set { SetPropertyValue<decimal>(nameof(rRate), ref frRate, value); }
        }
        string frComment;
        [Size(300)]
        public string rComment
        {
            get { return frComment; }
            set { SetPropertyValue<string>(nameof(rComment), ref frComment, value); }
        }
        DateTime frCreatedat;
        public DateTime rCreatedat
        {
            get { return frCreatedat; }
            set { SetPropertyValue<DateTime>(nameof(rCreatedat), ref frCreatedat, value); }
        }
        DateTime frUpdatedat;
        public DateTime rUpdatedat
        {
            get { return frUpdatedat; }
            set { SetPropertyValue<DateTime>(nameof(rUpdatedat), ref frUpdatedat, value); }
        }
        Members frFKtoMember;
        [Association(@"RatesReferencesMembers")]
        public Members rFKtoMember
        {
            get { return frFKtoMember; }
            set { SetPropertyValue<Members>(nameof(rFKtoMember), ref frFKtoMember, value); }
        }
        Spaces frFKtoSpace;
        [Association(@"RatesReferencesSpaces")]
        public Spaces rFKtoSpace
        {
            get { return frFKtoSpace; }
            set { SetPropertyValue<Spaces>(nameof(rFKtoSpace), ref frFKtoSpace, value); }
        }
        Orders frFKtoOrder;
        [Association(@"RatesReferencesOrders")]
        public Orders rFKtoOrder
        {
            get { return frFKtoOrder; }
            set { SetPropertyValue<Orders>(nameof(rFKtoOrder), ref frFKtoOrder, value); }
        }
    }

}