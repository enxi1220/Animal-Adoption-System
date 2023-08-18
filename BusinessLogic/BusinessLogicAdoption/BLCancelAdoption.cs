using AnimalAdoptionSystem.DataAccess.DataAccessAdoption;
using AnimalAdoptionSystem.DataAccess.DataAccessPet;
using AnimalAdoptionSystem.Framework.Bases;
using AnimalAdoptionSystem.Framework.Executors;
using AnimalAdoptionSystem.Helper;
using AnimalAdoptionSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalAdoptionSystem.BusinessLogic.BusinessLogicAdoption
{
    public class BLCancelAdoption : BaseBusinessLogic<ADOPTION, object>
    {
        protected override object Execute(ADOPTION input, DataAccessExecutor dataAccessExecutor, object[] additionalParameters)
        {
            dataAccessExecutor.Execute<DAEditAdoption, ADOPTION>(input, additionalParameters);
            dataAccessExecutor.Execute<DAEditPet, PET>(new PET() { STATUS = Constant.getPetStatus(Constant.PetStatusEnum.New) });
            return null;
        }

        protected override void Initialize(ADOPTION input, object[] additionalParameters)
        {
            input.STATUS = Constant.getAdoptStatus(Constant.AdoptStatusEnum.Canceled);
            input.UPDATEDDATE = DateTime.Now;
        }
    }
}