using AnimalAdoptionSystem.Framework.Interfaces;
using AnimalAdoptionSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalAdoptionSystem.Framework.Executors
{
    public class DataAccessExecutor
    {
        private readonly PETADOPTIONEntities _entities;

        public DataAccessExecutor(PETADOPTIONEntities entities)
        {
            _entities = entities;
        }

        public TOutput Execute<TDataAccess, TInput, TOutput>(TInput input, params object[] additionalParameters) where TDataAccess : IDataAccess<TInput, TOutput>, new()
        {
            TDataAccess dataAccess = new TDataAccess();
            dataAccess.Entities = _entities;
            return dataAccess.Run(input, additionalParameters);
        }

        public void Execute<TDataAccess, TInput>(TInput input, params object[] additionalParameters) where TDataAccess : IDataAccess<TInput, object>, new()
        {
            Execute<TDataAccess, TInput, object>(input, additionalParameters);
        }
    }
}