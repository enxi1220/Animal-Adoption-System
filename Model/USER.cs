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
    
    public partial class USER
    {
        public int USERID { get; set; }
        public string USERNAME { get; set; }
        public string STATUS { get; set; }
        public string USERGROUPNAME { get; set; }
        public string NAME { get; set; }
        public string PASSWORD { get; set; }
        public string PHONE { get; set; }
        public string MAIL { get; set; }
        public Nullable<System.DateTime> CREATEDDATE { get; set; }
        public string CREATEDBY { get; set; }
        public Nullable<System.DateTime> UPDATEDDATE { get; set; }
        public string UPDATEDBY { get; set; }
    
        public virtual USERGROUP USERGROUP { get; set; }
    }
}
