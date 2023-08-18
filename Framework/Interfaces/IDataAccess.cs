using AnimalAdoptionSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalAdoptionSystem.Framework.Interfaces
{
    public interface IDataAccess<TInput, TOutput>
    {
        PETADOPTIONEntities Entities { get; set; }
        TOutput Run(TInput input, params object[] additionalParameters);
    }
}
