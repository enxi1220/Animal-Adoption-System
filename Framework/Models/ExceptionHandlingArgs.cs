using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalAdoptionSystem.Framework.Models
{
    public class ExceptionHandlingArgs: EventArgs
    {
        public bool IsHandled { get; set; }

        public Exception Exception { get; set; }
    }
}