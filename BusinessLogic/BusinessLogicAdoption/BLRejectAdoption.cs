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
    public class BLRejectAdoption : BaseBusinessLogic<ADOPTION, object>
    {

        protected override object Execute(ADOPTION input, DataAccessExecutor dataAccessExecutor, object[] additionalParameters)
        {
            ADOPTION adoption = dataAccessExecutor.Execute<DAGetAdoption, ADOPTION, IEnumerable<ADOPTION>>(input, additionalParameters).First();
            PET pet = dataAccessExecutor.Execute<DAGetPet, PET, IEnumerable<PET>>(new PET() { PETID = adoption.PETID }, additionalParameters).FirstOrDefault();
            if (adoption.STATUS.Equals(Constant.getAdoptStatus(Constant.AdoptStatusEnum.Rejected)))
            {
                throw new Exception(adoption.ADOPTIONNO + " has been rejected.");
            }
            if (adoption.STATUS.Equals(Constant.getAdoptStatus(Constant.AdoptStatusEnum.Canceled)))
            {
                throw new Exception(adoption.ADOPTIONNO + " has been canceled.");
            }

            // chg adopt status
            //chg pet status
            dataAccessExecutor.Execute<DAEditAdoption, ADOPTION>(input, additionalParameters);

            pet.STATUS = Constant.getPetStatus(Constant.PetStatusEnum.New);
            dataAccessExecutor.Execute<DAEditPet, PET>(pet, additionalParameters);

            return null;
        }

        protected override void Initialize(ADOPTION input, object[] additionalParameters)
        {
            input.STATUS = Constant.getAdoptStatus(Constant.AdoptStatusEnum.Rejected);
            input.UPDATEDDATE = DateTime.Now;
        }
    }
}