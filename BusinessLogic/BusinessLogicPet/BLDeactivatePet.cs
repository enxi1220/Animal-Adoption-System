using AnimalAdoptionSystem.DataAccess.DataAccessPet;
using AnimalAdoptionSystem.Framework.Bases;
using AnimalAdoptionSystem.Framework.Executors;
using AnimalAdoptionSystem.Helper;
using AnimalAdoptionSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalAdoptionSystem.BusinessLogic.BusinessLogicPet
{
    public class BLDeactivatePet : BaseBusinessLogic<PET, object>
    {
        protected override object Execute(PET input, DataAccessExecutor dataAccessExecutor, object[] additionalParameters)
        {
            dataAccessExecutor.Execute<DAEditPet, PET>(input, additionalParameters);
            return null;
        }

        protected override void Initialize(PET input, object[] additionalParameters)
        {
            input.STATUS = Constant.getPetStatus(Constant.PetStatusEnum.Deactivate);
            input.UPDATEDDATE = DateTime.Now;
        }
    }
}