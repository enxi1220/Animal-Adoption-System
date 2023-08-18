using AnimalAdoptionSystem.DataAccess.DataAccessPet;
using AnimalAdoptionSystem.Framework.Bases;
using AnimalAdoptionSystem.Framework.Executors;
using AnimalAdoptionSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalAdoptionSystem.BusinessLogic.BusinessLogicPet
{
    public class BLGetPet : BaseBusinessLogic<PET, IEnumerable<PET>>
    {
        protected override IEnumerable<PET> Execute(PET input, DataAccessExecutor dataAccessExecutor, object[] additionalParameters)
        {
            return dataAccessExecutor.Execute<DAGetPet, PET, IEnumerable<PET>>(input, additionalParameters);
        }
        
    }
}