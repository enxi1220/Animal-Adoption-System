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
    
    public partial class EUTHANASIA
    {
        public int EUTHANASIAID { get; set; }
        public string EUTHANASIANO { get; set; }
        public string DESC { get; set; }
        public int PETID { get; set; }
        public Nullable<double> DOSE { get; set; }
        public string UOM { get; set; }
        public string MEDICINE { get; set; }
        public string STATUS { get; set; }
        public Nullable<System.DateTime> EXECUTIONDATE { get; set; }
        public Nullable<System.DateTime> CREATEDDATE { get; set; }
        public string CREATEDBY { get; set; }
        public Nullable<System.DateTime> UPDATEDDATE { get; set; }
        public string UPDATEDBY { get; set; }
    
        public virtual PET PET { get; set; }
    }
}