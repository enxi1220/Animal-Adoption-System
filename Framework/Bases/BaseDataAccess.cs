using AnimalAdoptionSystem.Framework.Interfaces;
using AnimalAdoptionSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalAdoptionSystem.Framework.Bases
{
    public abstract class BaseDataAccess<TInput, TOutput> : IDataAccess<TInput, TOutput>
    {
        public PETADOPTIONEntities Entities { get; set; }

        public TOutput Run(TInput input, params object[] additionalParameters)
        {
            Initialize(input, additionalParameters);
            return Execute(Entities, input, additionalParameters);
        }

        protected abstract TOutput Execute(PETADOPTIONEntities entity, TInput input, object[] additionalParameters);

        protected virtual void Initialize(TInput input, object[] additionalParameters)
        {
        }
    }
}