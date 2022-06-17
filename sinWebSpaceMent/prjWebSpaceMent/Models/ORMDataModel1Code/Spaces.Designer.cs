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

    public partial class Spaces : XPLiteObject
    {
        int fsNumber;
        [Key(true)]
        public int sNumber
        {
            get { return fsNumber; }
            set { SetPropertyValue<int>(nameof(sNumber), ref fsNumber, value); }
        }
        string fsName;
        [Size(50)]
        public string sName
        {
            get { return fsName; }
            set { SetPropertyValue<string>(nameof(sName), ref fsName, value); }
        }
        string fsType;
        [Size(20)]
        public string sType
        {
            get { return fsType; }
            set { SetPropertyValue<string>(nameof(sType), ref fsType, value); }
        }
        string fsAddr;
        [Size(150)]
        public string sAddr
        {
            get { return fsAddr; }
            set { SetPropertyValue<string>(nameof(sAddr), ref fsAddr, value); }
        }
        string fsPhone;
        [Size(20)]
        public string sPhone
        {
            get { return fsPhone; }
            set { SetPropertyValue<string>(nameof(sPhone), ref fsPhone, value); }
        }
        string fsFloor;
        [Size(10)]
        public string sFloor
        {
            get { return fsFloor; }
            set { SetPropertyValue<string>(nameof(sFloor), ref fsFloor, value); }
        }
        string fsHeight;
        [Size(10)]
        public string sHeight
        {
            get { return fsHeight; }
            set { SetPropertyValue<string>(nameof(sHeight), ref fsHeight, value); }
        }
        string fsArea;
        [Size(10)]
        public string sArea
        {
            get { return fsArea; }
            set { SetPropertyValue<string>(nameof(sArea), ref fsArea, value); }
        }
        string fsCapacity;
        [Size(10)]
        public string sCapacity
        {
            get { return fsCapacity; }
            set { SetPropertyValue<string>(nameof(sCapacity), ref fsCapacity, value); }
        }
        decimal fsRent;
        public decimal sRent
        {
            get { return fsRent; }
            set { SetPropertyValue<decimal>(nameof(sRent), ref fsRent, value); }
        }
        decimal fsRate;
        public decimal sRate
        {
            get { return fsRate; }
            set { SetPropertyValue<decimal>(nameof(sRate), ref fsRate, value); }
        }
        string fsIntro;
        [Size(1000)]
        public string sIntro
        {
            get { return fsIntro; }
            set { SetPropertyValue<string>(nameof(sIntro), ref fsIntro, value); }
        }
        bool fsOpeningDays1;
        public bool sOpeningDays1
        {
            get { return fsOpeningDays1; }
            set { SetPropertyValue<bool>(nameof(sOpeningDays1), ref fsOpeningDays1, value); }
        }
        bool fsOpeningDays2;
        public bool sOpeningDays2
        {
            get { return fsOpeningDays2; }
            set { SetPropertyValue<bool>(nameof(sOpeningDays2), ref fsOpeningDays2, value); }
        }
        bool fsOpeningDays3;
        public bool sOpeningDays3
        {
            get { return fsOpeningDays3; }
            set { SetPropertyValue<bool>(nameof(sOpeningDays3), ref fsOpeningDays3, value); }
        }
        bool fsOpeningDays4;
        public bool sOpeningDays4
        {
            get { return fsOpeningDays4; }
            set { SetPropertyValue<bool>(nameof(sOpeningDays4), ref fsOpeningDays4, value); }
        }
        bool fsOpeningDays5;
        public bool sOpeningDays5
        {
            get { return fsOpeningDays5; }
            set { SetPropertyValue<bool>(nameof(sOpeningDays5), ref fsOpeningDays5, value); }
        }
        bool fsOpeningDays6;
        public bool sOpeningDays6
        {
            get { return fsOpeningDays6; }
            set { SetPropertyValue<bool>(nameof(sOpeningDays6), ref fsOpeningDays6, value); }
        }
        bool fsOpeningDays7;
        public bool sOpeningDays7
        {
            get { return fsOpeningDays7; }
            set { SetPropertyValue<bool>(nameof(sOpeningDays7), ref fsOpeningDays7, value); }
        }
        string fsSecurity;
        [Size(1000)]
        public string sSecurity
        {
            get { return fsSecurity; }
            set { SetPropertyValue<string>(nameof(sSecurity), ref fsSecurity, value); }
        }
        string fsTraffic;
        [Size(1000)]
        public string sTraffic
        {
            get { return fsTraffic; }
            set { SetPropertyValue<string>(nameof(sTraffic), ref fsTraffic, value); }
        }
        DateTime fsCreatedat;
        public DateTime sCreatedat
        {
            get { return fsCreatedat; }
            set { SetPropertyValue<DateTime>(nameof(sCreatedat), ref fsCreatedat, value); }
        }
        DateTime fsUpdatedat;
        public DateTime sUpdatedat
        {
            get { return fsUpdatedat; }
            set { SetPropertyValue<DateTime>(nameof(sUpdatedat), ref fsUpdatedat, value); }
        }
        Members fsFKtoMember;
        [Association(@"SpacesReferencesMembers")]
        public Members sFKtoMember
        {
            get { return fsFKtoMember; }
            set { SetPropertyValue<Members>(nameof(sFKtoMember), ref fsFKtoMember, value); }
        }
        [Association(@"ActivitiesReferencesSpaces")]
        public XPCollection<Activities> ActivitiesCollection { get { return GetCollection<Activities>(nameof(ActivitiesCollection)); } }
        [Association(@"OrdersReferencesSpaces")]
        public XPCollection<Orders> OrdersCollection { get { return GetCollection<Orders>(nameof(OrdersCollection)); } }
        [Association(@"PhotosReferencesSpaces")]
        public XPCollection<Photos> PhotosCollection { get { return GetCollection<Photos>(nameof(PhotosCollection)); } }
        [Association(@"RatesReferencesSpaces")]
        public XPCollection<Rates> RatesCollection { get { return GetCollection<Rates>(nameof(RatesCollection)); } }
        [Association(@"SubSpacesReferencesSpaces")]
        public XPCollection<SubSpaces> SubSpacesCollection { get { return GetCollection<SubSpaces>(nameof(SubSpacesCollection)); } }
    }

}
