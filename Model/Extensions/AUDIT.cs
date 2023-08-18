using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalAdoptionSystem.Model
{
    public partial class AUDIT
    {
        public string PETNO { get; set; }

        public string PETNAME { get; set; }

        public IEnumerable<string> Statuses { get; set; }
    }
}