using AnimalAdoptionSystem.Framework.Interfaces;
using AnimalAdoptionSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalAdoptionSystem.Framework.Executors
{
    public class BusinessLogicExecutor
    {
        public static TOutput Execute<TBusinessLogic, TInput, TOutput>(TInput input, params object[] additionalParameters) where TBusinessLogic : IBusinessLogic<TInput, TOutput>, new()
        {
            TBusinessLogic businessLogic = new TBusinessLogic();
            return businessLogic.Run(input, additionalParameters);
        }

        public static void Execute<TBusinessLogic, TInput>(TInput input, params object[] additionalParameters) where TBusinessLogic : IBusinessLogic<TInput, object>, new()
        {
            Execute<TBusinessLogic, TInput, object>(input, additionalParameters);
        }
    }
}