//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AnimalAdoptionSystem.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class ADOPTION
    {
        public int ADOPTIONID { get; set; }
        public string ADOPTIONNO { get; set; }
        public int CUSTOMERID { get; set; }
        public int PETID { get; set; }
        public string ICIMAGE { get; set; }
        public string PHONE { get; set; }
        public string STATUS { get; set; }
        public string PETNO { get; set; }
        public string NAME { get; set; }
        public string AGE { get; set; }
        public string SIZE { get; set; }
        public string GENDER { get; set; }
        public string BREED { get; set; }
        public string TYPE { get; set; }
        public string IMAGE { get; set; }
        public string DESC { get; set; }
        public string REASONOFREJECTION { get; set; }
        public Nullable<System.DateTime> CREATEDDATE { get; set; }
        public string CREATEDBY { get; set; }
        public Nullable<System.DateTime> UPDATEDDATE { get; set; }
        public string UPDATEDBY { get; set; }
        public string CUSTOMERNAME { get; set; }
    
        public virtual CUSTOMER CUSTOMER { get; set; }
        public virtual PET PET { get; set; }
    }
}