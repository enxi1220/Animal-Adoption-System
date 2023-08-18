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
    public class BLEditPet : BaseBusinessLogic<PET, object>
    {
        protected override object Execute(PET input, DataAccessExecutor dataAccessExecutor, object[] additionalParameters)
        {
            dataAccessExecutor.Execute<DAEditPet, PET>(input);
            return null;
        }

        protected override void Initialize(PET input, object[] additionalParameters)
        {
            input.UPDATEDDATE = DateTime.Now;
        }
    }
}