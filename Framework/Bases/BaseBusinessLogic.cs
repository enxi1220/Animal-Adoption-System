using AnimalAdoptionSystem.Framework.Executors;
using AnimalAdoptionSystem.Framework.Interfaces;
using AnimalAdoptionSystem.Framework.Models;
using AnimalAdoptionSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalAdoptionSystem.Framework.Bases
{
    public abstract class BaseBusinessLogic<TInput, TOutput> : IBusinessLogic<TInput, TOutput>
    {
        public TOutput Run(TInput input, params object[] additionalParameters)
        {
            using (PETADOPTIONEntities entities = new PETADOPTIONEntities())
            using (var transaction = entities.Database.BeginTransaction())
            {
                try
                {
                    var dataAccessExecutor = new DataAccessExecutor(entities);
                    Initialize(input, additionalParameters);
                    var output = Execute(input, dataAccessExecutor, additionalParameters);
                    transaction.Commit();
                    return output;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    var args = new ExceptionHandlingArgs()
                    {
                        IsHandled = false,
                        Exception = ex
                    };
                    ExceptionHandling(args);

                    if (!args.IsHandled)
                    {
                        throw;
                    }
                }
                return default(TOutput);
            }
        }

        protected virtual void ExceptionHandling(ExceptionHandlingArgs args)
        {
        }

        protected abstract TOutput Execute(TInput input, DataAccessExecutor dataAccessExecutor, object[] additionalParameters);

        protected virtual void Initialize(TInput input, object[] additionalParameters)
        {
        }
    }
}