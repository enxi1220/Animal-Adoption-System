using AnimalAdoptionSystem.DataAccess.DataAccessAdoption;
using AnimalAdoptionSystem.Framework.Bases;
using AnimalAdoptionSystem.Framework.Executors;
using AnimalAdoptionSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalAdoptionSystem.BusinessLogic.BusinessLogicAdoption
{
    public class BLGetAdoption : BaseBusinessLogic<ADOPTION, IEnumerable<ADOPTION>>
    {
        protected override IEnumerable<ADOPTION> Execute(ADOPTION input, DataAccessExecutor dataAccessExecutor, object[] additionalParameters)
        {
            return dataAccessExecutor.Execute<DAGetAdoption, ADOPTION, IEnumerable<ADOPTION>>(input, additionalParameters);
        }
    }
}