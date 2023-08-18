using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalAdoptionSystem.Framework.Interfaces
{
    public interface IBusinessLogic<TInput, TOutput>
    {
        TOutput Run(TInput input, params object[] additionalParameters);
    }
}
