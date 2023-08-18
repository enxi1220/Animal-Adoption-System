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
    public class BLApproveAdoption : BaseBusinessLogic<ADOPTION, object>
    {
        protected override object Execute(ADOPTION input, DataAccessExecutor dataAccessExecutor, object[] additionalParameters)
        {
            ADOPTION adoption = dataAccessExecutor.Execute<DAGetAdoption, ADOPTION, IEnumerable<ADOPTION>>(input, additionalParameters).First();
            PET pet = dataAccessExecutor.Execute<DAGetPet, PET, IEnumerable<PET>>(new PET() { PETID = adoption.PETID }, additionalParameters).FirstOrDefault();
            if (adoption.STATUS.Equals(Constant.getAdoptStatus(Constant.AdoptStatusEnum.Approved)))
            {
                throw new Exception(adoption.ADOPTIONNO + " has been approved.");
            }
            if (adoption.STATUS.Equals(Constant.getAdoptStatus(Constant.AdoptStatusEnum.Canceled)))
            {
                throw new Exception(adoption.ADOPTIONNO + " has been canceled.");
            }

            // chg adopt status
            //chg pet info (owner, adoptiontime, status)
            pet.OWNER = adoption.CREATEDBY;
            pet.ADOPTIONTIME = DateTime.Now;
            pet.STATUS = Constant.getPetStatus(Constant.PetStatusEnum.Adopted);
            dataAccessExecutor.Execute<DAEditPet, PET>(pet, additionalParameters);
            dataAccessExecutor.Execute<DAEditAdoption, ADOPTION>(input, additionalParameters);


            return null;
        }

        protected override void Initialize(ADOPTION input, object[] additionalParameters)
        {
            input.STATUS = Constant.getAdoptStatus(Constant.AdoptStatusEnum.Approved);
            input.REASONOFREJECTION = default(string);
            input.UPDATEDDATE = DateTime.Now;
        }
    }
}